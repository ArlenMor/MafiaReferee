using System.Numerics;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace Vote
{
    public class CandidateValidate : MonoBehaviour
    {
        public InputField Candidate;


        /*void Validate(string str)
        {
            if (   str != "1" || str != "2" || str != "3"
                || str != "4" || str != "5" || str != "6"
                || str != "7" || str != "8" || str != "9" || str != "10")
            {
                Candidate.text = "";
            }
        }*/
        public void Start()
        {
            Candidate.onValidateInput += (input, charIndex, addedChar) => MyValidate(addedChar, input);
        }
        
        
        private static char MyValidate(char charToValidate, string str)
        {
            if (charToValidate != '1' && charToValidate != '2' &&
                charToValidate != '3' && charToValidate != '4' &&
                charToValidate != '5' && charToValidate != '6' &&
                charToValidate != '7' && charToValidate != '8' &&
                charToValidate != '9' && charToValidate != '0' ||
                str.Length > 2)
            {
                charToValidate = '\0';
            }

            return charToValidate;
        }
    }
}