using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class CardInfo : BusinessObject
    {
        //Allgemein
        private bool marked; //Wurde die Karte makiert
        private long createdTime; //Wann die Karte erstellt wurde

        //Lernmodus Variablen
        private ObservableCollection<int> learnHistory; //Speichert den Lernverlauf der Karte
                                    //0 = Falsch beantwortet
                                    //1 = Richtig beantwortet
                                    //2 = Übersprungen

        private long lastLearnedTime; //Speichert wann die Karte zuletzt gelernt wurde

        public CardInfo()
        {
            learnHistory = new ObservableCollection<int>();
        }


        #region General Properties
        public bool Marked
        {
            get
            {
                return marked;
            }
            set
            {
                marked = value;
                OnPropertyChanged();
            }
        }

        public long CreatedTime
        {
            get
            {
                return createdTime;
            }
            set
            {
                createdTime = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Lernmodus Properties
        public long LastLearnedTime
        {
            get
            {
                return lastLearnedTime;
            }
            set
            {
                lastLearnedTime = value;
                OnPropertyChanged();
            }
        }

        public string LastLearnedColor
        {
            get
            {
                if (learnHistory.Count > 0)
                {
                    switch (learnHistory[learnHistory.Count - 1])
                    {
                        case 0:
                            return "#e62020";
                        case 1:
                            return "#41e620";
                        default:
                            return "#fff";
                    }
                }
                return "#fff";

            }
        }


        public ObservableCollection<int> LearnHistory
        {
            get
            {
                return learnHistory;
            }
            set
            {
                learnHistory = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
