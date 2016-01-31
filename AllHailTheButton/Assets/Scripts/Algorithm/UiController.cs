using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DataModel
{
    class UiController
    {
        // This will change when we move to the final graph handler
        private static ModelTest UiHandler;

        public static void Intialize()
        {
            UiHandler = GameObject.FindObjectOfType<ModelTest>();
        }

        // You must call Initialize before calling this
        public static void UpdateUI(IterationData data)
        {
            List<float> team1 = new List<float>();
            foreach (UserState state in Enum.GetValues(typeof(UserState)))
            {
                team1.Add(data.GetData(Team.Blue, state));
            }

            List<float> team2 = new List<float>();
            foreach (UserState state in Enum.GetValues(typeof(UserState)))
            {
                team2.Add(data.GetData(Team.Red, state));
            }

            UiHandler.PushUpdate(team1, team2);
        }
    }
}
