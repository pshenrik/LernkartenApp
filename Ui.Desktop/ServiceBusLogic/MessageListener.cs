﻿using System;
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
                    MainMenu mainmenu = new MainMenu();
                    mainmenu.Show();
                    
                });

            ServiceBus.Instance.Register<OpenStatisticsWindow>(
               this,
               msg =>
               {
                   Statistics statWindow = new Statistics();
                   statWindow.Show();
                   
               });
            
            ServiceBus.Instance.Register<OpenViewCategoryWindow>(
               this,
               msg =>
               {
                   Category category = new Category();
                   category.Show();

               });

            ServiceBus.Instance.Register<OpenExamModeWindow>(
               this,
               msg =>
               {
                   Prüfungsmodus examMode = new Prüfungsmodus();
                   examMode.Show();
                   
               });

            ServiceBus.Instance.Register<OpenLearnModeWindow>(
               this,
               msg =>
               {
                   LearnMode learnmode = new LearnMode();
                   
                   learnmode.Show();

               });
            ServiceBus.Instance.Register<OpenExportWindow>(
               this,
               msg =>
               {
                   Export export = new Export();
                   export.Show();

               });
            ServiceBus.Instance.Register<OpenViewMarkedCardsWindow>(
                this,
                msg =>
                {
                    ViewMarkedCards vmc = new ViewMarkedCards();
                    vmc.Show();
                }

                );

            ServiceBus.Instance.Register<OpenCreateCardWindow>(
             this,
             msg =>
             {
                 CreateCard createCardWindow = new CreateCard();
                 createCardWindow.Show();

             });
            ServiceBus.Instance.Register<OpenEditCardWindow>(
             this,
             msg =>
             {
                 EditCard editCard = new EditCard();
                 editCard.Show();

             });

            ServiceBus.Instance.Register<OpenImportWindow>(
            this,
            msg =>
            {
                ImportExportXML importExportxml = new ImportExportXML();
                importExportxml.Show();

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

