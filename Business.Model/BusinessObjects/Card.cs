using System.ComponentModel;
namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Card : INotifyPropertyChanged
    {
        private string name;
        public Card (string name)
        {
            this.name = name;
            
        }
        public CardPage Front { get; }
        public CardPage Back { get; }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
