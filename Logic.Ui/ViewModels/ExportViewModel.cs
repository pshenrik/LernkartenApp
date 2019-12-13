using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using System.Windows.Input;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ExportViewModel : AbstractViewModel
    {
        private CategoryViewModel category;
        private ICommand testMethodeCommand;
            
        public ExportViewModel()
        {
            //this.category = category;

            testMethodeCommand = new RelayCommand(this.Test, this.ReturnTrue);
        }

        public ICommand TestMethodeCommand
        {
            get
            {
                return testMethodeCommand;
            }
        }
        public void Test()
        {
            Console.WriteLine("test");
        }

        private bool ReturnTrue()
        {
            return true;
        }
    }
}
