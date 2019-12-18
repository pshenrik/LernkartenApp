using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
   public class CreateCardViewModel : AbstractViewModel
    {
        
        public CardCollectionViewModel Cards { get; set; }
        public CardViewModel Card { get; set; }
        public CardPageViewModel Front { get; set; }
        public CardPageViewModel Back { get; set; }

        //relayCommand
        private ICommand createCardCommand;
        public ICommand CreateCardCommand { get { return createCardCommand; } }

        private ICommand addQuestionImgCommand;
        public ICommand AddQuestionImgCommand { get { return addQuestionImgCommand; } }

        private ICommand addAnswerImgCommand;
        public ICommand AddAnswerImgCommand { get { return addAnswerImgCommand; } }
        public CreateCardViewModel()
        {

            Card = new CardViewModel("");

            Front = new CardPageViewModel();
            Back = new CardPageViewModel();
            Front.Text = "Frage eingeben";
            Back.Text = "Antwort eingeben";

            Card.Front.Text = Front.Text;
            Card.Back.Text = Back.Text;
            Card.Name = "Überschrift";

            //relayCommand
           createCardCommand = new RelayCommand(this.CreateCard, this.ReturnTrue);

           addQuestionImgCommand = new RelayCommand(this.addQuestionImg, this.ReturnTrue);

           addAnswerImgCommand = new RelayCommand(this.addAnswerImg, this.ReturnTrue);
        }

        public CreateCardViewModel(SetViewModel set)
        {

        }

        private void CreateCard()
        {
            Card.Front.Text = Front.Text;
            Card.Back.Text = Back.Text;
            Console.WriteLine(Card.Front.Text);

           // this.Cards.Add(this.Card);

        }

        private void addQuestionImg()
        {
            Console.WriteLine("Frage");
        }
        private void addAnswerImg()
        {
            Console.WriteLine("Antwort");
        }
        private bool ReturnTrue()
        {
            return true;
        }
    }
}
