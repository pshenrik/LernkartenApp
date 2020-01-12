using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Card : BusinessObject
    {
        private string name;
        private ObservableCollection<String> keywords;

        #region Properties
        public CardPage Front { get; }
        public CardPage Back { get; }
        public CardInfo Info { get; set; }
        public ObservableCollection<String> Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
                
            }
        }

      
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
            Keywords = new ObservableCollection<string>();

        }
        public Card()
        {
           
            Front = new CardPage();
            Back = new CardPage();
            Info = new CardInfo();
            Keywords = new ObservableCollection<string>();

        }
        

        //Die Karte guckt selber, ob eine Antwort mit den Keywords übereinstimmt.
        public bool CheckAnswer(String answer)
        {
            if(answer == null)
            {
                return false;
            }
            string input = answer.ToLower();
            string[] words = input.Split(' ');

            //Wenn die Eingabe 100% mit der Antwort übereinstimmt
            if (input.Equals(Back.Text))
            {
                return true;
            }

            //Ansonsten alle Wörter nach den Keywords absuchen
            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                for(int j = 0; j < keywords.Count; j++)
                {
                    if (word.Equals(keywords[j].ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


    }
}
