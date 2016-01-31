using System;

namespace DataModel
{
    public enum UserState
    {
        Active = 0,
        Inactive,
        Clicked,
    };

    class User
    {
        public User(Team team)
        {
            _team = team;
        }

        private static uint s_uInactivityThreshold = 5;

        public UserState GetState(uint uLottery)
        {
            switch (_currentState)
            {
                case UserState.Active:
                case UserState.Clicked:
                    _HandleActive(uLottery);
                    break;

                case UserState.Inactive:
                    _HandleInactive(uLottery);
                    break;
            }
            return _currentState;
        }

        public Team GetTeam()
        {
            return _team;
        }

        private void _HandleActive(uint uLottery)
        {
            double value = s_rand.NextDouble();
            if (value < Probabilities.s_pActiveClicks * Math.Pow(Probabilities.s_pInactivityDecay, _uDaysSinceActive))
            {
                _currentState = UserState.Clicked;
                _uDaysSinceActive = 0;
            }
            else
            {
                // Increment the days since we were last active
                _uDaysSinceActive++;

                // If we're at the threshold, we'll become inactive
                if (_uDaysSinceActive >= s_uInactivityThreshold)
                {
                    _currentState = UserState.Inactive;
                }
                else
                {
                    _currentState = UserState.Active;
                }
            }
        }

        private void _HandleInactive(uint uLottery)
        {
            double value = s_rand.NextDouble();
            if (value < Probabilities.s_pInactiveClicks * Math.Pow(Probabilities.s_pInactivityDecay, _uDaysSinceActive))
            {
                _currentState = UserState.Clicked;
                _uDaysSinceActive = 0;
            }
            else
            {
                // Increment the days since we were last active
                _uDaysSinceActive++;
            }
        }

        private UserState _currentState = UserState.Active;
        private uint _uDaysSinceActive = 0;
        private Team _team;

        static private Random s_rand = new Random();
    }
}
