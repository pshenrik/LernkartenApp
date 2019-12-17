using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardViewModel : AbstractViewModel
    {
        internal Card Card { get; set; }

        public CardPageViewModel FrontVM;
        public CardPageViewModel BackVM;
        
        public CardViewModel(Card card)
        {
            this.Card = card;
        }
        public CardViewModel(string name)
        {
            this.Card = new Card(name);
            this.FrontVM = new CardPageViewModel(this.Card.Front);
            this.BackVM = new CardPageViewModel(this.Card.Back);
        }


        public String Name
        {
            get
            {
                return Card.Name;
            }

            set
            {
                Card.Name = value;
                OnPropertyChanged();
            }
        }

        public CardPage Front
        {
            get
            {
                return FrontVM.Page;
            }
        }

        public CardPage Back
        {
            get
            {
                return BackVM.Page;
            }
        }

        public bool Marked
        {
            get
            {
                return Card.Marked;
            }

            set
            {
                Card.Marked = value;
            }
        }
    }
}
