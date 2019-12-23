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


        public ICommand FindCategoryCommand { get; }
        private ICommand RemoveCategoryCommand { get; }
        public RelayCommand OpenCreateCategoryWindowCommand { get; }
        public RelayCommand OpenExamModeWindowCommand { get; }
        public RelayCommand OpenStatisticsWindowCommand { get; }
        public RelayCommand OpenExportWindowCommand { get; }
        public RelayCommand OpenLernmodusWindowCommand { get; }
        public RelayCommand OpenViewCategoryWindowCommand { get; }
        public RelayCommand OpenViewMarkedCardsWindowCommand { get; }
        public CategoryViewModel SelectedCategory { get; set; }
        public String SearchedCategory { get; set; }

        private String notFoundMessage;
        public String NotFoundMessage
        {
            get
            {
                return this.notFoundMessage;
            }
            set
            {
                this.notFoundMessage = value;
                OnPropertyChanged();
            }
        }
        private String selctedComboBoxItem;
        public String SelectedcomboBoxItem
        {
            get
            {
                return this.selctedComboBoxItem;

            }
            set
            {
                this.selctedComboBoxItem = value;
                // selctedComboBoxItem = " :name";

                CollectoinSorting(this.selctedComboBoxItem);
            }
        }

        private string numberOfCategories;
        public String NumberOfCategories
        {
            get
            {
                return this.numberOfCategories;
            }

            set
            {
                this.numberOfCategories = value;
                OnPropertyChanged();
            }

        }
        public SetViewModel Categories { get; set; }
        public MainMenuViewModel()
        {

            //   testMethodVar = new RelayCommand(this.Test, this.getTrue);
            OpenCreateCategoryWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCategoryWindow()));
            OpenExamModeWindowCommand = new RelayCommand(() => OpenWindow(new OpenExamModeWindow()));
            OpenStatisticsWindowCommand = new RelayCommand(() => OpenWindow(new OpenStatisticsWindow()));
            OpenExportWindowCommand = new RelayCommand(() => OpenWindow(new OpenExportWindow()));
            OpenLernmodusWindowCommand = new RelayCommand(() => OpenWindow(new OpenLernmodusWindow()));
            OpenViewCategoryWindowCommand = new RelayCommand(() => OpenViewCategoryWindowFunc(new OpenViewCategoryWindow()));
            OpenViewMarkedCardsWindowCommand = new RelayCommand(() => OpenWindow(new OpenViewMarkedCardsWindow()));
            FindCategoryCommand = new RelayCommand(this.FindCategoryfunction, this.GetBoolean);
            RemoveCategoryCommand = new RelayCommand(this.RemoveCategoryfunction, this.GetBoolean);

            NumberOfCategories = "                                   " + Categories.Count() + " Kategorien";


        }


        public MainMenuViewModel(SetViewModel setViewModel)
        {


            this.Categories = setViewModel;

            OpenCreateCategoryWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCategoryWindow()));
            OpenExamModeWindowCommand = new RelayCommand(() => OpenWindow(new OpenExamModeWindow()));
            OpenStatisticsWindowCommand = new RelayCommand(() => OpenWindow(new OpenStatisticsWindow()));
            OpenExportWindowCommand = new RelayCommand(() => OpenWindow(new OpenExportWindow()));
            OpenLernmodusWindowCommand = new RelayCommand(() => OpenWindow(new OpenLernmodusWindow()));
            OpenViewCategoryWindowCommand = new RelayCommand(() => OpenViewCategoryWindowFunc(new OpenViewCategoryWindow()));
            OpenViewMarkedCardsWindowCommand = new RelayCommand(() => OpenWindow(new OpenViewMarkedCardsWindow()));
            FindCategoryCommand = new RelayCommand(this.FindCategoryfunction, this.GetBoolean);
            RemoveCategoryCommand = new RelayCommand(this.RemoveCategoryfunction, this.GetBoolean);
            NumberOfCategories = "                                   " + Categories.Count() + " Kategorien";

        }


        // Funktion, durch die das Collection nach Name, Datum oder Anzahle der Karten sortiert werden kann. 
        private void CollectoinSorting(String selectedType)
        {
            //TODO: SelctedType bekommt keinen Wert: Die Elemente von ComboBox sollen gelesen werden!


            if (selectedType == "Name")
            {
                var sortableList = this.Categories.OrderBy(category => category.Name).ToList();

                this.Categories.Clear();
                foreach (var item in sortableList)
                {
                    this.Categories.Add(item);
                }
            }
            else if (selectedType == "Datum")
            {
                var sortableList = this.Categories.OrderBy(category => Convert.ToDateTime(category.CreatedTime).Ticks).ToList();

                this.Categories.Clear();
                foreach (var item in sortableList)
                {
                    this.Categories.Add(item);
                }
            }
            else
            {
                /*  var sortableList = this.categories.OrderBy(category => category.NumberOfCards).ToList();

                  this.categories.Clear();
                  foreach (var item in sortableList)
                  {
                      this.categories.Add(item);
                  }*/


            }
        }
        private void FindCategoryfunction()
        {
            if (this.SearchedCategory != "")
            {
                bool isFound = false;

                for (var i = 0; i < this.Categories.Count && !isFound; i++)
                {
                    if (this.Categories[i].Name == this.SearchedCategory)
                    {
                        isFound = true;
                        this.Categories.Move(i, 0);

                        NotFoundMessage = "";
                    }
                    else
                    {
                        NotFoundMessage = "Die gesuchte Kategorie konnte nicht gefunden werden";
                    }
                }
            }
        }


        private bool GetBoolean()
        {
            return true;
        }

        private void RemoveCategoryfunction()
        {
            if (SelectedCategory != null)
            {


                Console.WriteLine(SelectedCategory.Name);
                Categories.Remove(SelectedCategory);
                NumberOfCategories = "                                   " + Categories.Count + " Kategorien";
                SelectedCategory = null;
            }
        }

        private void OpenWindow<TNotification>(TNotification notification)
        {


            ServiceBus.Instance.Send(notification);

        }



        private void OpenViewCategoryWindowFunc<TNotification>(TNotification ViewCategoryWindow)
        {

            if (SelectedCategory != null)
            {


                ViewCategoryViewModel.SelectedCategoryInMainMenu = this.SelectedCategory;
                // new ViewCategoryViewModel( this.SelectedCategory); 
                ServiceBus.Instance.Send(ViewCategoryWindow);
            }

        }
        public ICommand GetRemoveCategoryCommand
        {
            get
            {

                return RemoveCategoryCommand;
            }
        }



    }
}
