﻿namespace kpazminoAS6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Views.vEstudiante());
        }
    }
}
