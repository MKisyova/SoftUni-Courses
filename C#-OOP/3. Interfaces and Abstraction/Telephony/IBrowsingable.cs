namespace Telephony
{
    public interface IBrowsingable
    {
        public string Website { get; set; }

        string AbilityToBrowse(string site);
    }
}
