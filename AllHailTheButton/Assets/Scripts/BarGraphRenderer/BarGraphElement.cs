using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.BarGraphRenderer {

    [ CreateAssetMenu( menuName = "BarGraphElement", fileName = "BarGraphElement", order = 0 ) ]
    public class BarGraphElement : ScriptableObject {

        public string Name = "NULL";

        [ Multiline ]
        public string Description = "NULL";

        public Color Color = Color.magenta;

    }

}
