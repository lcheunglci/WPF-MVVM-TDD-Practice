using FriendStorage.UI.Command;
using Prism.Events;
using System;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
        }

        private void OnFriendEditViewExecute(object obj)
        {
            throw new NotImplementedException();
        }

        public int Id { get; private set; }
        public string DisplayMember { get; private set; }
        public ICommand OpenFriendEditViewCommand { get; private set; }
    }
}
