﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace De.HsFlensburg.LernkartenApp001.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für CreateCategory.xaml
    /// </summary>
    public partial class CreateCategory : Window
    {
        public CreateCategory()
        {
            InitializeComponent();
        }

        public static implicit operator Form(CreateCategory v)
        {
            throw new NotImplementedException();
        }
    }
}
