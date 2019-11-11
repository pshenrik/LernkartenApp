using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    class CreateCategoryViewModel
    {
        CategoryWrapper Category { get; set; }

        public CreateCategoryViewModel()
        {
            Category = new CategoryWrapper();
            Category.Name = "Kategorienname Eingeben";
        }


        //private void ChangeModel()
        //{
        //  this.Category.category.Name = this.Category.category.Name + "-Diff-";
        //}
       


    }
}
