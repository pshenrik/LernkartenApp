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
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Runtime.InteropServices;

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

        private BitmapSource questionImage ;
        public BitmapSource QuestionImage
        {
            get
            {
                return this.questionImage;
            }
            set
            {
                this.questionImage = value;
                OnPropertyChanged();
            }
        }

        private BitmapSource answerImage;
        public BitmapSource AnswerImage
        {
            get
            {
                return this.answerImage;
            }
            set
            {
                this.answerImage = value;
                OnPropertyChanged();
            }
        }
   

        private string checkAddNewCard;
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

        private String newKeyword ;
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
            this.Card = new CardViewModel();
            this.Card.Name= "Überschrift";
            this.Card.Front.Text= "Frage eingeben";
            this.Card.Back.Text = "Antwort eingeben";

            this.newKeyword = "Neues Wort";
            checkAddNewCard = "";
            this.Card.Keywords.Add("Hallo");

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

                this.set[categoryIndex].Collections[0].Add(this.Card);
                this.CheckAddNewCard = "Karte wurde erfolgreich erstellt";
            }
            this.Card.Name = "Überschrift";
            this.Card.Front.Text = "Frage eingeben";
            this.Card.Back.Text = "Antwort eingeben";
            this.AnswerImage = null;
            this.QuestionImage = null;
        }

        private void addQuestionImg()
        {
            try
            {
                
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   // this.QuesImgeLocation = dialog.FileName;
                   // this.Card.Front.ImageSourece = this.QuesImgeLocation;
                    //Console.WriteLine(this.QuesImgeLocation);

                  Image newImage = Image.FromFile(dialog.FileName);
                    this.QuestionImage= GetImageStream(newImage);
                    this.Card.Front.Image = this.questionImage;
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
                    Image newImage = Image.FromFile(dialog.FileName);
                    this.AnswerImage= GetImageStream(newImage);
                    this.Card.Back.Image = this.answerImage;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Card.Keywords.Add(this.newKeyword);
            this.NewKeyword = "Neues Wort";
           // this.keywords.Add(this.newKeyword);
        }
        private bool ReturnTrue()
        {
            return true;
        }
    }
}
