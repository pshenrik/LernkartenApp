using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardPageViewModel : AbstractViewModel
    {
        private CardPage page;
        public CardPage Page
        {
            get
            {
                return this.page;
            }
        }
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
                OnPropertyChanged();
            }
        }

        public BitmapSource Image
        {
            get
            {
               return page.Image;
            }
            set
            {
                page.Image = value;
                OnPropertyChanged();
            }
        }
    }
}
