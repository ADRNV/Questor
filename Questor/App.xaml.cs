using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Questor
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new MainPage();

            this.InitializeComponent();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep() 
        {
        }

        protected override void OnResume()
        {
        }
    }
}
