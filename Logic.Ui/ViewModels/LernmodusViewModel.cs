﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class LernmodusViewModel
    {
        private CategoryViewModel category;
        public LernmodusViewModel(CategoryViewModel category)
        {
            this.category = category;
            CardViewModel card = new CardViewModel();
        }

        public int CardsLearned { get; set; }

        private CardViewModel currentCard;
        public CardViewModel CurrentCard {
            get
            {
                return currentCard;
            }
                
        }

    }


}
