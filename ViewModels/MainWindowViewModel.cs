using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace avaloniaCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private decimal displayValue = 0;
        private bool shouldResetDisplay = false;
        private decimal value1 = 0;
        private enum OperationType { sum, difference, product, quotient, result, none };
        private OperationType operationType = OperationType.none;

        public decimal DisplayValue
        {
            get => displayValue;
            private set => this.RaiseAndSetIfChanged(ref displayValue, value);
        }

        public void NumberSelected(string numberText)
        {
            decimal number = Convert.ToDecimal(numberText);

            if (shouldResetDisplay)
            {
                value1 = displayValue;
                DisplayValue = number;
                shouldResetDisplay = false;
            }
            else
            {
                DisplayValue = displayValue * 10 + number;
            }
        }

        public void SetOperation(string operT)
        {
            if (!shouldResetDisplay)
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
                case "=":
                    operationType = OperationType.result;
                    break;
                default:
                    operationType = OperationType.none;
                    break;
            }

            shouldResetDisplay = true;
        }

        public void ResetAll()
        {
            DisplayValue = 0;
            value1 = 0;
            shouldResetDisplay = false;
        }
    }
}
