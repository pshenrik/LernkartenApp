﻿
using System;
namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Category
    {
        //Max 5 collections
        public CardCollection[] collections
        {
            get; set;
        }


        public String Name { get; set; }
        public int NumberOfCards { get; set;}
    }
}
