using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ExportViewModel : AbstractViewModel
    {
        private CategoryViewModel category;
            
        public ExportViewModel(CategoryViewModel category)
        {
            this.category = category;
            
        }


    }
}
