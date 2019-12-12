
using System;
namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Card
    {
        public CardPage Front { get; set; }
        public CardPage Back { get; set; }
        public String Name { get; set; }

        public Card()
        {
            Front = new CardPage();
            Back = new CardPage();
        }
    }
}
