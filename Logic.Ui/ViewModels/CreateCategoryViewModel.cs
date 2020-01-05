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
     
        private SetViewModel set;
        private String addedSuccessful = "";
        public String AddedSuccessful
        {
            get
            {
                return addedSuccessful;
            }
            set
            {
                addedSuccessful = value;
                OnPropertyChanged();
            }
        }
        public CreateCategoryViewModel(SetViewModel set)
        {
            this.set = set;
            Category = new CategoryViewModel();
            Category.Name = "Kategorienname eingeben";
            //relayCommand
            createCategoryCommand = new RelayCommand(this.CreateCategory, this.ReturnTrue);
        }

        private void CreateCategory()
        {
            this.set.Add(this.Category);
            AddedSuccessful = Category.Name + " erfolgreich hizugefügt";
            Console.WriteLine(Category.Name);
            Category.Name = "Kategorienname eingeben";
        }
        private bool ReturnTrue()
        {
            return true;
        }

    }
}
