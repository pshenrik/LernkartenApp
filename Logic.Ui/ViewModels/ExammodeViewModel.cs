using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System.Windows.Input;
using System.Threading;
using De.HsFlensburg.LernkartenApp001.Services.ServiceBus;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Messages;


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{



    public class ExamModeViewModel : AbstractViewModel
    {
        private CardViewModel currentCard; 
        private bool enableSetting;
        private int cardCounter; 
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
        private Thread examThread;
        private Thread progressThread;
        public SetViewModel Set { get; set; }
        
        public CategoryViewModel[] CategoryList { get; set; }


        public ExamModeViewModel()
        {
            Set = new SetViewModel();
            VisabilityExamUi = "Hidden";
            CanStop = false;
            getCategorys();
            Time = 5;
            Question = "";
            ExamProgress = 0;
            QuestionProgress = 0;
            rand = new Random();
            this.EnableSettings = true;
            this.cardAmount = 1;
            this.time = 5;    
            this.startExamCommand = new RelayCommand(this.StartExam, this.ReturnStartTrue);
            this.stopExamCommand = new RelayCommand(this.StopExam, this.ReturnStartTrue);

            
        }
      
        #region Propertys
        public CardCollectionViewModel[] Collections
        {
            get
            {
                return this.collections;
            }
            set
            {
                
                this.collections = value;
                Console.WriteLine(collections);
                
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
                OnPropertyChanged();
                Console.WriteLine(this.answer);
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
                this.CardAmount = value/2 ;
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
        public void StartExam()
        {

            ExamStarted = true;
            VisabilityExamUi = "Visable";
            EnableSettings = false;
            CanStart = false;
            CanStop = true;
            examThread = new Thread(new ThreadStart(() => exam()));
            examThread.Start();
        }
        private void exam()
        {
            usedCards = new bool[5][];
            usedCards[0] = new bool[Collections[0].Count];
            usedCards[1] = new bool[Collections[1].Count];
            usedCards[2] = new bool[Collections[2].Count];
            usedCards[3] = new bool[Collections[3].Count];
            usedCards[4] = new bool[Collections[4].Count];

            for (int i = 0; i < CardAmount; i++)
            {
                if(i == 0)
                {
                    Thread.Sleep(1000);
                }
                ProgressString = "Frage " + (i + 1) + " von " + CardAmount;
                QuestionProgress = 0;
                stopTask = false;
                Action a = new Action(() => startTime(this.time));
                progressThread = new Thread(new ThreadStart(() => startTime(this.time)));
                getNextCard();
                progressThread.Start();

                Question = currentCard.Front.Text;

                progressThread.Join();
                ExamProgress = 100f / CardAmount * (i + 1);
                Thread.Sleep(500);
                Answer = "";
                
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

        private bool[][] usedCards; 
        private void getNextCard()
        {

            for(int i = 0; i < 1; i++)
            {
                int collectionSelector = rand.Next(0, 101);

                int collection;
                
                if(collectionSelector <= 30)
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

                if(Collections[collection].Count == 0)
                {
                    i--;
                }else if (!UnusedCards(collection)) {
                    i--;
                }
                else
                {
                    for(int j = 0; j < 1; j++)
                    {
                        int questionSelector = rand.Next(0, Collections[collection].Count);

                        if (usedCards[collection][questionSelector])
                        {
                            j--;
                        }else
                        {
                            currentCard = Collections[collection].ElementAt(questionSelector);
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
        private bool ReturnStartTrue()
        {
            return true;
        }



        private bool ReturnStopTrue()
        {
            return this.ExamStarted;
        }


       


        private void getCategorys()
        {
            

            for(int i = 0; i < 10; i++)
            {
                CategoryViewModel cat  = new CategoryViewModel("Kategorie" + (i+1));

                for(int j = 0; j < (i*2); j++)
                {
                    CardViewModel card = new CardViewModel();
                    card.Front.Text = "Kategorie " + (i+1)+ " Frage " + (j+1);
                    cat.Collections[0].Add(card);
                }


                Set.Add(cat);
            }



        }
        #endregion

    }


}
