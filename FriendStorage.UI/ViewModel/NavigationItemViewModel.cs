﻿using FriendStorage.UI.Command;
using FriendStorage.UI.Events;
using Prism.Events;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
            _eventAggregator = eventAggregator;
        }

        private void OnFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>().Publish(Id);
        }

        public int Id { get; private set; }
        private string _displayMember;
        public ICommand OpenFriendEditViewCommand { get; private set; }
        public string DisplayMember
        {
            get => _displayMember;
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }
    }
}
