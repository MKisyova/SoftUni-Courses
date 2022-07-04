using BorderControl.Interfaces;

namespace BorderControl.Members
{
    class Robot : IIdentifiable
    {
        public Robot(string model, string identityNumber)
        {
            Model = model;
            IdentityNumber = identityNumber;
        }

        public string Model { get; private set; }
        public string IdentityNumber { get ; private set; }
    }
}
