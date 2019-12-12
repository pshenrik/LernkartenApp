﻿using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardViewModel
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
