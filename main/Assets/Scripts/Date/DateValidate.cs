using UnityEngine;
using UnityEngine.UI;

namespace Date
{
    public class DateValidate : MonoBehaviour
    {
        public InputField mainInputField;
        public void Start()
        {
            // Sets the MyValidate method to invoke after the input field's default input validation invoke (default validation happens every time a character is entered into the text field.)
            mainInputField.onValidateInput += delegate(string input, int charIndex, char addedChar) { return MyValidate( addedChar, input ); };
        }

        private char MyValidate(char charToValidate, string str)
        {
            //Checks if a dollar sign is entered....
            if (charToValidate != '1' && charToValidate != '2' &&
                charToValidate != '3' && charToValidate != '4' &&
                charToValidate != '5' && charToValidate != '6' &&
                charToValidate != '7' && charToValidate != '8' &&
                charToValidate != '9' && charToValidate != '0' &&
                charToValidate != '.' && charToValidate != ',' || str.Length >= 10   )
            {
                // ... if it is change it to an empty character.
                charToValidate = '\0';
            }
            return charToValidate;
        }
    }
}