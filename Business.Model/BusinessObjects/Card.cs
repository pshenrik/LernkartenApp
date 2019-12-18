using System;
﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Card : BusinessObject
    {
        private string name;
        private bool marked;
        public Card (string name)
        {
            this.name = name;
            Front = new CardPage();
            Back = new CardPage();

            
        }
        public Card()
        {
           
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

        

        //Die Karte guckt selber, ob eine Antwort mit den Keywords übereinstimmt.
        public bool CheckAnswer(String answer)
        {
            return true;
        }


    }
}
