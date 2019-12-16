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
        //Speichert bereits beantwortete Fragen
        private ObservableCollection<CardViewModel> finishedCards;
        private CategoryViewModel category;
        #endregion


        public LernmodusViewModel()
        {
            submitAnswerCommand = new RelayCommand(this.SubmitAnswer, this.ReturnTrue);
            cancelTrainingCommand = new RelayCommand(this.CancelTraining, this.ReturnTrue);
            markCardCommand = new RelayCommand(this.MarkCard, this.ReturnTrue);
            requestHelpCommand = new RelayCommand(this.RequestHelp, this.ReturnTrue);
        }
        

        private void SubmitAnswer()
        {
            Console.WriteLine(learnedCardsCounter);
            LearnedCardsCounter++;

            

          /*  finishedCards.Add(currentCard);
            CardViewModel nextCard = GetNextCard();
            currentCard = nextCard;*/
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
