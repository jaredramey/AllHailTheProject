using System;
using System.Collections.Generic;

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
        private const uint c_uInitialUsers = 1000;

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
            uint uNewUsers = (uint) (_users.Count * Probabilities.s_pNewUser * (((double) _uLottery) / _uLotteryTotal) * (_cIterations / Math.Pow(_cIterations, Probabilities.s_pInterestDecay)));
            
            for (uint i = 0; i < uNewUsers; i++)
            {
                _users.Add(new User((Team) (i % 2)));
            }
        }

        private void _UpdateUI(IterationData data)
        {
            Console.WriteLine(_users.Count);
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

            bool fBlueLoss = data.GetData(Team.Blue, UserState.Clicked) < _uThreshold;
            bool fRedLoss = data.GetData(Team.Red, UserState.Clicked) < _uThreshold;
            if (fBlueLoss && fRedLoss)
            {
                // Both teams lose
                // Grow the lottery even more, keep the threshold the same
                _uLottery = (uint)(_uLottery * c_dLotteryGrowth);
            }
            else if (fRedLoss)
            {
                // Blue wins
                _uBlueScore += _uLottery;
                _ResetGame();

            }
            else if (fBlueLoss)
            {
                // Red wins
                _uRedScore += _uLottery;
                _ResetGame();
            }
            else
            {
                // No winner
                _uThreshold = (uint) Math.Ceiling(_uThreshold * c_dThresholdGrowth);
            }

            // Update the total lottery
            _uLotteryTotal += _uLottery;
        }

        private void _ResetGame()
        {
            _uThreshold = c_uThresholdStart;
            _uLottery = c_uLotteryStart;
        }

        private uint _cIterations = 1;
        private uint _uLottery = c_uLotteryStart;
        private uint _uThreshold = c_uThresholdStart;
        
        private const double c_dLotteryGrowth = 1.5;
        private const double c_dLotteryLossGrowth = 1.75;
        private const double c_dThresholdGrowth = 1.25;

        private uint _uRedScore = 0;
        private uint _uBlueScore = 0;

        private const uint c_uLotteryStart = 5;
        private const uint c_uThresholdStart = 2;

        private uint _uLotteryTotal = c_uLotteryStart;
    }
}
