using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ImportViewModel : AbstractViewModel

    {
        public ICommand ImportCommand { get; }
        public ICommand ExportCommand { get; }
        public String InsertedNameForXmlfile { get; set; }
        private SetViewModel Set;

        public ImportViewModel(SetViewModel set)
        {
            this.Set = set;
            ImportCommand = new RelayCommand(this.SelectXMlFile, this.GetBoolean);
            ExportCommand = new RelayCommand(this.Exportfunction, this.GetBoolean);

        }

        private void Exportfunction()
        {
            if (!String.IsNullOrEmpty(InsertedNameForXmlfile))
            {
                this.Message = "";
                try
                {
                    using (var fldrDlg = new FolderBrowserDialog())
                    {
                        if (fldrDlg.ShowDialog() == DialogResult.OK)
                        {
                            this.Message = "";
                            if (String.IsNullOrEmpty(fldrDlg.SelectedPath))
                            {
                                this.Message = "Bitte geben Sie Pfad ein: ";
                            }
                            else
                            {

                                String path = fldrDlg.SelectedPath + "\\" + InsertedNameForXmlfile + ".xml";
                                XmlTextWriter xmlWriter = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                                xmlWriter.Formatting = Formatting.Indented;
                                xmlWriter.WriteStartDocument();
                                xmlWriter.WriteComment("Creating an XML File.....");
                                xmlWriter.WriteStartElement("Categories");

                                foreach (CategoryViewModel category in Set)
                                {
                                    xmlWriter.WriteStartElement("Category");
                                    xmlWriter.WriteElementString("Name", category.Name);
                                    xmlWriter.WriteElementString("CreatedTime", category.CreatedTime);
                                    xmlWriter.WriteElementString("NumberOfCards", category.NumberOfCards.ToString());
                                    xmlWriter.WriteStartElement("Cards");
                                    for (var i = 0; i < category.Collections.Length; i++)
                                    {
                                        for (var j = 0; j < category.Collections[i].Count; j++)
                                        {
                                            xmlWriter.WriteStartElement("Card");
                                            xmlWriter.WriteElementString("Name", category.Collections[i][j].Name);
                                            xmlWriter.WriteElementString("CreatedTime", (category.Collections[i][j].Info.CreatedTime).ToString());
                                            xmlWriter.WriteElementString("CreatedTimeAsString", category.Collections[i][j].Info.CreatedTimeAsString);
                                            xmlWriter.WriteElementString("IsMarked", category.Collections[i][j].Info.Marked.ToString());
                                            xmlWriter.WriteElementString("LastlernedColor", category.Collections[i][j].Info.LastLearnedColor);
                                            xmlWriter.WriteElementString("LastLearnedTime", (category.Collections[i][j].Info.LastLearnedTime).ToString());
                                            xmlWriter.WriteElementString("LastTimeUsed", (category.Collections[i][j].Info.LastTimeUsed).ToString());
                                            xmlWriter.WriteStartElement("LearnHistory");
                                            foreach (bool Lh in category.Collections[i][j].Info.LearnHistory)
                                            {
                                                xmlWriter.WriteElementString("LH", Lh.ToString());
                                            }

                                            xmlWriter.WriteEndElement();
                                            xmlWriter.WriteElementString("Question", category.Collections[i][j].Front.Text);
                                            if (category.Collections[i][j].Front.Image != null)
                                            {
                                                byte[] bImage = BitmapSourceToByte(category.Collections[i][j].Front.Image);
                                                xmlWriter.WriteElementString("QuestionFoto", Convert.ToBase64String(bImage));
                                            }
                                            xmlWriter.WriteElementString("Answer", category.Collections[i][j].Back.Text);
                                            if (category.Collections[i][j].Back.Image != null)
                                            {
                                                byte[] bImage = BitmapSourceToByte(category.Collections[i][j].Back.Image);
                                                xmlWriter.WriteElementString("AnswerFoto", Convert.ToBase64String(bImage));
                                            }

                                            xmlWriter.WriteStartElement("KeyWords");
                                            foreach (String keyword in category.Collections[i][j].Keywords)
                                            {
                                                xmlWriter.WriteElementString("keyword", keyword);
                                            }

                                            xmlWriter.WriteEndElement();
                                            xmlWriter.WriteEndElement();
                                        }
                                    }

                                    xmlWriter.WriteEndElement();
                                    xmlWriter.WriteEndElement();
                                }
                                //xmlWriter.WriteEndElement();
                                xmlWriter.WriteEndDocument();
                                xmlWriter.Flush();
                                xmlWriter.Close();

                                this.Message = "Fertig!\n Pfad: " + path;


                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Message = "Zum Exportieren geben Sie bitte einen Dateinamen ein!";
            }
        }
        private String message;
        public String Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                OnPropertyChanged();
            }
        }

        public void ImportFunction(String path)
        {
            this.Set.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach (XmlElement Category in doc.GetElementsByTagName("Category"))
            {

                CategoryViewModel categoryObject = new CategoryViewModel();

                foreach (XmlNode categoryElements in Category)
                {


                    switch (categoryElements.Name)
                    {
                        case "Name":
                            categoryObject.Name = categoryElements.InnerText;
                            break;

                        case "CreatedTime":
                            categoryObject.CreatedTime = categoryElements.InnerText;
                            break;
                        case "NumberOfCards":
                            categoryObject.NumberOfCards = Convert.ToInt32(categoryElements.InnerText);
                            break;
                        case "Cards":

                            foreach (XmlElement Card in Category.GetElementsByTagName("Card"))
                            {
                                CardViewModel cardVM = new CardViewModel();

                                foreach (XmlNode node in Card)
                                {

                                    switch (node.Name)
                                    {
                                        case "Name":
                                            cardVM.Name = node.InnerText;
                                            break;

                                        case "CreatedTime":
                                            cardVM.Info.CreatedTime = Convert.ToInt64(node.InnerText);
                                            break;
                                        case "CreatedTimeAsString":
                                            cardVM.Info.CreatedTimeAsString = node.InnerText;
                                            break;

                                        case "IsMarked":
                                            cardVM.Info.Marked = Convert.ToBoolean(node.InnerText);
                                            break;
                                        case "LastlernedColor":
                                            cardVM.Info.LastLearnedColor = node.InnerText;
                                            break;
                                        case "Question":
                                            cardVM.Front.Text = node.InnerText;
                                            break;
                                        case "QuestionFoto":
                                            byte[] BytesFront = Convert.FromBase64String(node.InnerText);
                                            cardVM.Back.Image = ByteToBitmapSource(BytesFront);
                                            break;
                                        case "Answer":
                                            cardVM.Back.Text = node.InnerText;
                                            break;
                                        case "AnswerFoto":
                                            byte[] BytesBack = Convert.FromBase64String(node.InnerText);
                                            cardVM.Back.Image = ByteToBitmapSource(BytesBack);
                                            break;
                                        case "KeyWords":
                                            XmlNodeList keyWords = Card.GetElementsByTagName("keyword");

                                            foreach (XmlNode Kw in keyWords)
                                            {

                                                cardVM.Keywords.Add(Kw.InnerText);
                                            }

                                            break;
                                        case "LearnHistory":
                                            XmlNodeList learnHistory = Card.GetElementsByTagName("LH");

                                            foreach (XmlNode lH in learnHistory)
                                            {

                                                cardVM.Info.LearnHistory.Add(Convert.ToBoolean(lH.InnerText));
                                            }
                                            break;
                                        case "LastTimeUsed":
                                            cardVM.Info.LastTimeUsed = Convert.ToInt64(node.InnerText);
                                            break;
                                        case "LastLearnedTime":
                                            cardVM.Info.LastLearnedTime = Convert.ToInt64(node.InnerText);
                                            break;
                                        default:
                                            break;

                                    }
                                }
                                categoryObject.Collections[0].Add(cardVM);
                            }
                            break;
                        default:
                            break;
                    }
                }

                this.Set.Add(categoryObject);
            }

            this.Message = "Die Datei wurde importiert.";
        }

        private void SelectXMlFile()
        {
            this.Message = "";
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "XML Files (*.xml)|*.xml";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Message = dialog.FileName;

                    this.ImportFunction(dialog.FileName);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Hilfsmethode: Die Methode ByteToBitmapSource wandelt ein Byte-Array in eine Bitmap um
        private static System.Windows.Media.Imaging.BitmapSource ByteToBitmapSource(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            return System.Windows.Media.Imaging.BitmapFrame.Create(stream);
        }
        //Hilfsmethode: transferiert ein Foto (Bitmap) in ein Byte-Array
        private static byte[] BitmapSourceToByte(System.Windows.Media.Imaging.BitmapSource source)
        {
            var encoder = new System.Windows.Media.Imaging.JpegBitmapEncoder();
            var frame = System.Windows.Media.Imaging.BitmapFrame.Create(source);
            encoder.Frames.Add(frame);
            var stream = new MemoryStream();

            encoder.Save(stream);
            return stream.ToArray();
        }
        private bool GetBoolean()
        {
            return true;
        }

    }
}
