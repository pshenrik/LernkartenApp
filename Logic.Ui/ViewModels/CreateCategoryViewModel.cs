using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class CreateCategoryViewModel : AbstractViewModel
    {
        //public CategoryCollectionViewModel Categorys { get; set; }
        public CategoryViewModel Category { get; set; }

        //relayCommand
        private ICommand createCategoryCommand;
        public ICommand CreateCategoryCommand { get { return createCategoryCommand; } }
     
        public CreateCategoryViewModel()
        {
            Category = new CategoryViewModel();
            Category.Name = "Kategorienname Eingeben";

            //relayCommand
            createCategoryCommand = new RelayCommand(this.CreateCategory, this.ReturnTrue);
        }

        public CreateCategoryViewModel(SetViewModel set)
        {

        }

        //private void ChangeModel()
        //{
        //  this.Category.category.Name = this.Category.category.Name + "-Diff-";
        //}

        private void CreateCategory()
        {
            //CategoryCollection fehlt

            Console.WriteLine(Category.Name);
        }
        private bool ReturnTrue()
        {
            return true;
        }

    }
}
