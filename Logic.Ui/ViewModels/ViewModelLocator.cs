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
            CreateCategoryVM = new CreateCategoryViewModel();
            CreateCardVM = new CreateCardViewModel();
            ExamModeVM = new ExamModeViewModel();
            LernmodusVM = new LernmodusViewModel();
            MainMenuVM = new MainMenuViewModel();
            ViewCategoryVM = new ViewCategoryViewModel();
            ExportVM = new ExportViewModel();
           

        }
        // ToDo: Inhalte für Vorlesung: Achtung: diese Properties 
        // müssen Public sein, da sie von XMAL aus referenziert werden! 
        // Compiler erwartet nur internal...
        public MainMenuViewModel MainWindowVM { get; }
        //public StatisticsWindowViewModel StatisticWindowVM { get; }
        public CreateCategoryViewModel CreateCategoryVM { get; }
        public CreateCardViewModel CreateCardVM { get; }
        public ExamModeViewModel ExamModeVM { get; }

        public LernmodusViewModel LernmodusVM { get; }

        public MainMenuViewModel MainMenuVM { get; }

        public ViewCategoryViewModel ViewCategoryVM { get; }
        public ExportViewModel ExportVM { get; }
    }
}
