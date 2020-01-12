using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{

    /*
     Methodennamen so richtig ? Klein/Großschreibung
     CheckStartRequirements in die Bedingung mit ReturnTrue einbinden
     Properties so richtig mit private Backendfield?
     */
    public class LernmodusViewModel : AbstractViewModel
    {
        #region ICommand
        private ICommand submitAnswerCommand;
        private ICommand nextCardCommand;
        private ICommand markCardCommand;
        private ICommand requestHelpCommand;
        private ICommand startLearningCommand;
        private ICommand stopLearningCommand;
        public ICommand SubmitAnswerCommand { get { return submitAnswerCommand; } }
        public ICommand NextCardCommand { get { return nextCardCommand; } }
        public ICommand MarkCardCommand { get { return markCardCommand; } }
        public ICommand RequestHelpCommand { get { return requestHelpCommand; } }
        public ICommand StartLearningCommand { get { return startLearningCommand; } }
        public ICommand StopLearningCommand { get { return stopLearningCommand; } }
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
                if(value != null) {
                   
                    CurrentCardPage = value.Front;

                    if (value.Info.Marked)
                    {
                        Console.WriteLine("true");
                        CurrentCardMarked = "Visible";
                    } else
                    {
                        CurrentCardMarked = "Hidden";
                    }
                
                    
                }
                
                ShowHelpMessage = "Hidden";
                OnPropertyChanged();
            }
        }
        //Die Karte vor dem Wechsel
        private CardViewModel cardBuffer;
        public CardViewModel CurrentCardListBox
        {
            set
            {
                if (cardBuffer == null)
                {
                    cardBuffer = CurrentCard;
                }
                CurrentCard = value;

                //Buttons enablen/disablen
                NextButtonEnabled = true;
                SubmitButtonEnabled = false;
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
                Console.WriteLine(value);
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

        private bool nextButtonEnabled = false;
        public bool NextButtonEnabled { 
            get
            {
                return nextButtonEnabled;
            }
            set
            {
                nextButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool menuButtonsEnabled = true;
        public bool MenuButtonsEnabled
        {
            get
            {
                return menuButtonsEnabled;
            }
            set
            {
                menuButtonsEnabled = value;
                OnPropertyChanged();
            }
        }

        public SetViewModel Set { get; set; }
  

        public CategoryViewModel category;
        public CategoryViewModel Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }

        private bool hideLearningInterface = true;
        public string HideLearningInterface
        {
            get
            {
                if (hideLearningInterface)
                {
                    return "Hidden";
                } 
                return "Visible";
            }
            set
            {
                if (value.Equals("Hidden"))
                {
                   
                    hideLearningInterface = true;
                } else
                {
                    hideLearningInterface = false;
                }
                
                OnPropertyChanged();
            }
        }
        private bool currentCardMarked;
        public string CurrentCardMarked
        {
            get
            {
                if (CurrentCard != null && CurrentCard.Info.Marked)
                {
                    Console.WriteLine("visible");
                    return "Visible";
                }
                Console.WriteLine("hidden");
                return "Hidden";
            }

            set
            {
                if (value == "Visible")
                {
                    currentCardMarked = true;
                } 
                currentCardMarked = false;
                OnPropertyChanged();
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        private string helpMessage;
        public string HelpMessage
        {
            get
            {
                return helpMessage;
            }
            set
            {
                helpMessage = value;
                OnPropertyChanged();
            }
        }

        private bool showHelpMessage;
        public string ShowHelpMessage
        {
            get
            {
                if (showHelpMessage)
                {
                    return "Visible";
                }
                return "Hidden";
            }
            set
            {
                if (value.Equals("Visible"))
                {
                    showHelpMessage = true;
                } else
                {
                    showHelpMessage = false;
                }
                
                OnPropertyChanged();
            }
        }

        #endregion


        private string red = "#e62020";
        private string green = "#41e620";
        private string white = "#fff";
        
        private int currentCardIndex;
    

        public LernmodusViewModel(SetViewModel set)
        {
            this.Set = set;

            submitAnswerCommand = new RelayCommand(this.SubmitAnswer, this.ReturnTrue);
            nextCardCommand = new RelayCommand(this.NextCard, this.ReturnTrue);
            markCardCommand = new RelayCommand(this.MarkCard, this.ReturnTrue);
            requestHelpCommand = new RelayCommand(this.RequestHelp, this.ReturnTrue);
            startLearningCommand = new RelayCommand(this.StartLearning, this.ReturnTrue);
            stopLearningCommand = new RelayCommand(this.StopLearning, this.ReturnTrue);
            this.FinishedCards = new ObservableCollection<CardViewModel>();

        
        }

        private void StartLearning()
        {
            if (CheckStartRequirements())
            {
                //Interface einblenden
                HideLearningInterface = "Visible";
                CurrentCard = GetNextCard();

                MenuButtonsEnabled = false;
            }
        }

        private void StopLearning()
        {
            HideLearningInterface = "Hidden";
            FinishedCards = new ObservableCollection<CardViewModel>();
            MenuButtonsEnabled = true;
        }

        private bool CheckStartRequirements()
        {
            //Es muss eine Kategorie ausgewählt sein und diese darf nicht leer sein.
            if (category != null )
            {
                if (category.NumberOfCards > 0)
                {
                    ErrorMessage = "";
                    return true;
                } else
                {
                    ErrorMessage = "Die ausgewählte Kategorie ist leer.";
                }
                
            } else
            {
                ErrorMessage = "Bitte wähle eine Kategorie aus.";
            }
          

            return false;
        }

        //Überprüft, ob eine Kategorie leer ist
        private bool CategoryContainsCards(CardCollectionViewModel[] categoryCollections)
        {
            for(int i = 0; i < 5; i++)
            {
                if(categoryCollections[i].Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        

        private void SubmitAnswer()
        {
            LearnedCardsCounter++;
            Console.WriteLine(Set.Count);
            //Antwort anzeigen
            CurrentCardPage = currentCard.Back;
            SubmitButtonEnabled = false;
            NextButtonEnabled = true;
          

            //Wenn die eingegebene Antwort richtig ist
            if (currentCard.Card.CheckAnswer(answerInputText))
            {
                CardToNextLevel(currentCard);
                AnswerIndicatorFillColor = green;
                currentCard.Info.LearnHistory.Add(true);
            }
            //Wenn die Anwort falsch ist
            else
            {
                CardToLowerLevel(currentCard);
                AnswerIndicatorFillColor = red;
                currentCard.Info.LearnHistory.Add(false);
            }
            AnswerInputText = "";



        }
        private void CardToNextLevel(CardViewModel card)
        {
           int index = currentCardIndex + 1;
           if (currentCardIndex == 4) {
                index = 0;
           }
           //Aus dem akutellen Level entfernen
           category.Collections[currentCardIndex].Remove(card);
            //Zum nächsten Level hinzufügen
           category.Collections[index].Add(card);
        }

        private void CardToLowerLevel(CardViewModel card)
        {
            //Aus dem akutellen Level entfernen
            category.Collections[currentCardIndex].Remove(card);
            //Zum 1 Level hinzufügen
            category.Collections[0].Add(card);
        }

        private void NextCard()
        {
            AnswerIndicatorFillColor = white;
            SubmitButtonEnabled = true;
            NextButtonEnabled = false;

            //Neue Karte der Lern History hinzufügen
            if(cardBuffer == null)
            {
                FinishedCards.Add(currentCard);
            }
            
            
            CurrentCard = GetNextCard();
            
            cardBuffer = null;
        }
        

   
        //Der Lernmodus-Algorithmus
        private CardViewModel GetNextCard()
        {
            
            if(cardBuffer != null) {
                return cardBuffer;
            } else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(100);
                CardViewModel nextCard;
                int index;

                //50% für Stapel 1
                if (randomNumber <= 50)
                {
                    index = 0;
                }
                //25% für Stapel 2
                else if (randomNumber <= 75)
                {
                    index = 1;
                }
                //12% für Stapel 3
                else if (randomNumber <= 87)
                {
                    index = 2;
                }
                //8% für Stapel 4
                else if (randomNumber <= 95)
                {
                    index = 3;
                }
                //5% für Stapel 5
                else
                {
                    index = 4;
                }

                if (category.Collections[index].Count != 0)
                {
                    currentCardIndex = index;
                    nextCard = category.Collections[index][0];
                }
                else
                {
                    nextCard = FindCard(index, 1);
                }
                return nextCard;
            }
           
        }

        //Durchsucht andere Collections nach Karten
        private CardViewModel FindCard(int startIndex, int tryCounter)
        {
            int index = startIndex + 1;
            if (startIndex == 4)
            {
                index = 0;
            }

            if (category.Collections[index].Count == 0)
            {
                return FindCard(index, tryCounter + 1);
            }
            else
            {
                currentCardIndex = index;
                return category.Collections[index][0];
            }
            
            
        }

        private void MarkCard()
        {
            CurrentCard.Info.Marked = true;
            CurrentCardMarked = "Visible";
        }

        private void RequestHelp()
        {   
            //Zeigt ein Keyword an, wenn es nur eins gibt, dann wird die Hälfte des Strings angezeigt
            string message;
            if (CurrentCard.Keywords.Count > 0)
            {
                string keywordPart = currentCard.Keywords[0].Substring(0, currentCard.Keywords[0].Length/2);
                message = "Ein gesuchtes Keyword fängt mit " + keywordPart + " an.";
            } else
            {
                string answerPart = currentCard.Back.Text.Substring(0, currentCard.Back.Text.Length/2);
                message = "Die Antwort fängt mit '"+ answerPart + "' an.";
            }

            HelpMessage = message;
            ShowHelpMessage = "Visible";
        }

        private bool ReturnTrue()
        {
            return true;
        }

    }


}
