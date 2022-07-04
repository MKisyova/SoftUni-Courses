namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone(string number)
        {
            Number = number;
        }

        public string Number { get; set ; }

        public string AbilityToCall(string number)
        {
            return $"Dialing... {number:d2}";
        }
    }
}
