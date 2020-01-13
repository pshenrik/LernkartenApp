using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ViewMarkedCardsViewModel : AbstractViewModel
    {
        public SetViewModel Set { get; set; }
        
        
        private bool nextAvailable;
        private bool prevAvailable;
        private CardCollectionViewModel[] collections;
        private string currentQuestion;
        private string currentAnswer;
        private int currentCardIndex;
        private string uiVisable;
        private string info;
        private string cardName;
        private BitmapSource currentImage;
        private ObservableCollection<CardViewModel> markedCards;
        public ViewMarkedCardsViewModel(SetViewModel set)
        {
            this.Info = "";
            this.UiVisable = "Hidden";
            this.Set = set;
            this.markedCards = new ObservableCollection<CardViewModel>(); 
            this.CurrentCardIndex = 0;
            this.nextCard = new RelayCommand(this.getNextCard, this.ReturnTrue);
            this.prevCard = new RelayCommand(this.getPrevCard, this.ReturnTrue);
            this.remove = new RelayCommand ( this.removeMarker, this.ReturnTrue);
        }


        #region Propertys
        public BitmapSource CurrentImage
        {
            get
            {
                return this.currentImage;
            }
            set
            {
                this.currentImage = value;
                OnPropertyChanged();
            }
        }
        public String CardName
        {
            get
            {
                return this.cardName;
            }
            set
            {
                this.cardName = value;
                OnPropertyChanged();
            }
        }
        public string UiVisable
        {
            get
            {
                return this.uiVisable;
            }
            set
            {
                this.uiVisable = value;
                OnPropertyChanged();
            }
        }
        public String Info
        {
            get
            {
                return this.info;
            }
            set
            {
                this.info = value;
                OnPropertyChanged();
            }
        }
        public int CurrentCardIndex
        {
            get
            {
                return this.currentCardIndex;
            }
            set
            {
                this.currentCardIndex = value;

                if(currentCardIndex == 0)
                {
                    this.PrevAvailable = false;
                }
                else
                {
                    this.PrevAvailable = true;
                }

                if(currentCardIndex >= markedCards.Count-1)
                {
                    this.NextAvailable = false;
                }
                else
                {
                    this.NextAvailable = true;
                }
            }
        }
        public bool NextAvailable
        {
            get
            {
                return this.nextAvailable;
            }
            set
            {
                this.nextAvailable = value;
                OnPropertyChanged();
            }
        }

        public bool PrevAvailable
        {
            get
            {
                return this.prevAvailable;
            }
            set
            {
                this.prevAvailable = value;
                OnPropertyChanged();
            }
        }
        public String CurrentQuestion
        {
            get
            {
                return this.currentQuestion;
            }
            set
            {
                this.currentQuestion = value;
                OnPropertyChanged();
            }
        }

        public String CurrentAnswer
        {
            get
            {
                return this.currentAnswer;
            }
            set
            {
                this.currentAnswer = value;
                OnPropertyChanged();
            }
        }
        public CardCollectionViewModel[] Collections
        {
            get
            {
                return this.collections;
            }
            set
            {
                
                this.collections = value;
                
                this.refreshMarkedCards();
                
                OnPropertyChanged();

            }
        }
        #endregion

        #region RelayCommandStuff
        private ICommand nextCard;
        private ICommand prevCard;
        private ICommand remove;
        public ICommand Remove { get { return this.remove; } }
        public ICommand NextCard { get { return this.nextCard; } }
        public ICommand PrevCard { get { return this.prevCard; } }


        #endregion


        #region Methods

        private void refreshMarkedCards()
        {
            markedCards.Clear();

            for(int i = 0; i < collections.Length; i++)
            {
                for(int j =0; j< collections[i].Count; j++)
                {
                    if (this.collections[i].ElementAt(j).Info.Marked)
                    {
                        this.markedCards.Add(collections[i].ElementAt(j));
                        
                    }
                }
            }
            Console.WriteLine(this.markedCards.Count);
            if(this.markedCards.Count > 0)
            {
                this.Info = "In dieser Kategorie sind " + this.markedCards.Count + " Karten markiert";
                this.UiVisable = "Visable";
                this.CurrentImage = this.markedCards.ElementAt(0).Front.Image;
                this.CardName = this.markedCards.ElementAt(0).Name;
                this.CurrentQuestion = this.markedCards.ElementAt(0).Front.Text;
                this.CurrentAnswer = this.markedCards.ElementAt(0).Back.Text;
                this.CurrentCardIndex = 0;
            }else
            {
                this.Info = "In dieser Kategorie sind keine Karten markiert";
                this.UiVisable = "Hidden";
            }
            
        }
        private void getNextCard()
        {
            this.CurrentCardIndex++;
            this.CurrentImage = this.markedCards.ElementAt(this.CurrentCardIndex).Front.Image;
            this.CardName = this.markedCards.ElementAt(this.CurrentCardIndex).Name;
            this.CurrentQuestion = this.markedCards.ElementAt(this.CurrentCardIndex).Front.Text;
            this.CurrentAnswer = this.markedCards.ElementAt(this.CurrentCardIndex).Back.Text;
            Console.WriteLine(this.markedCards.ElementAt(this.CurrentCardIndex).Info.LastTimeUsed);

        }

        private void getPrevCard()
        {
            this.CurrentCardIndex--;
            this.CurrentImage = this.markedCards.ElementAt(this.CurrentCardIndex).Front.Image;
            this.CardName = this.markedCards.ElementAt(this.CurrentCardIndex).Name;
            this.CurrentQuestion = this.markedCards.ElementAt(this.CurrentCardIndex).Front.Text;
            this.CurrentAnswer = this.markedCards.ElementAt(this.CurrentCardIndex).Back.Text;

        }

        private void removeMarker()
        {
            this.markedCards.ElementAt(this.CurrentCardIndex).Info.Marked = false;
            this.markedCards.RemoveAt(this.CurrentCardIndex);

            if(this.markedCards.Count == 0)
            {
                this.Info = "In dieser Kategorie sind keine Karten markiert";
                this.UiVisable = "Hidden";
                this.CurrentQuestion = "";
                this.CurrentAnswer = "";
                this.CurrentCardIndex = 0;
                this.CardName = "";
                this.CurrentImage = null;
            }
            else 
            {
                this.Info = "In dieser Kategorie sind " + this.markedCards.Count+" Karten markiert";

                if (this.CurrentCardIndex <= this.markedCards.Count - 1)
                {
                    this.CardName = this.markedCards.ElementAt(this.CurrentCardIndex).Name;
                    this.CurrentQuestion = this.markedCards.ElementAt(this.CurrentCardIndex).Front.Text;
                    this.CurrentAnswer = this.markedCards.ElementAt(this.CurrentCardIndex).Back.Text;
                    this.CurrentImage = this.markedCards.ElementAt(this.CurrentCardIndex).Front.Image;

                }
                else if (this.CurrentCardIndex > 0)
                {
                    this.getPrevCard();

                }

            }
        }
        #endregion
        private bool ReturnTrue()
        {
            return true;
        }
    }
}
