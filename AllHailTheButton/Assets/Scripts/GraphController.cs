using UnityEngine;
using System.Collections;

public class GraphController : MonoBehaviour
{
    //default material for all recs
    public Material material;

    //Blue Team variables
    public Color RC_Color;
    public float RC_PosX, RC_PosY, RC_W, RC_H;  //Red Clicked
    public Color RA_Color;
    public float RA_PosX, RA_PosY, RA_W, RA_H;  //Red Active
    public Color RI_Color;
    public float RI_PosX, RI_PosY, RI_W, RI_H;  //Red Inactive

    //Red Team Variables
    public Color BC_Color;
    public float BC_PosX, BC_PosY, BC_W, BC_H;  //Blu Clicked
    public Color BA_Color;
    public float BA_PosX, BA_PosY, BA_W, BA_H;  //Blu Active
    public Color BI_Color;
    public float BI_PosX, BI_PosY, BI_W, BI_H;  //Blue Inactive


    // Use this for initialization
    void Start()
    {
        //TODO: Init all recs
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Create function to update all recs
    }

    void OnGUI()
    {
        //TODO: Draw all recs
    }

    void DrawRec(float X, float Y, float W, float H, Color color)
    {
        // We shouldn't draw until we are told to do so.
        if (Event.current.type != EventType.Repaint)
            return;

        // Please assign a material that is using position and color.
        if (material == null)
        {
            Debug.LogError("You have forgot to set a material.");
            return;
        }

        //TODO: Finish fillinf out function from source below

    }
}

/*
* Source: http://answers.unity3d.com/questions/37752/how-to-render-a-colored-2d-rectangle.html
* Author: Statement
* Code -
 using UnityEngine;
 using System.Collections;
 
 public class Example : MonoBehaviour
 {
     // Please assign a material that is using position and color.
     public Material material;
     
     public Rect position = new Rect (16, 16, 128, 24);
     public Color color = Color.red;
     
     void OnGUI ()
     {        
         DrawRectangle (position, color);        
     }
         
     void DrawRectangle (Rect position, Color color)
     {    
         // We shouldn't draw until we are told to do so.
         if (Event.current.type != EventType.Repaint)
             return;
         
         // Please assign a material that is using position and color.
         if (material == null) {
             Debug.LogError ("You have forgot to set a material.");
             return;
         }
         
         material.SetPass (0);
         
         // Optimization hint: 
         // Consider Graphics.DrawMeshNow
         GL.Color (color);
         GL.Begin (GL.QUADS);
         GL.Vertex3 (position.x, position.y, 0);
         GL.Vertex3 (position.x + position.width, position.y, 0);
         GL.Vertex3 (position.x + position.width, position.y + position.height, 0);
         GL.Vertex3 (position.x, position.y + position.height, 0);
         GL.End ();
     }
 }
*/
