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
        private ICommand nextCardCommand;
        private ICommand cancelTrainingCommand;
        private ICommand markCardCommand;
        private ICommand requestHelpCommand;
        public ICommand SubmitAnswerCommand { get { return submitAnswerCommand; } }
        public ICommand NextCardCommand { get { return nextCardCommand; } }
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
                CurrentCardPage = value.Front;
                interactedWithCard = false; //Interaktion bei einer neuen Karte auf false setzen
                OnPropertyChanged();
            }
        }

        private CardPageViewModel currentCardPage;
        public CardPageViewModel CurrentCardPage
        {
            get
            {
                return currentCardPage;
            }

            set
            {
                currentCardPage = value;
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
        private string answerIndicatorFillColor;
        public string AnswerIndicatorFillColor
        {
            get
            {
                return answerIndicatorFillColor;
            }
            set
            {
                answerIndicatorFillColor = value;
                OnPropertyChanged();
            }
        }
        private bool submitButtonEnabled = true;
        public bool SubmitButtonEnabled
        {
            get
            {
                return submitButtonEnabled;
            }
            set
            {
                submitButtonEnabled = value;
                OnPropertyChanged();
            }
        }


        #endregion
        private string red = "#e62020";
        private string green = "#41e620";
        private string white = "#fff";
    
        private bool interactedWithCard; //Ob mit der aktuellen Karte bereits interagiert wurde (Submit oder Skip)
        private CategoryViewModel category;
        public LernmodusViewModel()
        {
            submitAnswerCommand = new RelayCommand(this.SubmitAnswer, this.ReturnTrue);
            nextCardCommand = new RelayCommand(this.NextCard, this.ReturnTrue);
            cancelTrainingCommand = new RelayCommand(this.CancelTraining, this.ReturnTrue);
            markCardCommand = new RelayCommand(this.MarkCard, this.ReturnTrue);
            requestHelpCommand = new RelayCommand(this.RequestHelp, this.ReturnTrue);
            this.FinishedCards = new ObservableCollection<CardViewModel>();
            
            
            //Bsp Karte erstellen
            this.CurrentCard = new CardViewModel(new Card("Hammerhart"));
            CurrentCard.Front.Text = "Woher kommt Brendan?";
            CurrentCard.Back.Text = "Spanien";



        }
        

        private void SubmitAnswer()
        {
            Console.WriteLine(learnedCardsCounter);
            LearnedCardsCounter++;

            interactedWithCard = true;

            //Antwort anzeigen
            CurrentCardPage = currentCard.Back;
            SubmitButtonEnabled = false;

            //Wenn die eingegebene Antwort richtig ist
            if (currentCard.Card.CheckAnswer(answerInputText))
            {
                AnswerIndicatorFillColor = green;
                currentCard.Info.LearnHistory.Add(1);
            }
            //Wenn die Anwort falsch ist
            else
            {
                AnswerIndicatorFillColor = red;
                currentCard.Info.LearnHistory.Add(0);
            }
            

        }
        

        private void NextCard()
        {
            AnswerIndicatorFillColor = white;
            SubmitButtonEnabled = true;
            //Wenn die Karte geskippt wurde
            if (!interactedWithCard)
            {

                currentCard.Info.LearnHistory.Add(2);
            }
            //Neue Karte der Lern History hinzufügen
            FinishedCards.Add(currentCard);
            CurrentCard = GetNextCard();
        }
        

   
        //Der Lernmodusalgorithmus
        private CardViewModel GetNextCard()
        {
            /*Random rand = new Random();
            //Erstmal zufällig aus einem der Stapel auswählen
            int collectionIndex = rand.Next(category.Collections.Length);
            //Zufällige Karte aus dem Stapel auswählen
            int cardIndex = rand.Next(category.Collections[collectionIndex].cards.Count);



            CardViewModel card = new CardViewModel(category.Collections[collectionIndex].cards[cardIndex]);*/
            CardViewModel card = new CardViewModel(currentCard.Card);

            return card;
        }

        private void CancelTraining()
        {   
            Console.WriteLine("cancel");
        }

        private void MarkCard()
        {

            currentCard.Info.Marked = true;
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
