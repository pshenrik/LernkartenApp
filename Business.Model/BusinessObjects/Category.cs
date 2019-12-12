using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Category : INotifyPropertyChanged
    {
        //Max 5 collections
        public CardCollection[] Collections { get; set; }

        public int NumberOfCards { get; set;}

        public String Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
