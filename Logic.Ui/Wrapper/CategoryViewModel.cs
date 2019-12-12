
using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CategoryWrapper : AbstractViewModel
    {
        public CategoryWrapper()
        {
            category = new Category();
        }

        public Category category;
        public String Name
        {
            get
            {
                return category.Name;
            }
            set
            {
                category.Name = value;
                //OnPropertyChanged();
            }
        }
    }
}
