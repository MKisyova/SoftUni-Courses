using BorderControl.Interfaces;

namespace BorderControl.Members
{
    class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        public Citizen(string name, int number, string identityNumber, string birthDate)
        {
            Name = name;
            Age = number;
            IdentityNumber = identityNumber;
            BirthDate = birthDate;
            Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string IdentityNumber { get; private set ; }

        public string BirthDate { get ; private set ; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
