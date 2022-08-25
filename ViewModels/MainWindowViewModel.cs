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
        private double value1 = 0;
        private double value2 = 0;
        private enum OperationType {sum, difference, product, quotient, none};
        private OperationType operationType = OperationType.none;

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

        public void SetOperation(string operT)
        {
            switch (operationType)
            {
                case OperationType.sum:
                    DisplayValue = value1 + displayValue;
                    break;
                case OperationType.difference:
                    DisplayValue = value1 - displayValue;
                    break;
                case OperationType.product:
                    DisplayValue = value1 * displayValue;
                    break;
                case OperationType.quotient:
                    DisplayValue = displayValue == 0 ? 0 : value1 / displayValue;
                    break;
            }

            switch (operT)
            {

                case "+":
                    operationType = OperationType.sum;
                    break;
                case "-":
                    operationType = OperationType.difference;
                    break;
                case "*":
                    operationType = OperationType.product;
                    break;
                case "/":
                    operationType = OperationType.quotient;
                    break;
                default:
                    operationType = OperationType.none;
                    break;
            }
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
