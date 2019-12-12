using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
   public class CreateCardViewModel
    {
        
        public CardPageWrapper CardPageQuestion { set; get; }
        public CardPageWrapper CardPageAnswer { set; get; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public CardCollectionWrapper cards;

        
        //CardWrapper card;

        public CreateCardViewModel()
        {
            CardPageQuestion = new CardPageWrapper();
            CardPageAnswer = new CardPageWrapper();
            CardPageQuestion.Text = "Farge Eingeben";
            CardPageAnswer.Text = "Antwort Eingeben";

            //card = new CardWrapper();
            //card.Front = cardPage.page;
        }



        public void CreateCard()
        {
            //CardWrapper newCardVM = new CardWrapper();
            //newCardVM.Back.Text = Question;
            //newCardVM.Front.Text = Answer;
            //cards.Add(newCardVM);

            CardWrapper newCardVM = new CardWrapper();
            //newCardVM.Front = CardPageQuestion.Text;
            //newCardVM.= CardPageAnswer.n
            //newCardVM.Back = CardPageAnswer.Text;


        }
    }
}
