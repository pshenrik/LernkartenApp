using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System.Windows.Input;
using System.Threading;
using static System.Windows.Threading.Dispatcher;
using De.HsFlensburg.LernkartenApp001.Services.ServiceBus;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Messages;


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{



    public class ExamModeViewModel : AbstractViewModel
    {
        private System.Windows.Threading.Dispatcher dispatcher; 
        private CardViewModel selectedWrongCard;
        private CardViewModel currentCard;
        private string selectedWrongQuestion;
        private string selectedWrongAnswer;
        private bool enableSetting;
        private int cardCounter;
        private string percentString;
        private CardCollectionViewModel[] collections;
        private long time;
        private int cardAmount;
        private bool canStart;
        private bool canStop;
        private float questionProgress;
        private float examProgress;
        private CardViewModel[] cards;
        private string color;
        private bool stopTask;
        private bool examStarted;
        private string answer;
        private string question;
        private string progressString;
        private Random rand;
        private string visabilityExamUi;
        private string visabilityStatUi;
        private Thread examThread;
        private Thread progressThread;
        private string boxColor;
        private string statString;
        public SetViewModel Set { get; set; }
        
        public CategoryViewModel[] CategoryList { get; set; }


        public ExamModeViewModel (SetViewModel set)
        {
            this.Set = set;
            dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            VisabilityExamUi = "Hidden";
            VisabilityStatUi = "Hidden";
            CanStop = false;
            boxColor = "white";
            WrongAnswers = new ObservableCollection<CardViewModel>();
            Time = 5;
            Question = "";
            ExamProgress = 0;
            QuestionProgress = 0;
            rand = new Random();
            this.EnableSettings = true;
            this.cardAmount = 1;
            this.time = 5;
            this.startExamCommand = new RelayCommand(this.StartExam, this.ReturnTrue);
            this.stopExamCommand = new RelayCommand(this.StopExam, this.ReturnTrue);
        }


        #region Propertys
        public String VisabilityStatUi
        {
            get
            {
                return this.visabilityStatUi;
            }
            set
            {
                this.visabilityStatUi = value;
                OnPropertyChanged();
            }
        }
        public String SelectedWrongQuestion
        {
            get
            {
                return this.selectedWrongQuestion;
            }
            set
            {
                this.selectedWrongQuestion = value;
                OnPropertyChanged();
            }
        }
        public String SelectedWrongAnswer
        {
            get
            {
                return this.selectedWrongAnswer;
            }
            set
            {
                this.selectedWrongAnswer = value;
                OnPropertyChanged();
            }
        }
        public CardViewModel SelectedWrongCard
        {
            get
            {
                return this.selectedWrongCard;
            }
            set
            {
                this.selectedWrongCard = value;
                if(this.selectedWrongCard != null)
                {
                    this.SelectedWrongQuestion = selectedWrongCard.Front.Text;
                    this.SelectedWrongAnswer = selectedWrongCard.Back.Text;
                }
                
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CardViewModel> WrongAnswers { get; set; }
        public String BoxColor
        {
            get
            {
                return this.boxColor;
            }
            set
            {
                this.boxColor = value;
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
   
                
                int counter = 0;
                for (int i = 0; i < collections.Length; i++)
                {
                   
                    counter += collections[i].Count;
                }
                cards = new CardViewModel[counter];
                counter = 0;
                for(int i = 0; i < collections.Length; i++)
                {


                    for(int j = 0; j < collections[i].Count; j++)
                    {
                        cards[counter] = collections[i].ElementAt(j);
                        counter++;
                    }
                    

                }
                this.CardCounter = counter;
                
                if(counter > 0)
                {
                    CanStart = true;
                }else
                {
                    CanStart = false;
                }
                
            }
        }
        public String PercentString
        {
            get
            {
                return this.percentString;
            }
            set
            {
                this.percentString = value;
                OnPropertyChanged();
            }
        }
        public String StatString
        {
            get
            {
                return this.statString;
            }
            set
            {
                this.statString = value;
                OnPropertyChanged();
            }
        }
        
        public String VisabilityExamUi
        {
            get
            {
                return this.visabilityExamUi;
            }
            set
            {
                this.visabilityExamUi = value;
                OnPropertyChanged();
            }
        }
        public long Time
        {
            get
            {
                return this.time;
            }
            set {
                this.time = value;
                
                OnPropertyChanged();

            }
            
        }
        public String Answer
        {
            get
            {
                return this.answer;
            }
            set
            {
                this.answer = value;
                if (this.currentCard.CheckAnswer(this.answer))
                {
                    this.stopTask = true;
                }
                OnPropertyChanged();
                Console.WriteLine(this.answer);
            }
        }

        public CardViewModel CurrentCard
        {
            get
            {
                return this.currentCard;
            }
            set
            {
                this.currentCard = value;
                OnPropertyChanged();
            }
        }
        public bool CanStart
        {
            get
            {
                return canStart;
                
            }
            set
            {
                this.canStart = value;
                OnPropertyChanged();
            }


        }
        public String Question
        {
            get
            {
                return this.question; 
            }
            set
            {
                this.question = value;
                OnPropertyChanged();
            }
        }
        public String ProgressString
        {
            get
            {
                return this.progressString;
            }
            set
            {
                this.progressString = value;
                OnPropertyChanged();
            }
        }
        public float QuestionProgress
        {
            get
            {
                return this.questionProgress;
            }
            set
            {
                this.questionProgress = value;
                
                if (questionProgress <= 66)
                {
                    this.Color = "Green";
                }else if (questionProgress <= 90 ) {
                    this.Color = "Orange";
                }else
                {
                    this.Color = "Red";
                }
                OnPropertyChanged();
            }
        }
        public int CardCounter
        {
            get
            {
                return this.cardCounter;
            }
            set
            {
                this.cardCounter = value;
                if(cardCounter > 1)
                {
                    this.CardAmount = value / 2;
                }
                else
                {
                    this.CardAmount = value;
                }
                OnPropertyChanged();
            }

        }
        public bool ExamStarted
        {
            get
            {
                return this.examStarted;
            }
            set
            {
                this.examStarted = value;
                OnPropertyChanged();
            }
        }
        public float ExamProgress
        {
            get
            {
                return this.examProgress;
            }
            set
            {
                this.examProgress = value;

               
                OnPropertyChanged();
            }

        }
        public bool EnableSettings
        {
            get
            {
                return this.enableSetting;
            }
            set
            {
                this.enableSetting = value;
                OnPropertyChanged();
            }
        }
        public bool CanStop
        {
            get
            {
                return this.canStop;
            }
            set
            {
                this.canStop = value;
                OnPropertyChanged();
            }
        }
        public int CardAmount
        {
            get
            {
                return this.cardAmount;
            }
            set
            {
                this.cardAmount = value;
                
                OnPropertyChanged();
            }
        }

        public String Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        #region Command / RelayCommandStuff

        private ICommand startExamCommand;
        private ICommand stopExamCommand;
        public ICommand StopExamCommand { get { return stopExamCommand; } }
        public ICommand StartExamCommand { get { return startExamCommand; } }

        #endregion

        #region ExamMethods 
        // Die Methode stoppt die Prüfung, wird nach klick auf "abbrechen" ausgeführt
        //Propertys für UI werden wieder auf 0 gesetzt. 
        private void StopExam()
        {
            progressThread.Abort();
            examThread.Abort();
            VisabilityExamUi = "Hidden";
            QuestionProgress = 0;
            ExamProgress = 0;
            EnableSettings = true;
            CanStart = true;
            ExamStarted = false;
            ProgressString = "";
            Question = "";
            CanStop = false;

        }
        // Die Methode startet die Prüfung, wird nach klick auf "start" ausgeführt

        private void StartExam()
        {

            VisabilityStatUi = "Hidden";
            WrongAnswers.Clear();
            SelectedWrongQuestion = "";
            SelectedWrongAnswer = "";
            
            ExamStarted = true;
            VisabilityExamUi = "Visable";
            EnableSettings = false;
            CanStart = false;
            CanStop = true;
            //Hier wird der Thread gestartet, auf dem das Exam läuft
            examThread = new Thread(new ThreadStart(() => Exam()));
            examThread.Start();
        }
        private bool[][] usedCards;
        //Das eigentliche Exam
        private void Exam()
        {
            //Array für bereits verwendete karten
            usedCards = new bool[5][];
            usedCards[0] = new bool[Collections[0].Count];
            usedCards[1] = new bool[Collections[1].Count];
            usedCards[2] = new bool[Collections[2].Count];
            usedCards[3] = new bool[Collections[3].Count];
            usedCards[4] = new bool[Collections[4].Count];

            
            int initialCardAmount = CardAmount;

            //Diese For-Schleife wird aml die vom nutzer eingestellte Anzahl an Karten ausgeführt
            for (int i = 0; i < CardAmount; i++)
            {
               
                if(i == 0)
                {
                    //Zu bebegin des Exams Halbe Sekunde Pause, damit der Nutzer sich kurz auf die Frage einstellen kann
                    Thread.Sleep(500);
                }
                ProgressString = "Frage " + (i + 1) + " von " + CardAmount;
                QuestionProgress = 0;
                stopTask = false;
                //Dieser Thread stoppt die Zeit
                progressThread = new Thread(new ThreadStart(() => startTime(this.time)));
                GetNextCard(); //Neue Karte wird geholt
                progressThread.Start();

                Question = currentCard.Front.Text;

                progressThread.Join(); //Warten bis die Zeit abgelaufen ist (oder bis die Frage korrekt beantwortet wurde)
                ExamProgress = 100f / CardAmount * (i + 1);
                if (!stopTask)
                {
                    //Wurde die Frage nicht richtig beantwortet, wird Sie der WrongAnswerCollection hinzugefügt
                    dispatcher.Invoke(() => WrongAnswers.Add(currentCard));
                    
                }
                else
                {

                    BoxColor = "Green";
                    stopTask = false;
                }
                Thread.Sleep(500); //Pause Nach einer Frage
                Answer = "";
                BoxColor = "White";
                
            }
            CanStop = false;
            VisabilityExamUi = "Hidden";
            QuestionProgress = 0;
            ExamProgress = 0;
            EnableSettings = true;
            CanStart = true;
            ExamStarted = false;
            ProgressString = "";
            Question = "";        
            Statistics(initialCardAmount);
        }
        
        private void startTime(long timeForQuestion)
        {
            
            long timeMs = timeForQuestion * 1000;         
            long startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long diff = 0;
            while (diff < timeMs && !stopTask)
            {
                QuestionProgress = 100f / timeMs * diff;               
                diff = DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime;                              
            }
            
        }

        private void Statistics(int initialCardAmount)
        {
            double rightAnswers = initialCardAmount - WrongAnswers.Count;
            double percentCorrect = (rightAnswers / initialCardAmount) * 100;
            VisabilityStatUi = "Visable";
            StatString = "Du hast " + rightAnswers + " von " + initialCardAmount + " Fragen richtig beantwortet";
            PercentString = "Das entspricht " + Math.Round(percentCorrect,2) + "%"; 

            
        }

         
        private void GetNextCard()
        {
            //Die for schleife wird wiederhohlt, wenn eine Karte ausgewählt wurde, die bereits gefragt wurde
            for(int i = 0; i < 1; i++)
            {
                int collectionSelector = rand.Next(0, 101);

                int collection;

                //30 % Chance für eine Karte aus der (schlechtesten) untersten Collection, usw.
                if (collectionSelector <= 30)
                {
                    collection = 0;
                }else if(collectionSelector <= 55)
                {
                    collection = 1;
                }else if(collectionSelector <= 75)
                {
                    collection = 2;
                }else if (collectionSelector <= 90)
                {
                    collection = 3;
                }else
                {
                    collection = 4;
                }
                //Falls eine Collecion ausgewählt wurde, die leer ist
                if(Collections[collection].Count == 0)
                {
                    i--;
                }else if (!UnusedCards(collection)) { //Falls alle karten der collectin bereits verwendet wurden
                    i--;
                }
                else
                {
                    for(int j = 0; j < 1; j++)
                    {
                        //Zufällige der Collection wird ausgewählt Karte wird ausgewählt
                        int questionSelector = rand.Next(0, Collections[collection].Count);
                        //Überprüfung ob die Karte bereits verwendet wurde
                        if (usedCards[collection][questionSelector])
                        {
                            j--;
                        }else
                        {
                            CurrentCard = Collections[collection].ElementAt(questionSelector);
                            usedCards[collection][questionSelector] = true;
                        }
                    }
                }
            }

            
        }

        private bool UnusedCards(int col)
        {
            bool freeCards = false;
            for(int i = 0; i < usedCards[col].Length; i++)
            {
                if (!usedCards[col][i])
                {
                    freeCards = true;
                }
            }

            return freeCards;
        }
        #endregion
              
        #region Other
        private bool ReturnTrue()
        {
            return true;
        }





       




        #endregion

    }


}
