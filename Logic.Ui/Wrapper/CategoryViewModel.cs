
using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CategoryViewModel
    {
        private Category category;
        public String Name
        {
            get
            {
                return category.Name;
            }
            set
            {
                category.Name = value;
            }
        }
    }
}
