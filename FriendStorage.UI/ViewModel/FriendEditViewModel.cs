using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider;
using System;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int friendId);
        Friend Friend { get; }
    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider _dataProvider;
        private Friend _friend;

        public FriendEditViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute(object arg)
        {
            throw new NotImplementedException();
        }

        private void OnSaveExecute(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand SaveCommand { get; private set; }

        public Friend Friend
        {
            get
            {
                return _friend;
            }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }
        public void Load(int friendId)
        {
            var friend = _dataProvider.GetFriendById(friendId);
            Friend = friend;
        }
    }
}
