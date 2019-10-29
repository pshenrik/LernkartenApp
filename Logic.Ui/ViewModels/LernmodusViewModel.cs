using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    class LernmodusViewModel
    {
        private Category category;
        public LernmodusViewModel(Category category)
        {
            this.category = category;
        }

    }


}
