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
using System.Windows.Documents;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class StatisticsViewModel : AbstractViewModel
    {

        public StatisticsViewModel(SetViewModel Set)
        {
            this.Set = Set;
            this.canvasDyn = new Canvas();
            this.canvasStat = new Canvas();

            int sum = 1;
            int[] count = new int[5];
            var arSet = Set.ToList();
            for (int k = 0; k < arSet.Count(); k++) { 
                for (int i = 0; i < arSet[k].Collections.Length; i++){
                    for (int j = 0; j < arSet[k].Collections[i].cards.Count; j++){
                        CardInfo info = arSet[k].Collections[i].cards[j].Info;
                        count[i]++;
                        sum++;
                    }
                }
            }

            drawCanvas(this.canvasStat, count, sum);
        }

        public SetViewModel Set { get; set; }

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

                int[] count = new int[5];
                int sum = 1;
                for (int i = 0; i < category.Collections.Length; i++){
                    for (int j = 0; j < category.Collections[i].cards.Count; j++){
                        count[i]++;
                        sum++;
                    }
                }

                drawCanvas(canvasDyn, count, sum);
            }
        }

        private Canvas canvasStat;
        private Canvas canvasDyn;
        public Canvas CanvasStat { get { return this.canvasStat; } set { this.canvasStat = value; } }
        public Canvas CanvasDyn { get { return this.canvasDyn; } set { this.canvasDyn = value; } }

        private int cWidth = 350;
        private int cHeight = 200;
        private int offset = 5;

        /*
        *   drawCanvas leert das übergebene Canvas und füllt es mit 
        *   anzahl balken (sum) und den dazu passenden werten aus dem
        *   array (count)
        */
        private void drawCanvas(Canvas can, int[] count, int sum) {
            can.Children.Clear();
            int rectWidth = (this.cWidth - (count.Length * this.offset)) / count.Length;

            for (int i = 0; i < count.Length; i++)
            {
                Console.WriteLine(this.cHeight / sum * count[i]);
                Rectangle rect = new Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.LightBlue);
                rect.Fill = new SolidColorBrush(Colors.LightBlue);
                rect.Width = rectWidth;
                rect.Height = this.cHeight / sum * count[i];

                Canvas.SetTop(rect, cHeight - rect.Height);
                Canvas.SetLeft(rect, i*(rectWidth + this.offset));
                can.Children.Add(rect);
            }
        }
    }
}
