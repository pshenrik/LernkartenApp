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
            Set = new SetViewModel();
            generateCards();

            MainMenuVM = new MainMenuViewModel(Set);
            ImportVM = new ImportViewModel(Set); 
            ViewMarkedCardsVM = new ViewMarkedCardsViewModel(Set);
            CreateCategoryVM = new CreateCategoryViewModel(Set);
            CreateCardVM = new CreateCardViewModel(Set);
            ExamModeVM = new ExamModeViewModel(Set);
            LernmodusVM = new LernmodusViewModel(Set);
            
            ViewCategoryVM = new ViewCategoryViewModel(Set);
            ExportVM = new ExportViewModel(Set);
            StatisticsVM = new StatisticsViewModel(Set);
            EditCardVM = new EditCardViewModel(Set);
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
        public ImportViewModel ImportVM { get; }
        public ViewCategoryViewModel ViewCategoryVM { get; }
        public ExportViewModel ExportVM { get; }

        public StatisticsViewModel StatisticsVM { get; }
        public EditCardViewModel EditCardVM { get; }
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
                    card.Keywords.Add("test");
                    card.Keywords.Add("KATEGORIE");
                    card.Keywords.Add("FUN");
                    card.Keywords.Add("apache");
                    if ( (i + j)%2 == 0 ) { 
                        card.Info.Marked = true;
                    }

                    cat.Collections[0].Add(card);
                }


                Set.Add(cat);
            }
        }
    }
}
