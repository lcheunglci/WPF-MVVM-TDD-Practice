﻿namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            // TODO: Fix this 
            // NavigationViewModel = new NavigationViewModel();
        }

        public NavigationViewModel NavigationViewModel { get; private set; }

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
