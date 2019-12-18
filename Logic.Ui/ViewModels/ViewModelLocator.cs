using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ViewModelLocator
    {

        private SetViewModel Set;

        public ViewModelLocator()
        {
            generateCards();

            ViewMarkedCardsVM = new ViewMarkedCardsViewModel();
            CreateCategoryVM = new CreateCategoryViewModel();
            CreateCardVM = new CreateCardViewModel();
            ExamModeVM = new ExamModeViewModel();
            LernmodusVM = new LernmodusViewModel(new Wrapper.CategoryViewModel());
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

        private void generateCards()
        {
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                CategoryViewModel cat = new CategoryViewModel("Kategorie" + (i + 1));

                for (int j = 0; j < (i * 2); j++)
                {
                    counter++;
                    CardViewModel card = new CardViewModel("Karte Nummer " + counter);
                    card.Front.Text = "Kategorie " + (i + 1) + " Frage " + (j + 1);
                    card.Back.Text = "Kategorie " + (i + 1) + " Antwort " + (j + 1);
                    

                    if( i +j == 0 % 2)
                    {
                        card.Marked = true;
                    }

                    cat.Collections[0].Add(card);
                }


                Set.Add(cat);
            }
        }
    }
}
