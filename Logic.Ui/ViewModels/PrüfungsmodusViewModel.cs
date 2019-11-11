using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class PrüfungsmodusViewModel
    {

        private Category examCategroy;
        private Card[] ExamCards;
        private float time;
        private int CardAmount;
        private float QuestionProgress;
        private float ExamProgress;
        private int wrongAnswers;
        private int correctAnswers;



        public PrüfungsmodusViewModel(Category category)
        {
            this.examCategroy = category;
        }
        public void setTime(float time)
        {
            this.time = time;
        }

        public int CorrectAnswers
        {
            get
            {
                return this.correctAnswers;
            }

        }

        public int WrongAnswers
        {
            get
            {
                return this.wrongAnswers;
            }
        }




    }
}
