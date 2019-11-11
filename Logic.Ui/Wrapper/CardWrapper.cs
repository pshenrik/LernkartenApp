using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    class CardWrapper
    {

        public CardWrapper()
        {
            card = new Card();
        }
        public Card card;

        public CardPage Front
        {
            get
            {
                return card.Front;
            }

            set
            {
                card.Front = value;
               // OnPropertyChanged();
            }
        }

        public CardPage Back
        {
            get
            {
                return card.Back;
            }

            set
            {
                card.Back = value;
                // OnPropertyChanged();
            }
        }
    }
}
