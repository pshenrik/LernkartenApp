using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Category : BusinessObject
    {
        //Max 5 collections
        public CardCollection[] Collections { get; set; }

        public int NumberOfCards { get; set;}

        public String Name { get; set; }

       
    }
}
