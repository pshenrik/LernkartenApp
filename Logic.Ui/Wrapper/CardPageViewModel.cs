using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardPageWrapper : AbstractViewModel
    {

        public CardPageWrapper()
        {
            page = new CardPage();
        }
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
