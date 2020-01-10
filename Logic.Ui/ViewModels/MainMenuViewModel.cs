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


        public ICommand FindCategoryCommand { get; }
        private ICommand RemoveCategoryCommand { get; }
        public ICommand ChangingNameOfCategoryCommand { get; }
        public RelayCommand OpenCreateCategoryWindowCommand { get; }
        public RelayCommand OpenExamModeWindowCommand { get; }
        public RelayCommand OpenStatisticsWindowCommand { get; }
        public RelayCommand OpenExportWindowCommand { get; }
        public RelayCommand OpenLernmodusWindowCommand { get; }
        public RelayCommand OpenViewCategoryWindowCommand { get; }
        public RelayCommand OpenViewMarkedCardsWindowCommand { get; }
        public RelayCommand OpenImportWindowCommand { get; }
        
        public CategoryViewModel SelectedCategory { get; set; }
        public String SearchedCategory { get; set; }
        public String InsertedNewNameForCategory { get; set; }
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
    
        public String[] ComboboxItemslist { get; set; }
        public SetViewModel Categories { get; set; } 
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
            OpenImportWindowCommand = new RelayCommand(()=> OpenWindow(new OpenImportWindow())); 
            FindCategoryCommand = new RelayCommand(this.FindCategoryfunction, this.GetBoolean);
            RemoveCategoryCommand = new RelayCommand(this.RemoveCategoryfunction, this.GetBoolean);
            ChangingNameOfCategoryCommand = new RelayCommand(this.ChangingNameOfCategoryFunction, this.GetBoolean); 
            NumberOfCategories = "                                   " + Categories.Count() + " Kategorien";

            ComboboxItemslist = new String[3];
            ComboboxItemslist[0] = "Name";
            ComboboxItemslist[1] = "Datum";
            ComboboxItemslist[2] = "Anzahl der Karten";
         
        }

        private void ChangingNameOfCategoryFunction()
        {
            if(this.SelectedCategory != null)

            {
                if(this.InsertedNewNameForCategory != null)
                {
this.SelectedCategory.Name = this.InsertedNewNameForCategory;
                    this.NotFoundMessage = ""; 
                }
                else
                {
                    this.NotFoundMessage = "Bitte geben Sie einen Namen ein"; 
                }
                
            }
        }

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
            ComboboxItemslist = new String[3];
            ComboboxItemslist[0] = "Name";
            ComboboxItemslist[1] = "Datum";
            ComboboxItemslist[2] = "Anzahl der Karten";


        }


     

        // Funktion, durch die das Collection nach Name, Datum oder Anzahle der Karten sortiert werden kann. 
        private void CollectoinSorting(String selectedType)
        {

            this.NotFoundMessage = ""; 

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
                 var sortableList = this.Categories.OrderBy(category => category.NumberOfCards).ToList();

                  this.Categories.Clear();
                foreach (var item in sortableList)
                {
                    this.Categories.Add(item);
                }
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
            this.NotFoundMessage = "";
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
            this.NotFoundMessage = "";

            ServiceBus.Instance.Send(notification);

        }



        private void OpenViewCategoryWindowFunc<TNotification>(TNotification ViewCategoryWindow)
        {
            this.NotFoundMessage = "";
            if (SelectedCategory != null)
            {
                
                 
              //  this.SelectedCategory.IsSelected = true; 
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
