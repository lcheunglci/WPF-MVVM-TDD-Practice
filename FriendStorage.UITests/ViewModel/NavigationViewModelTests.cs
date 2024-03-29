﻿using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        private Mock<INavigationDataProvider> _navigationDataProviderMock;
        private NavigationViewModel _viewModel;
        private FriendSavedEvent _friendSavedEvent;
        private FriendDeletedEvent _friendDeletedEvent;

        public NavigationViewModelTests()
        {
            _friendSavedEvent = new FriendSavedEvent();
            _friendDeletedEvent = new FriendDeletedEvent();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock.Setup(ea => ea.GetEvent<FriendSavedEvent>())
                .Returns(_friendSavedEvent);
            eventAggregatorMock.Setup(ea => ea.GetEvent<FriendDeletedEvent>())
                .Returns(_friendDeletedEvent);

            _navigationDataProviderMock = new Mock<INavigationDataProvider>();
            _navigationDataProviderMock.Setup(dp => dp.GetAllFriends()).Returns(
                new List<LookupItem> {
                    new LookupItem { Id = 1, DisplayMember = "Julia" },
                    new LookupItem { Id = 2, DisplayMember = "Bob" }
            });

            _viewModel = new NavigationViewModel(_navigationDataProviderMock.Object, eventAggregatorMock.Object);
        }

        [Fact]
        public void ShouldLoadFriends()
        {

            _viewModel.Load();

            Assert.Equal(2, _viewModel.Friends.Count);

            var friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend);
            Assert.Equal("Julia", friend.DisplayMember);

            friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Bob", friend.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            _viewModel.Load();
            _viewModel.Load();

            Assert.Equal(2, _viewModel.Friends.Count);
        }

        [Fact]
        public void ShouldUpdateNavigationItemWhenFriendIsSaved()
        {
            _viewModel.Load();
            var navigationItem = _viewModel.Friends.First();

            var friendId = navigationItem.Id;

            _friendSavedEvent.Publish(
                new Friend
                {
                    Id = friendId,
                    FirstName = "Amy",
                    LastName = "Doe"
                });

            Assert.Equal("Amy Doe", navigationItem.DisplayMember);
        }

        [Fact]
        public void ShouldUpdateNavigationItemWhenAddedFriendIsSaved()
        {
            _viewModel.Load();

            const int newFriendId = 97;

            _friendSavedEvent.Publish(
                new Friend
                {
                    Id = newFriendId,
                    FirstName = "Amy",
                    LastName = "Doe"
                });

            Assert.Equal(3, _viewModel.Friends.Count);

            var addedItem = _viewModel.Friends.SingleOrDefault(f => f.Id == newFriendId);
            Assert.NotNull(addedItem);
            Assert.Equal("Amy Doe", addedItem.DisplayMember);
        }

        [Fact]
        public void ShouldRemoveNavigationItemWhenFriendIsDeleted()
        {
            _viewModel.Load();
            var deletedFriendId = _viewModel.Friends.First().Id;
            _friendDeletedEvent.Publish(deletedFriendId);

            Assert.Equal(1, _viewModel.Friends.Count);
            Assert.NotEqual(deletedFriendId, _viewModel.Friends.Single().Id);
        }
    }
}

