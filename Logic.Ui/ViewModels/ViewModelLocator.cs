using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ViewModelLocator
    {
        


        public ViewModelLocator()
        {
            ViewMarkedCardsVM = new ViewMarkedCardsViewModel();
            CreateCategoryVM = new CreateCategoryViewModel();
            CreateCardVM = new CreateCardViewModel();
            ExamModeVM = new ExamModeViewModel();
            LernmodusVM = new LernmodusViewModel();
            MainMenuVM = new MainMenuViewModel();
            ViewCategoryVM = new ViewCategoryViewModel();
            ExportVM = new ExportViewModel();
            StatisticsVM = new StatisticsViewModel();
        }
        // ToDo: Inhalte für Vorlesung: Achtung: diese Properties 
        // müssen Public sein, da sie von XMAL aus referenziert werden! 
        // Compiler erwartet nur internal...
        public ViewMarkedCardsViewModel ViewMarkedCardsVM { get;  }
        public MainMenuViewModel MainWindowVM { get; }
        //public StatisticsWindowViewModel StatisticWindowVM { get; }
        public CreateCategoryViewModel CreateCategoryVM { get; }
        public CreateCardViewModel CreateCardVM { get; }
        public ExamModeViewModel ExamModeVM { get; }

        public LernmodusViewModel LernmodusVM { get; }

        public MainMenuViewModel MainMenuVM { get; }

        public ViewCategoryViewModel ViewCategoryVM { get; }
        public ExportViewModel ExportVM { get; }

        public StatisticsViewModel StatisticsVM { get; }
    }
}
