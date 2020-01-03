using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
   public class CreateCardViewModel : AbstractViewModel
    {
        
        public CardViewModel Card { get; set; }

        //relayCommand
        private ICommand createCardCommand;
        public ICommand CreateCardCommand { get { return createCardCommand; } }

        private ICommand addQuestionImgCommand;
        public ICommand AddQuestionImgCommand { get { return addQuestionImgCommand; } }

        private ICommand addAnswerImgCommand;
        public ICommand AddAnswerImgCommand { get { return addAnswerImgCommand; } }

        private ICommand addNewKeywordCommand;
        public ICommand AddNewKeywordCommand { get { return addNewKeywordCommand; } }

        private CategoryViewModel selectedCategory;
        public CategoryViewModel SelectedCategory
        {
            get
            {
                return this.selectedCategory;
            }
            set
            {
                this.selectedCategory = value;
                OnPropertyChanged();
            }
        }
        private SetViewModel set;
        public SetViewModel Set
        {
            get
            {
                return this.set;
            }
            set
            {
                this.set = value;
                OnPropertyChanged();
            }
        }

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

        private string checkAddNewCard= "";
        public string CheckAddNewCard
        {
            get
            {
                return this.checkAddNewCard;
            }
            set
            {
                this.checkAddNewCard = value;
                OnPropertyChanged();
            }
        }
        //keywords
        private ObservableCollection<String> keywords;
        public ObservableCollection<String> Keywords { 
            get{
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

        
        public CreateCardViewModel(SetViewModel set)
        {
            this.set = set;
            Card = new CardViewModel();
            Card.Name= "Überschrift";
            Card.Front.Text= "Frage eingeben";
            Card.Back.Text = "Antwort eingeben";
            //
            this.keywords = new ObservableCollection<String>();
            this.keywords.Add("hallo");
            this.keywords.Add("hi");
            this.newKeyword="Neues Wort";
            //relayCommand
            createCardCommand = new RelayCommand(this.CreateCard, this.ReturnTrue);

            addQuestionImgCommand = new RelayCommand(this.addQuestionImg, this.ReturnTrue);
            addAnswerImgCommand = new RelayCommand(this.addAnswerImg, this.ReturnTrue);

            addNewKeywordCommand = new RelayCommand(this.addNewKeyword, this.ReturnTrue);
        }

        private void CreateCard()
        {
           int categoryIndex= this.set.IndexOf(this.selectedCategory);
            if (categoryIndex<0 || categoryIndex>=this.set.Count)
            {
                this.CheckAddNewCard = "Karte wurde nicht erstellt(Eingaben überprüfen)";
            }
            else
            {
                Console.WriteLine(this.set[categoryIndex].Name);
                this.set[categoryIndex].Collections[0].Add(this.Card);
                Console.WriteLine(this.Card.Front.Text);
                this.CheckAddNewCard = "Karte wurde erfolgreich erstellt";
            }
            this.Card.Name = "Überschrift";
            this.Card.Front.Text = "Frage eingeben";
            this.Card.Back.Text = "Antwort eingeben";
            this.AnswerImgeLocation = "";
            this.QuesImgeLocation = "";

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
                    this.Card.Front.ImageSourece = this.QuesImgeLocation;
                    Console.WriteLine(this.Card.Back.ImageSourece);
                }
                
            }
            catch(Exception)
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
                    this.Card.Back.ImageSourece = this.AnswerImgeLocation;
                    Console.WriteLine(this.Card.Front.ImageSourece);
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
        private bool ReturnTrue()
        {
            return true;
        }
    }
}
