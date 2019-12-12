using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardPageViewModel
    {
        private CardPage page;

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
