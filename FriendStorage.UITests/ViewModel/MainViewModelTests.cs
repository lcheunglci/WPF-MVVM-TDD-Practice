using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class MainViewModelTests
    {
        private OpenFriendEditViewEvent _openFriendEditViewEvent;
        private Mock<INavigationViewModel> _navigationViewModelMock;
        private Mock<IEventAggregator> _eventAggregatorMock;
        private MainViewModel _viewModel;
        private List<Mock<IFriendEditViewModel>> _friendEditViewModelMocks;

        public MainViewModelTests()
        {
            _friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            _openFriendEditViewEvent = new OpenFriendEditViewEvent();
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>()).Returns(_openFriendEditViewEvent);

            _viewModel = new MainViewModel(_navigationViewModelMock.Object, CreateFriendEditViewModel, _eventAggregatorMock.Object);

        }

        private IFriendEditViewModel CreateFriendEditViewModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            _friendEditViewModelMocks.Add(friendEditViewModelMock);
            return friendEditViewModelMock.Object;
        }

        [Fact]
        public void ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            _viewModel.Load();

            _navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
        }

        [Fact]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt()
        {
            const int friendId = 7;
            _openFriendEditViewEvent.Publish(friendId);

            Assert.Equal(1, _viewModel.FriendEditViewModels.Count);
            var friendEditVm = _viewModel.FriendEditViewModels.First();
            Assert.Equal(friendEditVm, _viewModel.SelectedFriendViewModel);
            _friendEditViewModelMocks.First().Verify(vm => vm.Load(friendId), Times.Once);
        }
    }
}
