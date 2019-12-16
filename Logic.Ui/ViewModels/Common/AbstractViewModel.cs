using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common
{
    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        // Base-Constructor with instantiate new Dictionary for PropertyMapping
        public AbstractViewModel()
        {
            this.PropertyMapping = new Dictionary<string, string>();
        }
        public Dictionary<String, String> PropertyMapping { get; set; }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // PropertyChangedHandler with Mapping for different-named Properties.
        public void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {   
            String propertyNameOut = "";
            if (this.PropertyMapping.TryGetValue(e.PropertyName, out propertyNameOut))
            {
                OnPropertyChanged(propertyNameOut);
            }
        }
       
    }




}

