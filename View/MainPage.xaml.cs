﻿using Ksiegowosc.ViewModel;

namespace Ksiegowosc.View;

public partial class MainPage : ContentPage
{
   
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}