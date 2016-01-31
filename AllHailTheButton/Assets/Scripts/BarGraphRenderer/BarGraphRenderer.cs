using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.BarGraphRenderer {

    public class BarGraphRenderer : MonoBehaviour {

        public BarGraphElement[] Elements = new BarGraphElement[0];

        public int MaxGraphCount = 0;

        private RectTransform m_rectTransform = null;

        private List<BarGraphSection> m_barGraphSections = new List<BarGraphSection>();

        public RectTransform RectTransform {
            get { return m_rectTransform ?? ( m_rectTransform = GetComponent<RectTransform>() ); }
        }

        public float[] Totals {
            get {
                float[] totals = new float[m_barGraphSections.Count];
                for ( int n = 0; n < totals.Length; ++n ) {
                    totals[n] = m_barGraphSections[n].Total;
                }
                return totals;
            }
        }

        public float HighestTotal {
            get {
                float max = 0.0f;
                foreach ( float total in Totals ) {
                    if ( max < total ) {
                        max = total;
                    }
                }
                return max;
            }
        }

        private float xOffset { get { return RectTransform.rect.width / m_barGraphSections.Count; } }

        public void ClearGraph() {
            m_barGraphSections.ForEach( section => Destroy( section.gameObject ) );
            m_barGraphSections.Clear();
        }

        public void PopBack() {
            Destroy( m_barGraphSections[m_barGraphSections.Count - 1].gameObject );
            m_barGraphSections.RemoveAt( m_barGraphSections.Count - 1 );
            RedrawGraph();
        }

        public void PopFront() {
            Destroy( m_barGraphSections[0].gameObject );
            m_barGraphSections.RemoveAt( 0 );
            RedrawGraph();
        }

        public void PushBack( BarGraphSection section ) {
            m_barGraphSections.Add( section );
            section.RectTransform.SetParent( RectTransform );
            if ( MaxGraphCount > 0 ) {
                while ( m_barGraphSections.Count > MaxGraphCount ) {
                    PopFront();
                }
            }
            RedrawGraph();
        }

        public void PushBack( params float[] values ) { PushBack( CreateGraphSection( values ) ); }

        public void PushFront( BarGraphSection section ) {
            m_barGraphSections.Insert( 0, section );
            section.RectTransform.SetParent( RectTransform );
            if ( MaxGraphCount > 0 ) {
                while ( m_barGraphSections.Count > MaxGraphCount ) {
                    PopBack();
                }
            }
            RedrawGraph();
        }

        public void PushFront( params float[] values ) { PushFront( CreateGraphSection( values ) ); }

        private BarGraphSection CreateGraphSection( params float[] values ) {
            BarGraphSection section =
                new GameObject( "BarGraphSection",
                                typeof( RectTransform ),
                                typeof( VerticalLayoutGroup ),
                                typeof( BarGraphSection ) ).GetComponent<BarGraphSection>();
            section.Values = values;
            section.VerticalLayoutGroup.childAlignment = TextAnchor.LowerLeft;
            section.VerticalLayoutGroup.childForceExpandHeight = false;
            section.RectTransform.anchorMin = Vector2.zero;
            section.RectTransform.anchorMax = Vector2.zero;
            return section;
        }

        private void RedrawGraph() {
            for ( int n = 0; n < m_barGraphSections.Count; ++n ) {
                m_barGraphSections[n].RectTransform.sizeDelta = new Vector2( xOffset,
                                                                             RectTransform.rect.height *
                                                                             ( m_barGraphSections[n].Total /
                                                                               HighestTotal ) );
                m_barGraphSections[n].RectTransform.anchoredPosition = RectTransform.offsetMin +
                                                                       new Vector2( xOffset * n + ( xOffset / 2.0f ),
                                                                                    m_barGraphSections[n].RectTransform.rect.height /
                                                                                    2.0f );

                m_barGraphSections[n].UpdateGraph( Elements );
            }
        }

        private void Update() {
            if ( RectTransform.hasChanged ) {
                RedrawGraph();
            }
        }

    }

}
