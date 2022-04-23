using FriendStorage.Model;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int friendId);
        Friend Friend { get; }
    }

    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider _friendProvider;

        public FriendEditViewModel(IFriendDataProvider friendProvider)
        {
            _friendProvider = friendProvider;
        }

        public Friend Friend => throw new System.NotImplementedException();

        public void Load(int friendId)
        {
            throw new System.NotImplementedException();
        }
    }
}
