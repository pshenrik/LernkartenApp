﻿
using System;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    class CategoryWrapper
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
