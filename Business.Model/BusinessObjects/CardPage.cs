using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class CardPage : INotifyPropertyChanged
    {   
        public String Text { get; set; }
        public String ImageSource { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
