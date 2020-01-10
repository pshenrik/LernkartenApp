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

        // Wird nur in View_Cartegory angezeigt. 
        public String CreatedTimeAsString
        {
            get
            {
                return info.CreatedTimeAsString; 
            }
        }
        #endregion

        #region Lernmodus Properties
        public ObservableCollection<bool> LearnHistory
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

        #region ExamModeProperties

        public long LastTimeUsed
        {
            get
            {
                return this.info.LastTimeUsed;
            }
            set
            {
                this.info.LastTimeUsed = value;
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
