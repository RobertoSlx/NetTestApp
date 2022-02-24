﻿using AppTest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views.Preferences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrefLearnPage : ContentPage
    {
        public PrefLearnPage()
        {
            InitializeComponent();
            BindingContext = new PrefLearnPage_VM(); // Binding el Viewmodel
        }
    }
}