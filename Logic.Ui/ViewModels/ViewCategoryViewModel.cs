using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Messages;
using De.HsFlensburg.LernkartenApp001.Services.ServiceBus;
using System.Windows.Input;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ViewCategoryViewModel: AbstractViewModel
    {
       
           #region Ohne Static 
            /*
              public SetViewModel Categories { get; set; }
               private  CategoryViewModel Category;
               public String NameOfCategory { get; set; }
               public String NumberOfCards { get; set; }
               public RelayCommand OpenCreateCardWindowCommand { get; }
               public CardViewModel SelectedCard { get; set; }
               private ICommand RemoveCardCommand;
               public ObservableCollection<CardViewModel> Cards { get; set; }

               public ViewCategoryViewModel(CategoryViewModel category)
               {

                this.Category = category;

                   this.NameOfCategory = this.Category.Name;
                   this.NumberOfCards = "                                   " + this.Category.NumberOfCards + " Karten in " + this.Category.Name;
                   OpenCreateCardWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCardWindow()));
                   RemoveCardCommand = new RelayCommand(this.RemoveCardFunction, this.GetBoolean);

                   this.Cards = new ObservableCollection<CardViewModel>();

                   for (var i = 0; i < this.Category.Collections.Length; i++)
                   {
                       for (var j = 0; j < this.Category.Collections[i].Count; j++)
                       {
                           this.Cards.Add(this.Category.Collections[i][j]);
                           Console.WriteLine(this.Cards[i].Name);

                       }
                   }


                  Console.WriteLine("FAAAAT"); 
               }

               public ViewCategoryViewModel(SetViewModel setViewModel)
               {
                   this.Categories = setViewModel;


               }



               private void OpenWindow<TNotification>(TNotification notification)
               {


                   ServiceBus.Instance.Send(notification);
               }


               private bool GetBoolean()
               {
                   return true;
               }

               public ICommand getRemoveCardCommand
               {
                   get
                   {

                       return RemoveCardCommand;
                   }
               }
               public void RemoveCardFunction()
               {

                   if (Cards.Contains(SelectedCard))
                   {
                       Cards.Remove(SelectedCard);
                   }
               }

               */
            #endregion
            //******************************************************************************************************************************************



        public static ObservableCollection<CardViewModel> Cards;


        private static CategoryViewModel selectedCategoryInMainMenu;
        public String SearchedCard { get; set; }
        public RelayCommand OpenCreateCardWindowCommand { get; }
        public CardViewModel SelectedCard { get; set; }
        public ICommand FindCardCommand { get; }
        private ICommand RemoveCardCommand;
        public static string NameOfCategory { get; set; }

        private static String numberOfCards;
        public static String NumberOfCards { get { return numberOfCards; } set { numberOfCards = value; } }


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

                   CardsSorting(this.selctedComboBoxItem);
               }
           }

      

        public SetViewModel setViewModel;
        public ViewCategoryViewModel(SetViewModel setViewModel)
        {
            this.setViewModel = setViewModel;

            OpenCreateCardWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCardWindow()));
            RemoveCardCommand = new RelayCommand(this.RemoveCardFunction, this.getBoolean);
            FindCardCommand = new RelayCommand(this.FindCardFunction, this.getBoolean);
        }

        public ViewCategoryViewModel()
        {
            OpenCreateCardWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCardWindow()));
            RemoveCardCommand = new RelayCommand(this.RemoveCardFunction, this.getBoolean);
            FindCardCommand = new RelayCommand(this.FindCardFunction, this.getBoolean);

        }
          private void CardsSorting(String selectedType)
          {
              //TODO: SelctedType bekommt keinen Wert: Die Elemente von ComboBox sollen gelesen werden!


              if (selectedType == "Name")
              {
                  var sortableList = Cards.OrderBy(category => category.Name).ToList();

                  Cards.Clear();
                  foreach (var item in sortableList)
                  {
                      Cards.Add(item);
                  }
              }
              else if (selectedType == "Datum")
              {
                  var sortableList = Cards.OrderBy(category => Convert.ToDateTime(category.Info.CreatedTime)).ToList();

                  Cards.Clear();
                  foreach (var item in sortableList)
                  {
                      Cards.Add(item);
                  }
              }
              else
              {

              }
          }
        private void FindCardFunction()
        {
            if (this.SearchedCard != "")
            {
                bool isFound = false;
                for (var i = 0; i < Cards.Count && !isFound; i++)
                {
                    if (Cards[i].Name == this.SearchedCard)
                    {
                        isFound = true;
                        Cards.Move(i, 0);
                        NotFoundMessage = "";
                    }
                    else
                    {
                        NotFoundMessage = "Die gesuchte Karte konnte nicht gefunden werden";
                    }
                }
            }

        }

        public static CategoryViewModel SelectedCategoryInMainMenu
        {

            get
            {
                return selectedCategoryInMainMenu;
            }

            set
            {
                selectedCategoryInMainMenu = value;

                NameOfCategory = selectedCategoryInMainMenu.Name;
                NumberOfCards = "                                   " + selectedCategoryInMainMenu.NumberOfCards + " Karten in " + selectedCategoryInMainMenu.Name;
                Cards = new ObservableCollection<CardViewModel>();

                for (var i = 0; i < selectedCategoryInMainMenu.Collections.Length; i++)
                {
                    for (var j = 0; j < selectedCategoryInMainMenu.Collections[i].Count; j++)
                    {
                        Cards.Add(selectedCategoryInMainMenu.Collections[i][j]);
                        Console.WriteLine(Cards[i].Info.CreatedTime);
                    }
                }

            }
        }

        private void OpenWindow<TNotification>(TNotification notification)
        {


            ServiceBus.Instance.Send(notification);
        }


        private bool getBoolean()
        {
            return true;
        }

        public ICommand GetRemoveCardCommand
        {
            get
            {

                return RemoveCardCommand;
            }
        }
        public void RemoveCardFunction()
        {
            if (SelectedCard != null)
            {
                Console.WriteLine(SelectedCard.Name);


                if (Cards.Contains(SelectedCard))
                {
                    Cards.Remove(SelectedCard);
                    // NumberOfCards = "                                   " + selectedCategoryInMainMenu.NumberOfCards + " Karten in " + selectedCategoryInMainMenu.Name;
                }
            }
        }
    }
}


