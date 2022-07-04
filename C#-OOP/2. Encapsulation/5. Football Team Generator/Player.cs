using System;

namespace FootballTeamGenerator
{
    class Player
    {
        private string name;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Endurance
        {
            get => endurance; 

            set
            {
                ValidateStat(nameof(Endurance), value);
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint; 

            set 
            {
                ValidateStat(nameof(Sprint), value);
                sprint = value; 
            }
        }

        public int Dribble
        {
            get => dribble; 

            set 
            {
                ValidateStat(nameof(Dribble), value);
                dribble = value; 
            }
        }

        public int Passing
        {
            get => passing; 

            set 
            {
                ValidateStat(nameof(Passing), value);
                passing = value; 
            }
        }

        public int Shooting
        {
            get => shooting; 

            set 
            {
                ValidateStat(nameof(Shooting), value);
                shooting = value; 
            }
        }

        public double Stats
            => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private void ValidateStat(string statName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }

    }
}
