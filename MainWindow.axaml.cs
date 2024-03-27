using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Tmds.DBus.Protocol;
using Avalonia.Media;
using System.Linq;

namespace phoneNumber
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SliderNumber.PointerMoved += changeSliderValue;

            ComboBox combobox = MyComboBox;
            for (int i = 0; i < 1000; i++)
            {
                combobox.Items.Add(i.ToString());
            }
            ComboBox combobox2 = MyComboBox2;
            for (int i = 0; i < 1000; i++)
            {
                combobox2.Items.Add(i.ToString());
            }
            ComboBox combobox3 = MyComboBox3;
            for (int i = 0; i < 10000; i++)
            {
                combobox3.Items.Add(i.ToString());
            }
        }

        public void ClickPlus(object? sender, RoutedEventArgs args)
        {
            string s = Input.Text;

            long inputNumbers = 0;

            string[] numbers = s.Split('+', '_');

            foreach (string numString in numbers)
            {
                foreach (char c in numString)
                {
                    inputNumbers = inputNumbers * 10 + (c - '0');
                }
            }
            inputNumbers++;

            Input.Text = inputNumbers.ToString();



        }
        public void RandomClick(object? sender, RoutedEventArgs args)
        {
            Random numberRandom = new();

            long inputNumbers = numberRandom.NextInt64(0, 100000000000);
            Input.Text = inputNumbers.ToString();
        }

        public void NextOutputClick(object? sender, RoutedEventArgs args)
        {
           
            string first = MyComboBox.SelectedItem.ToString();
            string second = MyComboBox2.SelectedItem.ToString();
            string third = MyComboBox3.SelectedItem.ToString();

            

            string result = first + second + third;
           
            
           
            comboboxMessage.Text = $"Your phone number is +{result}";

        }
        public void changeSliderValue(object? sender, RoutedEventArgs args)
        {
            SliderNumber.Value = Math.Round(SliderNumber.Value, 0);

        }
        public void SliderOutputClick(object? sender, RoutedEventArgs args)
        {
            long sliderValue = Convert.ToInt64(SliderNumber.Value);

            sliderMessage.Text = "Your phone number is +" + sliderValue.ToString();
        }


    }
}