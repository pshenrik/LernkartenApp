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

        private Category examCategroy;
        private Card[] ExamCards;
        private float time;
        private int CardAmount;
        private float QuestionProgress;
        private float ExamProgress;
        private int wrongAnswers;
        private int correctAnswers;
        private bool examStarted;


        public ExamModeViewModel()
        {
            this.examCategroy = new Category();
            this.startExamCommand = new RelayCommand(this.StartExam, this.ReturnTrue);
            this.changeTimeCommand = new RelayCommand(this.SetTime, this.ReturnTrue);
        }

        public ExamModeViewModel(Category category)
        {
            this.examCategroy = category;

        }

        public float Time
        {
            get { return this.time; }
            set { this.time += value; }
        }

        private ICommand startExamCommand;
        private ICommand changeTimeCommand;
        public ICommand StartExamCommand { get { return startExamCommand; } }
        public ICommand ChangeTimeCommand { get { return changeTimeCommand; } }


        public void StartExam()
        {
            Console.WriteLine("moin");
        }

        public void SetTime()
        {

        }
        private bool ReturnTrue()
        {
            return examCategroy != null;
        }


    }


}
