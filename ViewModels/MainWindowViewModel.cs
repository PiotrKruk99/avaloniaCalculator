using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace avaloniaCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //private int displayValue = 0;
        private double displayValue = 0;

        // public string DisplayValue
        // {
        //     get => displayValue.ToString();
        //     private set => this.RaiseAndSetIfChanged(ref displayValue, Convert.ToInt32(value));
        // }

        public double DisplayValue
        {
            get => displayValue;
            private set => this.RaiseAndSetIfChanged(ref displayValue, value);
        }

        public void NumberSelected(string numberText)
        {
            double number = Convert.ToDouble(numberText);
            //DisplayValue = (displayValue * 10 + number).ToString();
            DisplayValue = displayValue * 10 + number;
        }

        public void ResetAll()
        {
            //DisplayValue = "0";
            DisplayValue = 0;
        }

        public void ButtonClicked(string text)
        {

        }
    }
}
