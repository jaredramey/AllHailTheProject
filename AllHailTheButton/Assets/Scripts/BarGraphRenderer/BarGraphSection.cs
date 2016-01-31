using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.BarGraphRenderer {

    [ RequireComponent( typeof( VerticalLayoutGroup ), typeof( LayoutElement ) ) ]
    public class BarGraphSection : MonoBehaviour {

        public float[] Values = new float[0];

        private RectTransform m_rectTransform = null;

        private VerticalLayoutGroup m_verticalLayoutGroup = null;

        public VerticalLayoutGroup VerticalLayoutGroup {
            get { return m_verticalLayoutGroup ?? ( m_verticalLayoutGroup = GetComponent<VerticalLayoutGroup>() ); }
        }

        public RectTransform RectTransform {
            get { return m_rectTransform ?? ( m_rectTransform = GetComponent<RectTransform>() ); }
        }

        public RectTransform[] GraphSegments {
            get {
                return
                    GetComponentsInChildren<RectTransform>()
                        .Where( rectTransform => rectTransform.gameObject != gameObject )
                        .ToArray();
            }
        }

        public float Total {
            get {
                float total = 0.0f;
                foreach ( float value in Values ) {
                    total += value;
                }
                return total;
            }
        }

        public void UpdateGraph( params BarGraphElement[] graphElements ) {
            if ( Values.Length > graphElements.Length ) {
                Debug.LogWarningFormat(
                    "#{0}# There are more values than there are graphElements. Not all values will be added to the graph.",
                    typeof( BarGraphElement ).Name );
            }
            foreach ( RectTransform child in GraphSegments ) {
                Destroy( child.gameObject );
            }
            for ( int n = 0; n < graphElements.Length && n < Values.Length; ++n ) {
                GameObject child = new GameObject( graphElements[n].name,
                                                   typeof( RectTransform ),
                                                   typeof( CanvasRenderer ),
                                                   typeof( Image ),
                                                   typeof( LayoutElement ) );
                Image childImage = child.GetComponent<Image>();
                childImage.color = graphElements[n].Color;
                LayoutElement childLayout = child.GetComponent<LayoutElement>();
                childLayout.flexibleHeight = Values[n];
                RectTransform childTransform = child.GetComponent<RectTransform>();
                childTransform.SetParent( RectTransform, false );
            }
        }

    }

}
