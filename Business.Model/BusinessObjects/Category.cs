﻿using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class Category : BusinessObject
    {
        //Max 5 collections
        public CardCollection[] Collections;
        //  private long createdTime;
        private String createdTime;
        
        /*   public long CreatedTime
           {
               get
               {
                   return this.createdTime;
               }
               set
               {
                   this.createdTime = value;
               }
           }*/
           public Category()
        {

        }
        public String CreatedTime
   {
       get
       {
           return this.createdTime;
       }
       set
       {
           this.createdTime = value;
       }
   }
        public int NumberOfCards
        {
            get
            {
                return Collections[0].Count + Collections[1].Count + Collections[2].Count + Collections[3].Count + Collections[4].Count;
            }
            set
            {
            }
        }


        public String Name { get; set; }
       
        public Category(String name)
        {
            // this.CreatedTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            this.CreatedTime = string.Format("{0: dd.MM.yyyy    hh:mm:ss}", DateTime.Now); 

            this.Name = name;
            this.Collections = new CardCollection[5];
            this.Collections[0] = new CardCollection();
            this.Collections[1] = new CardCollection();
            this.Collections[2] = new CardCollection();
            this.Collections[3] = new CardCollection();
            this.Collections[4] = new CardCollection();

        }

       
    }
}
