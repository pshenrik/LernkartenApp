using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardWrapper
    {
        private Card card;
        
        public String Name
        {
            get
            {
                return card.Name;
            }

            set
            {
                card.Name = value;
                //  OnPropertyChanged();
            }
        }

        public CardPage Front
        {
            get
            {
                return card.Front;
            }
        }

        public CardPage Back
        {
            get
            {
                return card.Back;
            }
        }
    }
}
