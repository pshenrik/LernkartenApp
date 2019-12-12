using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class CategoryViewModel
    {

        public static ObservableCollection<CardWrapper> cardColl; 
        public CategoryViewModel(CardCollectionWrapper cards)
        {
            cardColl = new ObservableCollection<CardWrapper>(cards);
           
        }
       public CategoryViewModel()
        {

        }
        public String NumberOfCards
        {
            get
            {
                return cardColl.Count + " sind vorhanden"; 
            }
        }

        // HilfesFunktin zum Suchen nach einem Name einer Karte einer Katogrie 
        public string getCardName(String name)
        {

            return null; 
        }

        public void NameSort()
        {

        }

        public void DateSort()
        {

        }
    
    
        
    }
}
