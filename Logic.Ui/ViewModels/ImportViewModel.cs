using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ImportViewModel: AbstractViewModel

    {
        public ICommand ImportCommand { get; }
        public String InsertedPath { get; set; }
        private SetViewModel set; 

        public ImportViewModel(SetViewModel set)
        {
            this.set = set;
            ImportCommand = new RelayCommand(this.Importfunction, this.GetBoolean);
        }

        private void Importfunction()
        {
            this.Message = ""; 
            if(this.InsertedPath == null)
            {
                this.Message = "Bitte geben Sie Pfad ein: ";
            }
            else
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(InsertedPath, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteComment("Creating an XML File.....");
                xmlWriter.WriteStartElement("Categories"); 

                foreach (CategoryViewModel category in set)
                {
                    xmlWriter.WriteStartElement("Category");
                    xmlWriter.WriteElementString("Name", category.Name);
                    xmlWriter.WriteElementString("Created Time", category.CreatedTime);
                    xmlWriter.WriteElementString("Number of Cards", category.NumberOfCards.ToString());
                    xmlWriter.WriteStartElement("Cards");
                    for (var i = 0; i < category.Collections.Length; i++)
                    {
                        for (var j = 0; j < category.Collections[i].Count; j++)
                        {
                            //Cards.Add(category.Collections[i][j]);
                            // Console.WriteLine(category.Collections[i][j].Info.CreatedTime);
                            xmlWriter.WriteStartElement("Card");
                            xmlWriter.WriteElementString("Name", category.Collections[i][j].Name);
                            xmlWriter.WriteElementString("Created Time", category.Collections[i][j].Info.CreatedTimeAsString);
                            xmlWriter.WriteElementString("Is Marked", category.Collections[i][j].Info.Marked.ToString());
                            xmlWriter.WriteElementString("Last lerned Color", category.Collections[i][j].Info.LastLearnedColor);
                            xmlWriter.WriteElementString("Question", category.Collections[i][j].Front.Text);
                            xmlWriter.WriteElementString("Answer", category.Collections[i][j].Back.Text);
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

                this.Message = "Fertig!\n Pfad: " + this.InsertedPath; 
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

        private bool GetBoolean()
        {
            return true;
        }

    }
}
