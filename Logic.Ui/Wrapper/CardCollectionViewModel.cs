
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardCollectionViewModel : ObservableCollection<CardViewModel>
    {
        public CardCollection cards;
        private bool syncDisabled = false;

        public CardCollectionViewModel()
        {
            cards = new CardCollection();

            this.CollectionChanged += ViewModelCollectionChanged;
            cards.CollectionChanged += ModelCollectionChanged;
        }
        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var card in e.NewItems.OfType<CardViewModel>().Select(v => v.Card).OfType<Card>())
                        cards.Add(card);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var card in e.OldItems.OfType<CardViewModel>().Select(v => v.Card).OfType<Card>())
                        cards.Remove(card);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    cards.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var card in e.NewItems.OfType<Card>())
                        Add(new CardViewModel(card));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var card in e.OldItems.OfType<Card>())
                        Remove(GetViewModelOfModel(card));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    this.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private CardViewModel GetViewModelOfModel(Card card)
        {
            foreach (CardViewModel cvm in this)
            {
                if (cvm.Card.Equals(card)) return cvm;
            }
            return null;
        }
    }
}

