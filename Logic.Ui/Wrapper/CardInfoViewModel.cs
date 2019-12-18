using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    public class CardInfoViewModel : AbstractViewModel
    {
        private CardInfo info;
        #region General Properties
        public bool Marked
        {
            get
            {
                return info.Marked;
            }
            set
            {
                info.Marked = value;
                OnPropertyChanged();
            }
        }

        public long CreatedTime
        {
            get
            {
                return info.CreatedTime;
            }
            set
            {
                info.CreatedTime = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Lernmodus Properties
        public ObservableCollection<int> LearnHistory
        {
            get
            {
                return info.LearnHistory;
            }
            set
            {
                info.LearnHistory = value;
                OnPropertyChanged();
            }
        }

        public string LastLearnedColor
        {
            get
            {
                return info.LastLearnedColor;
            }
        }

        public long LastLearnedTime
        {
            get
            {
                return info.LastLearnedTime;
            }
            set
            {
                info.LastLearnedTime = value;
                OnPropertyChanged();
            }
        }

    


        #endregion
        public CardInfoViewModel(CardInfo info)
        {
            this.info = info;
        }

        public CardInfoViewModel()
        {
            this.info = new CardInfo();
        }


    }
}
