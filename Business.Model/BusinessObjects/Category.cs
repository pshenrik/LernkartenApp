using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Category : BusinessObject
    {
        //Max 5 collections
        public CardCollection[] Collections;

        public int NumberOfCards
        {
            get
            {
                return Collections[0].Count + Collections[1].Count + Collections[2].Count + Collections[3].Count + Collections[4].Count;
            } 
        }


        public String Name { get; set; }

        public Category(String name)
        {
            this.Name = name;
            this.Collections = new CardCollection[5];

        }

       
    }
}
