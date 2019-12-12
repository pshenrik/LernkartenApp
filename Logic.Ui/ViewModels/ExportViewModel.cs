﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    class ExportViewModel : AbstractViewModel
    {
        private Category category;
            
        public ExportViewModel(Category category)
        {
            this.category = category;
        }
    }
}
