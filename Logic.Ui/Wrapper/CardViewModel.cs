using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardViewModel : AbstractViewModel
    {
        internal Card Card { get; set; }

        private CardPageViewModel FrontVM;
        private CardPageViewModel BackVM;
        
        public CardViewModel(Card card)
        {
            this.Card = card;
            this.FrontVM = new CardPageViewModel(this.Card.Front);
            this.BackVM = new CardPageViewModel(this.Card.Back);
        }
        public CardViewModel(string name)
        {
            this.Card = new Card(name);
            this.FrontVM = new CardPageViewModel(this.Card.Front);
            this.BackVM = new CardPageViewModel(this.Card.Back);
        }
        public CardViewModel()
        {
            this.Card = new Card();
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

        public CardPageViewModel Front
        {
            get
            {
                return FrontVM;
            }
        }

        public CardPageViewModel Back
        {
            get
            {
                return BackVM;
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
