using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Ui.Desktop.ServiceBusLogic
{
    class MassageListener
    {
        public MassageListener()
        {
          //  InitMessenger();
        }

        #region methods
        /*
        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenStatisticsWindowMessage>(
                this,
                msg =>
                {
                    StatisticsWindow window = new StatisticsWindow();
                    window.Show();
                });
        }*/


        #endregion

        #region properties

        //  Damit diese Property gebindet werden kann, muss zunächst 
        //  diese Klasse als Static Resource der App.xaml hinzugefügt werden:

        //<Application.Resources>
        //<desktop:MessageListener x:Key="MessageListener">
        //</desktop:MessageListener>
        //</Application.Resources>
        //</Application>

        // Dann muss nur noch die Property an die IsEnabled-Eigenschaft gebindet werden,
        // damit eine Instanz von dieser Klasse erzeugt wird:

        //  <Window.IsEnabled>
        //          <Binding Source = "{StaticResource MessageListener}" Path="BindableProperty"></Binding>
        //  </Window.IsEnabled>

        // Und nur dafür ist diese Property... :
        public bool BindableProperty => true;

        #endregion
    }

}

