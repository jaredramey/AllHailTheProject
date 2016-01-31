using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Team
{
    Red = 0,
    Blue,
}

namespace ConsoleApplication1
{
    class Model : ITimeControlledObject
    {
        private List<User> _users;
        private const uint c_uInitialUsers = 100;

        public Model()
        {
            _users = new List<User>();
            for (uint i = 0; i < c_uInitialUsers; i++)
            {
                _users.Add(new User((Team) (i % 2)));
            }
        }
        
        // ITimeControlledObject
        public void Trigger()
        {
            IterationData data = new IterationData();
            data.uIteration = _cIterations;
            data.uThreshold = _uThreshold;

            _AddUsers();
            foreach (User user in _users)
            {
                UserState state = user.GetState(_uLottery);
                Team team = user.GetTeam();
                data.SetData(team, state);
            }

            _UpdateUI(data);

            _UpdateLottery(data);
            _cIterations++;
        }

        private void _AddUsers()
        {

        }

        private void _UpdateUI(IterationData data)
        {
            Console.Write(data.uIteration + "\t");
            Console.Write(data.uThreshold + "\t");

            foreach (Team team in Enum.GetValues(typeof(Team)))
            {
                foreach (UserState state in Enum.GetValues(typeof(UserState)))
                {
                    Console.Write(data.GetData(team, state) + "\t");
                }
            }

            Console.WriteLine();
        }

        private void _UpdateLottery(IterationData data)
        {
            bool fLossCondition = false;

            // Here we'll assume there's two teams.
            if (data.GetData(Team.Blue, UserState.Clicked) < _uThreshold)
            {
                if (data.GetData(Team.Blue, UserState.Clicked) < _uThreshold)
                {
                    // Both teams lose
                    // Grow the lottery even more, keep the threshold the same
                    _uLottery = (uint) (c_dLotteryLossGrowth * _uLottery);
                }
                else
                {
                    // Red wins!
                    
                }

            }
        }

        private uint _cIterations = 0;
        private uint _uLottery = 0;
        private uint _uThreshold = 0;


        private const double c_dLotteryGrowth = 1.25;
        private const double c_dLotteryLossGrowth = 1.75;
        private const double c_dThresholdGrowth = 1.25;
    }
}
