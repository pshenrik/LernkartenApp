using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using System.Windows.Input;
using De.HsFlensburg.LernkartenApp001.Services.ServiceBus;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Messages;


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class StatisticsViewModel : AbstractViewModel
    {
        private bool enableSetting;
        public CategoryViewModel[] CategoryList { get; set; }
        public StatisticsViewModel()
        {
            getCategorys();
            this.EnableSettings = true;
        }

        public StatisticsViewModel(SetViewModel Set)
        {
        }

        public bool EnableSettings
        {
            get
            {
                return this.enableSetting;
            }
            set
            {
                this.enableSetting = value;
                OnPropertyChanged();
            }
        }

        private CardCollectionViewModel coll;
        private CardCollectionViewModel[] cols;
        private void getCategorys()
        {
            CategoryList = new CategoryViewModel[20];
            for (int i = 0; i < CategoryList.Length; i++)
            {
                CategoryList[i] = new CategoryViewModel();
                CategoryList[i].Name = "Category " + (i + 1);
                cols = new CardCollectionViewModel[1];
                coll = new CardCollectionViewModel();
                for (int j = 0; j < i * 2; j++)
                {
                    coll.Add(new CardViewModel("test"));

                }
                cols[0] = coll;
                CategoryList[i].Collections = cols;
            }
            if (CategoryList.Length < 1) 
            {
                this.EnableSettings = false;
            }


        }
    }
}
