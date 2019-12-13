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

        private CategoryViewModel examCategory;
        private CardCollectionViewModel[] collections;
        private float time;
        private int cardAmount;
        public CategoryViewModel[] CategoryList { get; set; }


        public ExamModeViewModel()
        {
            getCategorys();
            this.cardAmount = 1;
            this.time = 5;    
            this.startExamCommand = new RelayCommand(this.StartExam, this.ReturnStartTrue);     
        }

        public ExamModeViewModel(Category category)
        {
            

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
                Console.WriteLine(collections.Length);
                OnPropertyChanged();
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
        public int CategoryCounter
        {
            get
            {
                return this.CategoryList.Length;
            }
            set
            {
                
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

        public CategoryViewModel ExamCategory
        {
            get
            {
                return this.examCategory;
            }
            set
            {
                this.examCategory = value;
                OnPropertyChanged();
                
            }
        }
        
        private ICommand startExamCommand;
        
        public ICommand StartExamCommand { get { return startExamCommand; } }
        
        


        public void StartExam()
        {
            Console.WriteLine("moin");
        }

        
        private bool ReturnStartTrue()
        {
            return collections != null;
        }

        private void getCategorys()
        {
            CategoryList = new CategoryViewModel[5];
            for (int i =0; i< CategoryList.Length; i++)  {
                CategoryList[i] = new CategoryViewModel();
                CategoryList[i].Name = "Moin" + i;
                CardCollectionViewModel[] coll = new CardCollectionViewModel[2];
                CategoryList[i].Collections = coll;
            }
            
            
        }

    }


}
