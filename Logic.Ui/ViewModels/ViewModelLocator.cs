using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            int variante = 1;

            if (variante == 0)
            {
                #region Variante1: Erzegung des Models im MainWindowViewModel
                // MainWindow wird erzeugt - und darin das Model...
                MainWindowVM = new MainWindowViewModel();
                // Das Model geholt...
                SetViewModel svm = MainWindowVM.getModel();
                // und allen weiteren ViewModels übergeben:
                StatisticWindowVM = new StatisticsWindowViewModel(svm);
                #endregion
            }
            else
            {
                #region Variante2: Erzegung des Models im ViewModelLocator
                // Das Model wird erzeugt
                SetViewModel svm = new SetViewModel();
                // und allen  ViewModels übergeben:
                MainWindowVM = new MainWindowViewModel(svm);
                StatisticWindowVM = new StatisticsWindowViewModel(svm);
                #endregion
            }

        }
        // ToDo: Inhalte für Vorlesung: Achtung: diese Properties 
        // müssen Public sein, da sie von XMAL aus referenziert werden! 
        // Compiler erwartet nur internal...
        public MainWindowViewModel MainWindowVM { get; }
        public StatisticsWindowViewModel StatisticWindowVM { get; }
    }
}
