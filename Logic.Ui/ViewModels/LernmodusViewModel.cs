using System;
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
        private Category category;
        public LernmodusViewModel(Category category)
        {
            this.category = category;
        }

        public int CardsLearned { get; set; }

        //private CardWrapper currentCard;
        //public CardWrapper CurrentCard {
        //    get
        //    {
        //        return currentCard;
        //    }
                
        //}

    }


}
