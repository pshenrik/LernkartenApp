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
        
      
        public static IEnumerable<CategoryViewModel> getCategoryWrappers()
        {  
            List<CategoryViewModel> listCat = new List<CategoryViewModel>();
         
            listCat.Add(new CategoryViewModel { Name = "Math" });
            listCat.Add(new CategoryViewModel { Name = "B" });
            listCat.Add(new CategoryViewModel { Name = "C" });
            listCat.Add(new CategoryViewModel { Name = "D" });
            listCat.Add(new CategoryViewModel { Name = "E" });
            return listCat;
        }
       
      
        public static ObservableCollection<CategoryViewModel> categories = new ObservableCollection<CategoryViewModel>(getCategoryWrappers());

        private ICommand RemoveCategoryCommand;
        public RelayCommand OpenCreateCategoryWindowCommand { get; }
        public RelayCommand OpenExamModeWindowCommand { get; }
        public RelayCommand OpenStatisticsWindowCommand { get; }
        public RelayCommand OpenExportWindowCommand { get; }
        public RelayCommand OpenLernmodusWindowCommand { get; }
        public RelayCommand OpenViewCategoryWindowCommand { get;  }
        public CategoryViewModel SelectedCategory { get; set;}

        public static String NumberOfCategories { get; set; }


        public SetViewModel setViewModel; 
        public MainMenuViewModel() {
         //   testMethodVar = new RelayCommand(this.Test, this.getTrue);
            OpenCreateCategoryWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCategoryWindow()));
            OpenExamModeWindowCommand  = new RelayCommand(() => OpenWindow(new OpenExamModeWindow()));
            OpenStatisticsWindowCommand = new RelayCommand(() => OpenWindow(new OpenStatisticsWindow()));
            OpenExportWindowCommand = new RelayCommand(() => OpenWindow(new OpenExportWindow()));
            OpenLernmodusWindowCommand = new RelayCommand(() => OpenWindow(new OpenLernmodusWindow()));
            OpenViewCategoryWindowCommand = new RelayCommand(() => OpenViewCategoryWindowFunc(new OpenViewCategoryWindow()));
         
            RemoveCategoryCommand = new RelayCommand(this.removeCategoryfunction, this.getBoolean);
            NumberOfCategories = "                                   " + categories.Count() + " Kategorien"; 
     
        
        }


        public MainMenuViewModel(SetViewModel setViewModel)
        {
            this.setViewModel = setViewModel;
            OpenCreateCategoryWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCategoryWindow()));
            OpenExamModeWindowCommand = new RelayCommand(() => OpenWindow(new OpenExamModeWindow()));
            OpenStatisticsWindowCommand = new RelayCommand(() => OpenWindow(new OpenStatisticsWindow()));
            OpenExportWindowCommand = new RelayCommand(() => OpenWindow(new OpenExportWindow()));
            OpenLernmodusWindowCommand = new RelayCommand(() => OpenWindow(new OpenLernmodusWindow()));
            OpenViewCategoryWindowCommand = new RelayCommand(() => OpenViewCategoryWindowFunc(new OpenViewCategoryWindow()));

            RemoveCategoryCommand = new RelayCommand(this.removeCategoryfunction, this.getBoolean);
            NumberOfCategories = "                                   " + categories.Count() + " Kategorien";
        }
        
        private bool getBoolean()
        {
            return true; 
        }

        private void removeCategoryfunction()
        {
            Console.WriteLine("removed");
            categories.Remove(SelectedCategory); 
        }

        private void OpenWindow<TNotification>(TNotification notification)
        {

         
            ServiceBus.Instance.Send(notification);
         
        }

        


        private void OpenViewCategoryWindowFunc<TNotification>(TNotification ViewCategoryWindow)
        {
            if (SelectedCategory != null)
            {
                ViewCategoryViewModel.NumberOFCards = "                                   " + SelectedCategory.NumberOfCards + " Karten in " + SelectedCategory.Name;
                ViewCategoryViewModel.NameOfCategory = SelectedCategory.Name;
                ServiceBus.Instance.Send(ViewCategoryWindow);
            }
          
        }
        public ICommand getRemoveCategoryCommand
        {
            get
            {
               
                return RemoveCategoryCommand; 
            }
        }


        
        /*    public ICommand TestMethode
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
