using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class EditCardViewModel : AbstractViewModel
    {

        //relayCommand
        private ICommand editedCardCommand;
        public ICommand EditedCardCommand { get { return editedCardCommand; } }

        private ICommand addQuestionImgCommand;
        public ICommand AddQuestionImgCommand { get { return addQuestionImgCommand; } }

        private ICommand addAnswerImgCommand;
        public ICommand AddAnswerImgCommand { get { return addAnswerImgCommand; } }

        private ICommand addNewKeywordCommand;
        public ICommand AddNewKeywordCommand { get { return addNewKeywordCommand; } }

        private ICommand removeKeywordCommand;
        public ICommand RemoveKeywordCommand { get { return removeKeywordCommand; } }
        
        private ICommand flipCardCommand;
        public ICommand FlipCardCommand { get { return flipCardCommand; } }
        
        private ICommand moveCardCommand;
        public ICommand MoveCardCommand { get { return moveCardCommand; } }


        public String quesImgeLocation = "";
        public String QuesImgeLocation
        {
            get
            {
                return this.quesImgeLocation;
            }
            set
            {
                this.quesImgeLocation = value;
                OnPropertyChanged();
            }
        }

        public String answerImgeLocation = "";
        public String AnswerImgeLocation
        {
            get
            {
                return this.answerImgeLocation;
            }
            set
            {
                this.answerImgeLocation = value;
                OnPropertyChanged();
            }
        }

        private string checkEditedCard = "";
        public string CheckEditedCard
        {
            get
            {
                return this.checkEditedCard;
            }
            set
            {
                this.checkEditedCard = value;
                OnPropertyChanged();
            }
        }
        //keywords
        private ObservableCollection<String> keywords;
        public ObservableCollection<String> Keywords
        {
            get
            {
                return this.keywords;
            }
            set
            {
                this.keywords = value;
                OnPropertyChanged();
            }
        }

        private String newKeyword = "";
        public String NewKeyword
        {
            get
            {
                return this.newKeyword;
            }
            set
            {
                this.newKeyword = value;
                OnPropertyChanged();
            }
        }
        private String selectedKeyword = "";
        public String SelectedKeyword
        {
            get
            {
                return this.selectedKeyword;
            }
            set
            {
                this.selectedKeyword = value;
                OnPropertyChanged();
            }
        }

        private String answerVisibility = "";
        public String AnswerVisibility
        {
            get
            {
                return this.answerVisibility;
            }
            set
            {
                this.answerVisibility = value;
                OnPropertyChanged();
            }
        }

        private String questionVisibility = "";
        public String QuestionVisibility
        {
            get
            {
                return this.questionVisibility;
            }
            set
            {
                this.questionVisibility = value;
                OnPropertyChanged();
            }
        }

        //stacks
        private ObservableCollection<String> stacks;
        public ObservableCollection<String> Stacks
        {
            get
            {
                return this.stacks;
            }
            set
            {
                this.stacks = value;
                OnPropertyChanged();
            }
        }

        private String selectedStack = "";
        public String SelectedStack
        {
            get
            {
                return this.selectedStack;
            }
            set
            {
                this.selectedStack = value;
                OnPropertyChanged();
            }
        }
        public static CardViewModel Card { get; set; }
        private SetViewModel set;
        public EditCardViewModel(SetViewModel set)
        {
            //  this.Card = set.CARD;
           Card = new CardViewModel();
            Card.Name = "Keine Ahnung";
            Card.Front.Text = "Irgendwas hieeer";
           Card.Back.Text = "Irgendwas dooort";
            this.QuesImgeLocation = "C:\\Users\\Khaled\\Desktop\\Bilder\\images (4).jpg";
            this.AnswerImgeLocation= "C:\\Users\\Khaled\\Desktop\\Bilder\\images (2).jpg";
            Console.WriteLine(this.AnswerImgeLocation);
            //
            this.set = set;
            this.QuestionVisibility = "Visible";
            this.AnswerVisibility = "Hidden";
            //
            this.keywords = new ObservableCollection<String>();
            this.keywords.Add("hallo");
            this.keywords.Add("hi");
            this.newKeyword = "Neues Wort";
            //stacks
            this.stacks = new ObservableCollection<String>();
            this.stacks.Add("Erster Stapel");
            this.stacks.Add("Zweiter Stapel");
            this.stacks.Add("Dritter Stapel");
            this.stacks.Add("Vierter Stapel");
            this.stacks.Add("Fünfter Stapel");
            //relayCommand
            editedCardCommand = new RelayCommand(this.editedCard, this.ReturnTrue);

            addQuestionImgCommand = new RelayCommand(this.addQuestionImg, this.ReturnTrue);
            addAnswerImgCommand = new RelayCommand(this.addAnswerImg, this.ReturnTrue);

            addNewKeywordCommand = new RelayCommand(this.addNewKeyword, this.ReturnTrue);
            removeKeywordCommand = new RelayCommand(this.removeKeyword, this.ReturnTrue);

            moveCardCommand = new RelayCommand(this.moveCard, this.ReturnTrue);
            flipCardCommand = new RelayCommand(this.flipCard, this.ReturnTrue);
        }


        private void editedCard()
        {
            this.CheckEditedCard = "Karte wurde aktualisiert";
        }

        private void addQuestionImg()
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.QuesImgeLocation = dialog.FileName;
                   Card.Front.ImageSourece = this.QuesImgeLocation;
                    Console.WriteLine(Card.Back.ImageSourece);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void addAnswerImg()
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.AnswerImgeLocation = dialog.FileName;
                    Card.Back.ImageSourece = this.AnswerImgeLocation;
                    Console.WriteLine(Card.Front.ImageSourece);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void addNewKeyword()
        {
            this.keywords.Add(this.newKeyword);
        }
        private void removeKeyword()
        {
            this.keywords.Remove(this.selectedKeyword);
        }
        private void flipCard()
        {
            if (this.QuestionVisibility == "Visible")
            {
                this.QuestionVisibility = "Hidden";
                this.AnswerVisibility = "Visible";
            }
            else
            {
                this.QuestionVisibility = "Visible";
                this.AnswerVisibility = "Hidden";
            }
        }

        private void moveCard()
        {
            int indexOfSelectedStack = this.stacks.IndexOf(this.selectedStack);
            Console.WriteLine(indexOfSelectedStack);
           
            //finde Kategorie dieser Karte 
            int indexOfStackInCategory =0;
            int indexOfCategory = 0;
            //findCard ist die übergebene Karte vom MainManu
            CardViewModel findCard = this.set[2].Collections[0][1];

            for (int i=0; i<this.set.Count;i++)
            {
           
                    for (int j = 0; j < 5; j++)
                    {
                        foreach (CardViewModel card in this.set[i].Collections[j])
                        {
                             if (card.Equals(findCard))
                             {
                            indexOfCategory = i;
                            indexOfStackInCategory = j;
                        }
                        else
                        {
                            indexOfCategory = -1;
                            indexOfStackInCategory = -1;
                        }
                        }                        
                    }      
            }

            if (indexOfCategory!=-1)
            {
                this.set[indexOfCategory].Collections[indexOfSelectedStack].Add(findCard);
                this.set[indexOfCategory].Collections[indexOfStackInCategory].Remove(findCard);
            }
   
        }
        
        private bool ReturnTrue()
        {
            return true;
        }
    }
}
