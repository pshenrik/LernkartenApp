using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ExammodeViewModel : AbstractViewModel
    {

        private Category examCategroy;
        private Card[] ExamCards;
        private float time;
        private int CardAmount;
        private float QuestionProgress;
        private float ExamProgress;
        private int wrongAnswers;
        private int correctAnswers;



        public ExammodeViewModel(Category category)
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

        private bool ReturnTrue()
        {
            return true;
        }


    }
}
