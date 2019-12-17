using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    
    public class SetViewModel : ObservableCollection<CategoryViewModel>
    {

        private Set set;
        
        public SetViewModel()
        {
            this.set = new Set();
        }
        public SetViewModel(Set set)
        {
            this.set = set;
        }


        public Set Set
        {
            get
            {
                return this.set; 
            }
        }
        
    }
}
