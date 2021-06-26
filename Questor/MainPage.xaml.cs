using Questor.Choise;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Questor
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<int> students = new ObservableCollection<int>();

        private ObservableCollection<int> answered = new ObservableCollection<int>();

        RandomChoiser Choiser = new RandomChoiser();

        private int MaxCount = 0;

        public MainPage()
        {
            InitializeComponent();

            AnsweredList.ItemsSource = answered;


              
        }

        private void Button_Clicked(object sender, EventArgs e)
        {


            if (Repeats.IsChecked)
            {
                AnsweredList.IsVisible = true;
                Out.Text = $"{Choiser.NoRepeatlyChoise(students, answered)}";
            }
            else
            {
                AnsweredList.IsVisible = false;

                Out.Text = $"{Choiser.RepeatlyChoise(students)}";

            }
        }

        private void PersonCount_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
            if ((int)Math.Floor(PersonCount.Value) != MaxCount)
            {
                students.Clear();

                answered.Clear();

                for (int i = 1; i <= MaxCount + 1; i++)
                {
                    students.Add(i);
                }
            }
           
            MaxCount = (int)Math.Floor(PersonCount.Value);

            CountOfPerson.Text = $"{MaxCount} человек";

     
        }
    }
}
