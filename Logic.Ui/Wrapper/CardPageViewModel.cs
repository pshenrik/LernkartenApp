using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardPageViewModel : AbstractViewModel
    {
        private CardPage page;
        public CardPageViewModel()
        {
            this.page = new CardPage();
        }
        
        public CardPageViewModel (CardPage page)
        {
            this.page = page;
        }

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
