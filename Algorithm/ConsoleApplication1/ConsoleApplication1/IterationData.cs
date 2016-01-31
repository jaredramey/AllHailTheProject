using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class IterationData
    {
        public uint uIteration;
        public uint uThreshold;
        private uint[][] data = new uint[Enum.GetValues(typeof(Team)).Length][];
        private uint[] score = new uint[Enum.GetValues(typeof(Team)).Length];

        public IterationData()
        {
            foreach (Team team in Enum.GetValues(typeof(Team)))
            {
                data[(int)team] = new uint[Enum.GetValues(typeof(UserState)).Length];
                foreach (UserState state in Enum.GetValues(typeof(UserState)))
                {
                    data[(int)team][(int)state] = 0;
                }
            }
        }

        public void SetData(Team team, UserState state)
        {
            data[(int)team][(int)state]++;
        }

        public uint GetData(Team team, UserState state)
        {
            return data[(int)team][(int)state]++;
        }
    }
}
