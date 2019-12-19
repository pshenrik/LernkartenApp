﻿using System;
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
        
      
       
      
      
        private ICommand RemoveCategoryCommand { get; }
        public RelayCommand OpenCreateCategoryWindowCommand { get; }
        public RelayCommand OpenExamModeWindowCommand { get; }
        public RelayCommand OpenStatisticsWindowCommand { get; }
        public RelayCommand OpenExportWindowCommand { get; }
        public RelayCommand OpenLernmodusWindowCommand { get; }
        public RelayCommand OpenViewCategoryWindowCommand { get;  }

        public CategoryViewModel SelectedCategory { get; set; }


        private string selctedComboBoxItem;
        public String SelectedcomboBoxItem
        {
            get {
                return this.selctedComboBoxItem; 
            
            }
            set
            {
               // string[] words = this.selctedComboBoxItem.Split(':'); 

               // Console.WriteLine(words.Length); 
                Console.WriteLine(this.selctedComboBoxItem); 
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


        public SetViewModel categories { get; set; } 
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
           
            this.categories = setViewModel;
            
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
            if (SelectedCategory != null)
            {


                Console.WriteLine(SelectedCategory.Name);
                categories.Remove(SelectedCategory);
                NumberOfCategories = "                                   " + categories.Count + " Kategorien";
                SelectedCategory = null;
            }
        }

        private void OpenWindow<TNotification>(TNotification notification)
        {

         
            ServiceBus.Instance.Send(notification);
         
        }

        private void setNumberOfCards()
        {

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
