using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using System.ComponentModel;

using System.Collections.Specialized;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Script.Serialization;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper
{
    
    public class SetViewModel : ObservableCollection<CategoryViewModel>
    {

        private Set set;
        private bool syncDisabled = false;
        public SetViewModel()
        {
            this.set = new Set();
            this.CollectionChanged += ViewModelCollectionChanged;
            this.set.CollectionChanged += ModelCollectionChanged;
        }
        public SetViewModel(Set set)
        {
            this.set = set;
            this.CollectionChanged += ViewModelCollectionChanged;
            if(set != null)
            {
                this.set.CollectionChanged += ModelCollectionChanged;
            }

           
        }
     
        public Set Set
        {
            get
            {
                return this.set;
            }
        }
        
        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var category in e.NewItems.OfType<CategoryViewModel>().Select(v => v.category).OfType<Category>())
                        set.Add(category);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var category in e.OldItems.OfType<CategoryViewModel>().Select(v => v.category).OfType<Category>())
                        set.Remove(category);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    set.Clear();
                    break;
            }
            syncDisabled = false;
            //storeSetOnDisc();
        }
        private void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var category in e.NewItems.OfType<Category>())
                        Add(new CategoryViewModel(category));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var category in e.OldItems.OfType<Category>())
                        Remove(GetViewModelOfModel(category));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    this.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private CategoryViewModel GetViewModelOfModel(Category category)
        {
            foreach (CategoryViewModel cat in this)
            {
                if (cat.category.Equals(category)) return cat;
            }
            return null;
        }


        /*private void storeSetOnDisc() {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(SetViewModel));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, Set);
                    xml = sww.ToString();
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(xml);
                    xdoc.Save("C:/tmp/SetCards.xml");
                }
            }
        }*/

        private void storeSetOnDisc()
        {
            var json = new JavaScriptSerializer().Serialize(Set);
            System.IO.File.WriteAllText(@"C:\tmp\SetCards.json", json);
            
            //XmlDocument xdoc = new XmlDocument();     
            //xdoc.Save("C:/tmp/SetCards.xml");
              
        }
      
    }
}
