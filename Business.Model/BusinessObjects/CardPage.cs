using System;
using System.ComponentModel;
namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class CardPage : INotifyPropertyChanged
    {   
        public String Text { get; set; }
        public String ImageSource { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
