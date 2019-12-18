using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ViewMarkedCardsViewModel : AbstractViewModel
    {
        public SetViewModel Set;
        public ViewMarkedCardsViewModel(SetViewModel set)
        {
            this.Set = set;
        }
        public ViewMarkedCardsViewModel()
        {

        }
    }
}
