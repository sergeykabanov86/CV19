using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Wpf.ViewModels.Base;

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




        #endregion Commands



        #region Constructors

        public MainView()
        {
            ChangeTitle("new CV19 Window Title");
        }

        private void ChangeTitle(string newTitle) { WndTitle = newTitle; }

        #endregion Constructors



        #region Methods




        #endregion Methods

    }
}
