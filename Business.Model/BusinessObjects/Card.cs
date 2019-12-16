using System;
﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Card : INotifyPropertyChanged
    {
        private string name;
        private bool marked;
        public Card (string name)
        {
            this.name = name;
            Front = new CardPage();
            Back = new CardPage();

            
        }
        public CardPage Front { get; }
        public CardPage Back { get; }

        
        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Gibt an ob eine Karte makiert wurde
        public bool Marked {
            get
            {
                return marked;
            }
            set
            {
                marked = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Die Karte guckt selber, ob eine Antwort mit den Keywords übereinstimmt.
        public bool CheckAnswer(String answer)
        {
            return true;
        }


    }
}
