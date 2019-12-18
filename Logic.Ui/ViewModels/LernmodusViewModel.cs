using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{

    /*
     * Sind die Variablen zu den Attributen so richtig?
     * 
     * INotifyPropertyChanged ?
     * 
     * learnedCardsCounter ändert sich nicht im UI
     * 
     * CardCollection hat kein NotifyPropertyChanged ?
     * 
     * ListBox Name anzeigen
     * 
     * 
     * TODO
     * x:Class="ViewModelLocator.MainWindow"
     * in die xaml einfügen
     */
    public class LernmodusViewModel : AbstractViewModel
    {
        #region ICommand
        private ICommand submitAnswerCommand;
        private ICommand cancelTrainingCommand;
        private ICommand markCardCommand;
        private ICommand requestHelpCommand;
        public ICommand SubmitAnswerCommand { get { return submitAnswerCommand; } }
        public ICommand CancelTrainingCommand { get { return cancelTrainingCommand; } }
        public ICommand MarkCardCommand { get { return markCardCommand; } }
        public ICommand RequestHelpCommand { get { return requestHelpCommand; } }
        #endregion

        #region Properties
        private String answerInputText;
        public String AnswerInputText
        {
            get
            {
                return answerInputText;
            }
            set
            {
                answerInputText = value;
                OnPropertyChanged();
            }
        }

        private int learnedCardsCounter = 0;
        public int LearnedCardsCounter
        {
            get
            {
                return learnedCardsCounter;
            }
            set
            {
                learnedCardsCounter = value;
                OnPropertyChanged();
            }
        }

        private CardViewModel currentCard;
        public CardViewModel CurrentCard
        {
            get
            {
                return currentCard;
            }

            set
            {
                currentCard = value;
                OnPropertyChanged();
            }
        }
        //Speichert bereits beantwortete Fragen
        private ObservableCollection<CardViewModel> finishedCards;

        public ObservableCollection<CardViewModel> FinishedCards
        {
            get
            {
                return finishedCards;
            }

            set
            {
                finishedCards = value;
                OnPropertyChanged();
            }
            
        }

        

        #endregion

        public LernmodusViewModel(SetViewModel set)
        {

        }

        private CategoryViewModel category;
        public LernmodusViewModel(CategoryViewModel category)
        {
            submitAnswerCommand = new RelayCommand(this.SubmitAnswer, this.ReturnTrue);
            cancelTrainingCommand = new RelayCommand(this.CancelTraining, this.ReturnTrue);
            markCardCommand = new RelayCommand(this.MarkCard, this.ReturnTrue);
            requestHelpCommand = new RelayCommand(this.RequestHelp, this.ReturnTrue);
            this.FinishedCards = new ObservableCollection<CardViewModel>();
          
            FinishedCards.Add(new CardViewModel(new Card("test1")));
            FinishedCards.Add(new CardViewModel(new Card("test2")));
            FinishedCards.Add(new CardViewModel(new Card("test3")));
            

            this.category = category;
            //Bsp Karte erstellen
            this.CurrentCard = new CardViewModel(new Card("Hammerhart"));
            CurrentCard.Front.Text = "Woher kommt Brendan?";
            CurrentCard.Back.Text = "Mepw";
            
        }
        

        private void SubmitAnswer()
        {
            Console.WriteLine(learnedCardsCounter);
            LearnedCardsCounter++;

            

          /*FinishedCards.Add(currentCard);
            CardViewModel nextCard = GetNextCard();
            currentCard = nextCard;*/
        }

        //Zeigt eine Karte aus der Liste an
        private void ShowCard()
        {

        }

   

        private CardViewModel GetNextCard()
        {
            Random rand = new Random();
            //Erstmal zufällig aus einem der Stapel auswählen
            int collectionIndex = rand.Next(category.Collections.Length);
            //Zufällige Karte aus dem Stapel auswählen
            int cardIndex = rand.Next(category.Collections[collectionIndex].cards.Count);



            CardViewModel card = new CardViewModel(category.Collections[collectionIndex].cards[cardIndex]);

            return card;
        }

        private void CancelTraining()
        {   
            Console.WriteLine("cancel");
        }

        private void MarkCard()
        {

            //currentCard.Marked = true;
        }

        private void RequestHelp()
        {   
            //Zeigt ein Keyword an, wenn es nur eins gibt, dann wird die Hälfte des Strings angezeigt
            Console.WriteLine("help");
        }

        private bool ReturnTrue()
        {
            return true;
        }

    }


}
