using System;

namespace helloWorld
{
    public class InputConverter
    {
        public int ConvertInputToInteger (string argTextInput) {
            int convertedNumber;

            if (!int.TryParse (argTextInput, out convertedNumber)) {
                throw new ArgumentException (Constants.ExpectedValueTypeInt);
            }

            return convertedNumber;
        }

        public double ConvertInputToDouble(string argTextInput)
        {
            double convertedNumber;

            if (!double.TryParse (argTextInput, out convertedNumber)) {
                throw new ArgumentException (Constants.ExpectedValueTypeDouble);
            }

            return convertedNumber;
        }
    }
}