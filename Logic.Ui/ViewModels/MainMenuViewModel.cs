using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
   public class MainMenuViewModel : AbstractViewModel
    {
        public static IEnumerable<CategoryWrapper> GetCategoryWrappers()
        {
            List<CategoryWrapper> listCat = new List<CategoryWrapper>();
            listCat.Add(new CategoryWrapper { Name = "Math" });
            listCat.Add(new CategoryWrapper { Name = "B" });
            listCat.Add(new CategoryWrapper { Name = "C" });
            listCat.Add(new CategoryWrapper { Name = "D" });
            listCat.Add(new CategoryWrapper { Name = "E" });


            return listCat;
        }
       
      
        public static ObservableCollection<CategoryWrapper> Categories = new ObservableCollection<CategoryWrapper>(GetCategoryWrappers());
        /*
        public RelayCommand ChangeModelCommand { get; }

        public MainMenuViewModel() { 

        }
        public string NumberOfCategories
        {
            get
            {
                return Categories.Count + "sind vorhanden";
            }
        }

        // HilfesFunktion zum Suchen nach einer Kategorie in dem Collection 
        public string getCategoryName(string categoryName)
        {

            return null; 
        }


        // HilfesFunktion zum Sortieren: Kategorien werden nach Name sortiert!! 
        public void NameSort() 
        {

        }

        // HilfesFunktion zum Sortieren: Kategorien werden nach Date sortiert!! 
        public void DateSort()
        {

        }
        */

    }
}
