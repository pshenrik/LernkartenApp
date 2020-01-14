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

        private String categoryName;
        public String CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
                OnPropertyChanged();
            }
        }
        public CreateCategoryViewModel(SetViewModel set)
        {
            this.set = set;
            Category = new CategoryViewModel();
            this.categoryName = "Kategorienname eingeben";
            //relayCommand
            createCategoryCommand = new RelayCommand(this.CreateCategory, this.ReturnTrue);
        }

        private void CreateCategory()
        {
            this.Category.Name = this.categoryName;
            this.set.Add(this.Category);
            this.AddedSuccessful = "Kategorie "+Category.Name + " erfolgreich hizugefügt";
            this.CategoryName = "Kategorienname eingeben";
            this.Category = new CategoryViewModel();
        }
        private bool ReturnTrue()
        {
            return true;
        }

    }
}
