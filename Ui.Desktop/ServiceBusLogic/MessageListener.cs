using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Messages;
using De.HsFlensburg.LernkartenApp001.Services.ServiceBus;

namespace De.HsFlensburg.LernkartenApp001.Ui.Desktop.ServiceBusLogic
{
    public class MessageListener
    {
        public MessageListener()
        {
            InitMessenger();
        }

        #region methods

        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenMainMenuWindow>(
                this,
                msg =>
                {
                    Window1 mainmenu = new Window1();
                    mainmenu.Show();
                });
        }


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

