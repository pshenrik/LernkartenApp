using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System.Windows.Input;


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{



    public class ExamModeViewModel : AbstractViewModel
    {

        private int cardCounter; 
        private CardCollectionViewModel[] collections;
        private float time;
        private int cardAmount;
        private bool canStart;
        public CategoryViewModel[] CategoryList { get; set; }


        public ExamModeViewModel()
        {
            getCategorys();
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
                this.CardCounter = counter;
                Console.WriteLine(collections.Length);
                CanStart = true;
            }
        }
        public float Time
        {
            get
            {
                return this.time;
            }
            set {
                this.time = value;
                Console.WriteLine(time);
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
        public int CardCounter
        {
            get
            {
                return this.cardCounter;
            }
            set
            {
                this.cardCounter = value;
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
                Console.WriteLine(cardAmount);
                OnPropertyChanged();
            }
        }

        
        #endregion

        #region Command / RelayCommandStuff

        private ICommand startExamCommand;
        
        public ICommand StartExamCommand { get { return startExamCommand; } }

        public void StartExam()
        {
            Console.WriteLine("moin");
        }
        #endregion




        #region Other
        private bool ReturnStartTrue()
        {
            return true;
        }

        private CardCollectionViewModel coll;
        private CardCollectionViewModel[] cols;
        private void getCategorys()
        {
            CategoryList = new CategoryViewModel[5];
            for (int i =0; i< CategoryList.Length; i++)  {
                CategoryList[i] = new CategoryViewModel();
                CategoryList[i].Name = "Moin" + i;
                coll = new CardCollectionViewModel();
                coll.Add(new CardViewModel("Hallo"));
                coll.Add(new CardViewModel("Hallo"));
                
            }
            
            
        }
        #endregion

    }


}
