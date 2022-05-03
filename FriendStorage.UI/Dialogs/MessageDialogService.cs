using FriendStorage.UI.View;
using System.Windows;

namespace FriendStorage.UI.Dialogs
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowYesNoDialog(string title, string message)
        {
            return new YesNoDialog(message, title)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = App.Current.MainWindow
            }.ShowDialog().GetValueOrDefault()
                ? MessageDialogResult.Yes
                : MessageDialogResult.No;
        }
    }
}
