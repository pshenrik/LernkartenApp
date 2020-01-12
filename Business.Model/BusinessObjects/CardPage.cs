using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using De.HsFlensburg.LernkartenApp001.Business.Model.Common;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects
{
    public class CardPage : BusinessObject
    {   
        public String Text { get; set; }
        public BitmapSource Image { get; set; }



    }
}
