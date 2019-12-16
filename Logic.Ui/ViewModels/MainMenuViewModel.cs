using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using System.Windows.Input;
using De.HsFlensburg.LernkartenApp001.Services.ServiceBus;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Messages;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
   public class MainMenuViewModel : AbstractViewModel
    {
        public static IEnumerable<CategoryViewModel> GetCategoryWrappers()
        {
            List<CategoryViewModel> listCat = new List<CategoryViewModel>();
            /*listCat.Add(new CategoryViewModel { Name = "Math" });
            listCat.Add(new CategoryViewModel { Name = "B" });
            listCat.Add(new CategoryViewModel { Name = "C" });
            listCat.Add(new CategoryViewModel { Name = "D" });
            listCat.Add(new CategoryViewModel { Name = "E" });*/


            return listCat;
        }
       
      
        public static ObservableCollection<CategoryViewModel> Categories = new ObservableCollection<CategoryViewModel>(GetCategoryWrappers());

        private ICommand testMethodVar; 
          public MainMenuViewModel() {
            testMethodVar = new RelayCommand(this.Test, this.getTrue); 
        }
        private void OpenCreateCategoryWindow()
        {
            ServiceBus.Instance.Send(new OpenCreateCategoryWindow());
        }
        public RelayCommand OpenCreateCategoryWindowCommand { get; }

        public ICommand TestMethode
        {
            get
            {
                return testMethodVar; 
            }
        }
        public void Test()
        {

            Console.WriteLine("HIHIHIHIHIH"); 
        }
        private bool getTrue()
        {
            return true; 
        }


        /*
        public RelayCommand ChangeModelCommand { get; }

      
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
