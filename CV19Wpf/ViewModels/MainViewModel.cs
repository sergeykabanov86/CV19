using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CV19Wpf.Infrastructure.Commands;
using CommonLibrary.Views.Base;

namespace CV19Wpf.ViewModels
{
    public class MainView : ViewModel
    {

        #region Properties


        #region WndTitle - Window title
        /// <summary>Заголовок окна</summary>
        private string _WndTitle = "My fucking title";
        /// <summary>Заголовок окна</summary>
        public string WndTitle { get => _WndTitle; set => SetProperty(ref _WndTitle, value); }
        #endregion WndTitle


        #region Status - Status
        /// <summary> Status programm </summary>
        private string _Status = "Done!";
        /// <summary> Status programm </summary>
        public string Status { get => _Status; set => SetProperty(ref _Status, value); }
        #endregion Status



        #endregion Properties



        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExectue(object p)
        {
            return true;
        } 
        #endregion


        #endregion Commands



        #region Constructors

        public MainView()
        {
            ChangeTitle("new CV19 Window Title");

            #region CommandsInit
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExectue);

            #endregion
        }

        private void ChangeTitle(string newTitle) { WndTitle = newTitle; }

        #endregion Constructors



        #region Methods




        #endregion Methods

    }
}
