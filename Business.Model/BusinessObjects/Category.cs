﻿using System.ComponentModel;
using System;
namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Category : INotifyPropertyChanged
    {
        //Max 5 collections
        public CardCollection[] collections;

        public String Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
