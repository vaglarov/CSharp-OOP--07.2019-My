namespace _104.Telephony.Model
{
    using _104.Telephony.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Smartphone : ICallable, IBrowsing
    {
        public Smartphone()
        {

        }

        public string Browsing(string url)
        {
            if (!ValidateURK(url))
            {
                return $"Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }

        public string Calling(string number)
        {
            if (CheckForLetter(number))
            {
                return $"Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }

        }

        private bool ValidateURK(string url)
        {
            if (CheckForNumber(url))
            {
                return false;
            }
            return true;
        }

        private bool CheckForNumber(string url)
        {
            foreach (var charackter in url)
            {
                if (char.IsDigit(charackter))
                {
                    return true;
                }
              
            }
            return false;
        }

        private bool CheckForLetter(string number)
        {
            foreach (var character in number)
            {
                if (char.IsLetter(character)|| !char.IsLetterOrDigit(character))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
