using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsingable
    {
        public string Number { get; set; }

        public string Website { get; set; }

        public string AbilityToBrowse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {site}!";

        }

        public string AbilityToCall(string number)
        {
            return $"Calling... {number:d2}";
        }
    }
}
