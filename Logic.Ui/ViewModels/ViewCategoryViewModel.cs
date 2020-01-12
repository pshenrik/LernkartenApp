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
       
    /*       #region Ohne Static 
            
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

               
            #endregion
        */
            //******************************************************************************************************************************************


            
        public static ObservableCollection<CardViewModel> Cards;


        private static CategoryViewModel selectedCategoryInMainMenu;

        private String searchedCard; 
        public String SearchedCard { get { return this.searchedCard;  }
                set{
                this.searchedCard = value;
                this.FindCardFunction(this.searchedCard); 
                } }
        public RelayCommand OpenCreateCardWindowCommand { get; }
        public RelayCommand OpenEditCardWindowCommand { get; }
        public CardViewModel SelectedCard { get; set; }
 
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


        public String[] ComboboxItemslist { get; set; }
        public SetViewModel setViewModel;
        public ViewCategoryViewModel(SetViewModel setViewModel)
        {
            this.setViewModel = setViewModel;

            OpenCreateCardWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCardWindow()));
            OpenEditCardWindowCommand = new RelayCommand(() => OpenOpenEditCardWindowFunction(new OpenEditCardWindow())); 
            RemoveCardCommand = new RelayCommand(this.RemoveCardFunction, this.getBoolean);
           this.ComboboxItemslist = new String[2];
            this.ComboboxItemslist[0] = "Name";
            this.ComboboxItemslist[1] = "Datum"; 
        }

        private void OpenOpenEditCardWindowFunction(OpenEditCardWindow openEditCardWindow)
        {
            NotFoundMessage = "";
            if (this.SelectedCard != null)
            {
                EditCardViewModel.Card = this.SelectedCard; 
                ServiceBus.Instance.Send(openEditCardWindow);
            }
            
            
        }

        public ViewCategoryViewModel()
        {
            OpenCreateCardWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCardWindow()));
            RemoveCardCommand = new RelayCommand(this.RemoveCardFunction, this.getBoolean);
        
        }
          private void CardsSorting(String selectedType)
        {
            NotFoundMessage = "";
            if (selectedType == "Name")
              {
                  var sortableList = Cards.OrderBy(card => card.Name).ToList();

                  Cards.Clear();
                  foreach (var item in sortableList)
                  {
                      Cards.Add(item);
                  }
              }
              else 
              {
                  var sortableList = Cards.OrderBy(category =>category.Info.CreatedTime).ToList();

                  Cards.Clear();
                  foreach (var item in sortableList)
                  {
                      Cards.Add(item);
                  }
              }



        }
        private void FindCardFunction(String searchedCard)
        {
            if (!String.IsNullOrEmpty(searchedCard))
            {

                List<CardViewModel> list;
                searchedCard = searchedCard.ToLower(); 
                list = Cards.Where(card => card.Name.ToLower().Contains(searchedCard)).ToList();
                if (list.Count > 0)
                {
                    this.NotFoundMessage = ""; 
                    for(int i =0; i< list.Count; i++)
                    {
                        Cards.Move(Cards.IndexOf(list[i]), i); 
                    }
                }
                else
                {
                    this.NotFoundMessage = "Nicht gefunden!"; 
                }
            }
            else
            {
                
                this.NotFoundMessage = "";
                this.CardsSorting("Name"); 
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
            NotFoundMessage = "";

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
            NotFoundMessage = "";
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


