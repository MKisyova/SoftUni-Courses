namespace Telephony
{
    public interface ICallable
    {
        public string Number { get; set; }

        string AbilityToCall(string number);
    }
}
