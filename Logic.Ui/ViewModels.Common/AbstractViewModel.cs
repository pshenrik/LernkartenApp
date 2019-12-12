using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common
{
    public  abstract class AbstractViewModel : INotifyPropertyChanged
    {
        
      /*  public AbstractViewModel()
        {
            this.PropertyMapping = new Dictionary<string, string>();
        }
        public Dictionary<String, String> PropertyMapping { get; set; }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            String propertyNameOut = "";
            if(this.PropertyMapping.TryGetValue(e.PropertyName, out propertyNameOut))
            {
                OnPropertyChanged(propertyNameOut);
            }
        }*/
    }
}
