﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CategoryViewModel : AbstractViewModel
    {
        public Category category;
        public CardCollectionViewModel[] Collections { get; set; }
        

        public CategoryViewModel()
        {
            this.category = new Category("");
            this.Collections = new CardCollectionViewModel[5];
            Collections[0] = new CardCollectionViewModel(category.Collections[0]);
            Collections[1] = new CardCollectionViewModel(category.Collections[1]);
            Collections[2] = new CardCollectionViewModel(category.Collections[2]);
            Collections[3] = new CardCollectionViewModel(category.Collections[3]);
            Collections[4] = new CardCollectionViewModel(category.Collections[4]);


        }

        public CategoryViewModel(String name)
        {
            this.category = new Category(name);
            this.Collections = new CardCollectionViewModel[5];
            Collections[0] = new CardCollectionViewModel(category.Collections[0]);
            Collections[1] = new CardCollectionViewModel(category.Collections[1]);
            Collections[2] = new CardCollectionViewModel(category.Collections[2]);
            Collections[3] = new CardCollectionViewModel(category.Collections[3]);
            Collections[4] = new CardCollectionViewModel(category.Collections[4]);

        }
        public CategoryViewModel( Category cat)
        {
            this.category = cat;
            this.Collections = new CardCollectionViewModel[5];
            Collections[0] = new CardCollectionViewModel(category.Collections[0]);
            Collections[1] = new CardCollectionViewModel(category.Collections[1]);
            Collections[2] = new CardCollectionViewModel(category.Collections[2]);
            Collections[3] = new CardCollectionViewModel(category.Collections[3]);
            Collections[4] = new CardCollectionViewModel(category.Collections[4]);

        }
        
        public String Name
        {
            get
            {
                
                
                return this.category.Name;
            }
            set
            {
                this.category.Name = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfCards
        {
            get
            {
                return category.NumberOfCards;
            }
        }

      //  public static ObservableCollection<Category> categorys = new ObservableCollection<Category>(); 
    }
}
