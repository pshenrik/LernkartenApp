using System;
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
            for(int i = 0; i < 5; i++)
            {
                Collections[i] = new CardCollectionViewModel(category.Collections[i]);
            }


        }

        public CategoryViewModel(String name)
        {
            this.category = new Category(name);
            this.Collections = new CardCollectionViewModel[5];
            for (int i = 0; i < 5; i++)
            {
                Collections[i] = new CardCollectionViewModel(category.Collections[i]);
            }

        }
        public CategoryViewModel( Category cat)
        {
            this.category = cat;
            this.Collections = new CardCollectionViewModel[5];
            for (int i = 0; i < 5; i++)
            {
                Collections[i] = new CardCollectionViewModel(category.Collections[i]);
            }

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





        /*     public long CreatedTime
             {
                 get
                 {
                     return category.CreatedTime;
                 }
             }*/

          public String CreatedTime
    {
        get
        {
            return category.CreatedTime;
        }
            set
            {
                this.category.CreatedTime = value; 
            }
    }
        public int NumberOfCards
        {
            get
            {
                return category.NumberOfCards;
            }
            set
            {
                this.category.NumberOfCards = value; 
            }
        }

      //  public static ObservableCollection<Category> categorys = new ObservableCollection<Category>(); 
    }
}
