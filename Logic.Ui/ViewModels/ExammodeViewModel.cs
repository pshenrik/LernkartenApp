﻿using System;
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
        private bool examStarted;
        private string answer;
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
            OpenMainMenuCommand = new RelayCommand(() => this.back());
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
        private ICommand backToMenu;
        public ICommand StartExamCommand { get { return startExamCommand; } }
        public RelayCommand OpenMainMenuCommand { get; }
        public void StartExam()
        {
            ExamStarted = true;
            EnableSettings = false;
            CanStart = false;
            Thread examThread = new Thread(new ThreadStart(() => exam()));
            examThread.Start();
        }

        private void back()
        {
            ServiceBus.Instance.Send(new OpenMainMenuWindow());
        }
        #endregion

        #region ExamMethods
        private void exam()
        {
        for (int i = 0; i < CardAmount; i++)
            {
                QuestionProgress = 0;
                stopTask = false;
                Action a = new Action(() => startTime(this.time));
                Thread progressThread = new Thread(new ThreadStart(() => startTime(this.time)));
                progressThread.Start();

                //TODO: AbfrageAlgorithmus

                progressThread.Join();
                ExamProgress = 100f / CardAmount * (i + 1);
                Thread.Sleep(500);
                Answer = "";
                
            }
            QuestionProgress = 0;
            ExamProgress = 0;
            EnableSettings = true;
            CanStart = true;
            ExamStarted = false;
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

        #endregion
        
        
        #region Other
        private bool ReturnStartTrue()
        {
            return true;
        }






       


        private void getCategorys()
        {
            CategoryList = new CategoryViewModel[2];

            CategoryList[0] = new CategoryViewModel("Mathe");
            CategoryList[0].Collections[0].Add(new CardViewModel("Was ist 1+1"));
            CategoryList[0].Collections[0].Add(new CardViewModel("Was ist Kartoffel"));

            CategoryList[1] = new CategoryViewModel("Deutsch");
            CategoryList[1].Collections[0].Add(new CardViewModel("Was ist 1+1"));
            CategoryList[1].Collections[0].Add(new CardViewModel("Was ist Kartoffel"));
            CategoryList[1].Collections[0].Add(new CardViewModel("Was ist 1+1"));
            CategoryList[1].Collections[0].Add(new CardViewModel("Was ist Kartoffel"));
            CategoryList[1].Collections[0].Add(new CardViewModel("Was ist 1+1"));
            CategoryList[1].Collections[0].Add(new CardViewModel("Was ist Kartoffel"));



        }
        #endregion

    }


}
