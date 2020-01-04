using System;
﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Card : BusinessObject
    {
        private string name;

        #region Properties
        public CardPage Front { get; }
        public CardPage Back { get; }
        public CardInfo Info { get; set; }

      
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        #endregion


        public Card (string name)
        {
            this.name = name;
            Front = new CardPage();
            Back = new CardPage();
            Info = new CardInfo();


        }
        public Card()
        {
           
            Front = new CardPage();
            Back = new CardPage();
            Info = new CardInfo();


        }
        

        //Die Karte guckt selber, ob eine Antwort mit den Keywords übereinstimmt.
        public bool CheckAnswer(String answer)
        {
            return true;
        }


    }
}
