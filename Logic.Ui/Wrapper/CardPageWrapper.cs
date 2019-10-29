using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    class CardPageWrapper
    {
        public CardPage page;

        public String Text
        {
            get
            {
                return page.Text;
            }
            set
            {
                page.Text = value;
            }
        }


    }
}
