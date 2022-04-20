using Prism.Events;
using System;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFriendEditViewModel _selectedFriendViewModel;
        private Func<IFriendEditViewModel> _friendEditVmCreator;


        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendEditViewModel> friendEditVmCreator, IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new ObservableCollection<IFriendEditViewModel>();
            _friendEditVmCreator = friendEditVmCreator;
        }

        public INavigationViewModel NavigationViewModel { get; private set; }

        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels { get; private set; }


        public IFriendEditViewModel SelectedFriendViewModel { get => _selectedFriendViewModel; set => _selectedFriendViewModel = value; }


        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
