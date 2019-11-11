using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    class CardPageWrapper
    {

        public CardPageWrapper()
        {
            page = new CardPage();
        }
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

        public String ImageSourece
        {
            get
            {
               return page.ImageSource;
            }
            set
            {
                page.ImageSource = value;
            }
        }
    }
}
