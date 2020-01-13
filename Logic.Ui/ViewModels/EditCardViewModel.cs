using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class EditCardViewModel : AbstractViewModel
    {
        #region ICommands
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
        #endregion

        private string checkEditedCard;
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


        private String newKeyword;
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

        private String selectedStack;
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
            Card = new CardViewModel();
            Card.Name = "Keine Ahnung";
            Card.Front.Text = "Irgendwas hieeer";
            Card.Back.Text = "Irgendwas dooort";

            this.set = set;
            this.QuestionVisibility = "Visible";
            this.AnswerVisibility = "Hidden";

            checkEditedCard = "";
            this.newKeyword = "Neues Wort";
            selectedStack = "";
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
                    Image newImage = Image.FromFile(dialog.FileName);
                    Card.Front.Image = GetImageStream(newImage);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Image newImage = Image.FromFile(dialog.FileName);
                    Card.Back.Image = GetImageStream(newImage);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static BitmapSource GetImageStream(Image myImage)
        {
            var bitmap = new Bitmap(myImage);
            IntPtr bmpPt = bitmap.GetHbitmap();
            BitmapSource bitmapSource =
             System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bmpPt,
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());

            //freeze bitmapSource and clear memory to avoid memory leaks
            bitmapSource.Freeze();
            DeleteObject(bmpPt);

            return bitmapSource;
        }

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr value);

        private void addNewKeyword()
        {
           Card.Keywords.Add(this.newKeyword);
           this.NewKeyword = "Neues Wort";
        }
        private void removeKeyword()
        {
            Card.Keywords.Remove(this.selectedKeyword);
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
            
            //finde Kategorie dieser Karte 
            int indexOfStackInCategory =0;
            int indexOfCategory = 0;
            //findCard ist die übergebene Karte vom MainManu
            //CardViewModel findCard = this.set[2].Collections[0][1];

            for (int i=0; i<this.set.Count;i++)
            {
           
                    for (int j = 0; j < 5; j++)
                    {
                        foreach (CardViewModel card in this.set[i].Collections[j])
                        {
                             if (card.Equals(Card))
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
                this.set[indexOfCategory].Collections[indexOfSelectedStack].Add(Card);
                this.set[indexOfCategory].Collections[indexOfStackInCategory].Remove(Card);
            }
   
        }
        
        private bool ReturnTrue()
        {
            return true;
        }
    }
}
