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


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{



    public class ExamModeViewModel : AbstractViewModel
    {
        private bool enableSetting;
        private int cardCounter; 
        private CardCollectionViewModel[] collections;
        private long time;
        private int cardAmount;
        private bool canStart;
        private float questionProgress;
        private float examProgress;
        private CardViewModel[] cards;
        private string color;
        private bool stopTask;
        public CategoryViewModel[] CategoryList { get; set; }


        public ExamModeViewModel()
        {
            getCategorys();
            Time = 5;
            ExamProgress = 0;
            QuestionProgress = 0;
            this.EnableSettings = true;
            this.cardAmount = 1;
            this.time = 5;    
            this.startExamCommand = new RelayCommand(this.StartExam, this.ReturnStartTrue);     
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
                this.CardAmount = value/2 +1;
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
        
        public ICommand StartExamCommand { get { return startExamCommand; } }

        public void StartExam()
        {
            EnableSettings = false;
            CanStart = false;
            Thread examThread = new Thread(new ThreadStart(() => exam()));

            examThread.Start();
           
        }
        #endregion
        private void exam()
        {
            
            Console.WriteLine("moin");


            for (int i = 0; i < CardAmount; i++)
            {
                QuestionProgress = 0;
                stopTask = false;
                Action a = new Action(() => startTime(this.time));
                Thread progressThread = new Thread(new ThreadStart(() => startTime(this.time)));
                progressThread.Start();
                progressThread.Join();
                
                Thread.Sleep(500);
                ExamProgress = 100f / CardAmount * (i+1);
            }
            QuestionProgress = 0;
           // ExamProgress = 0;
            EnableSettings = true;
            CanStart = true;
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


        #region Other
        private bool ReturnStartTrue()
        {
            return true;
        }






        private CardCollectionViewModel coll;
        private CardCollectionViewModel[] cols;


        private void getCategorys()
        {
            CategoryList = new CategoryViewModel[20];
            for (int i =0; i< CategoryList.Length; i++)  {
                CategoryList[i] = new CategoryViewModel();
                CategoryList[i].Name = "Moin " + (i+1);
                cols = new CardCollectionViewModel[1];
                coll = new CardCollectionViewModel();
                for(int j = 0; j<i*2; j++)
                {
                    coll.Add(new CardViewModel("Hallo"));
                    
                }
                
                cols[0] = coll;
                CategoryList[i].Collections = cols;
            }
            
            
        }
        #endregion

    }


}
