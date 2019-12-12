using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardWrapper : AbstractViewModel
    {
        internal Card Card { get; set; }
        

        public CardWrapper (Card card)
        {
            this.Card = card;
        }
        public CardWrapper (string name)
        {
            this.Card = new Card(name);
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
                return Card.Front;
            }
        }

        public CardPage Back
        {
            get
            {
                return Card.Back;
            }
        }
    }
}
