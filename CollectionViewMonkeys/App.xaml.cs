﻿using CollectionViewMonkeys.Views;

namespace CollectionViewMonkeys
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            MainPage = new MonkeysCollectionView();
        }
    }
}