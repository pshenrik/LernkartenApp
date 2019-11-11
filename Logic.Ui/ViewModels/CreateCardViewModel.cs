using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
   public class CreateCardViewModel
    {
        CardPageWrapper cardPage=new CardPageWrapper();
        CardWrapper card;

        public CreateCardViewModel()
        {
            card = new CardWrapper();
            card.Front = cardPage.page;
        }
    }
}
