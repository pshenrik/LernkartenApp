using System;
using System.Collections.Generic;
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
     */
    public class LernmodusViewModel : AbstractViewModel
    {
        private ICommand submitAnswerCommand;
        private ICommand cancelTrainingCommand;
        private ICommand markCardCommand;
        private ICommand requestHelpCommand;
        public ICommand SubmitAnswerCommand { get { return submitAnswerCommand; } }
        public ICommand CancelTrainingCommand { get { return cancelTrainingCommand; } }
        public ICommand MarkCardCommand { get { return markCardCommand; } }
        public ICommand RequestHelpCommand { get { return requestHelpCommand; } }

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
            }
        }

        public int learnedCardsCounter = 0;
        public int LearnedCardsCounter
        {
            get
            {
                return learnedCardsCounter;
            }
            set
            {
                learnedCardsCounter = value;
            }
        }







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
            learnedCardsCounter++;
        }

        private void CancelTraining()
        {
            Console.WriteLine("cancel");
        }

        private void MarkCard()
        {
            Console.WriteLine("mark");
        }

        private void RequestHelp()
        {
            Console.WriteLine("help");
        }

        private bool ReturnTrue()
        {
            return true;
        }

    }


}
