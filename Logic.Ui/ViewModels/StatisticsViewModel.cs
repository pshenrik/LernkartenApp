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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class StatisticsViewModel : AbstractViewModel
    {
        public SetViewModel Set { get; set; }

        public StatisticsViewModel(SetViewModel Set)
        {
            this.Set = Set;
            this.canvas = new Canvas();
        }

        public CategoryViewModel category;
        public CategoryViewModel Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                OnPropertyChanged();
                drawCanvas();
            }
        }

        private Canvas canvas;
        public Canvas Canvas { get { return this.canvas; } set { this.canvas = value; } }

        public string Width = "200";
        public string Height = "200";
        public string X = "0";
        public string Y = "0";

        private ObservableCollection<CardInfoViewModel> cardInfo;
        public ObservableCollection<CardInfoViewModel> CardInfo {
            get { return cardInfo; }
            set { CardInfo = value; }
        }

        private void drawCanvas() {
            Console.WriteLine(category.Collections);

            Rectangle rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.Black);
            rect.Width = 200;
            rect.Height = 200;

            //Canvas.Add(rect);
            //Canvas.SetTop(rect, 0);
            Canvas.SetTop(rect, 0);
            Canvas.SetLeft(rect, 0);
            Canvas.Children.Add(rect);

            for (int i = 0; i < category.Collections.Length; i++) {
                for (int j = 0; j < category.Collections[i].cards.Count; j++)
                {
                    CardInfo info = category.Collections[i].cards[j].Info;
                    Console.WriteLine(info.LastLearnedColor);
                }
            }
        }
    }
}
