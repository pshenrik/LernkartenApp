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
        public static IEnumerable<CardViewModel> getCardsOfCategory()
        {
            List<CardViewModel> listOfCards = new List<CardViewModel>();

            listOfCards.Add(new CardViewModel("Card1") { Name = "A" });
            listOfCards.Add(new CardViewModel("Card2") { Name = "B" });
            listOfCards.Add(new CardViewModel("Card3") { Name = "C" });
            listOfCards.Add(new CardViewModel("Card4") { Name = "D" });
            listOfCards.Add(new CardViewModel("Card5") { Name = "E" });
            return listOfCards;
        }


        public static ObservableCollection<CardViewModel> cards = new ObservableCollection<CardViewModel>(getCardsOfCategory());
        public CardViewModel SelectedCard { get; set; }
        private ICommand RemoveCardCommand;


        public RelayCommand OpenCreateCardWindowCommand { get; }
      
        //   testMethodVar = new RelayCommand(this.Test, this.getTrue);
            

            public ViewCategoryViewModel()
        {
            OpenCreateCardWindowCommand = new RelayCommand(() => OpenWindow(new OpenCreateCardWindow()));
            RemoveCardCommand = new RelayCommand(this.RemoveCardFunction, this.getBoolean); 
        }

        private void OpenWindow<TNotification>(TNotification notification)
        {
            ServiceBus.Instance.Send(notification);
        }


        private bool getBoolean()
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
            if (cards.Contains(SelectedCard)){
                cards.Remove(SelectedCard);
            }
        }













        /*  public static ObservableCollection<CardViewModel> cardColl;
        public ViewCategoryViewModel(CardCollectionViewModel cards)
        {
            cardColl = new ObservableCollection<CardViewModel>(cards);

        }
        public ViewCategoryViewModel()
        {

        }
        public String NumberOfCards
        {
            get
            {
                return cardColl.Count + " sind vorhanden";
            }
        }

        // HilfesFunktin zum Suchen nach einem Name einer Karte einer Katogrie 
        public string getCardName(String name)
        {

            return null;
        }

        public void NameSort()
        {

        }

        public void DateSort()
        {

        }
        */


    }
}

