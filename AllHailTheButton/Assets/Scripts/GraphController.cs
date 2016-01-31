using UnityEngine;
using System.Collections;

public class GraphController : MonoBehaviour
{
    //default material for all recs
    public Material material;

    //Blue Team variables
    public Rect RC;
    public Color RC_Color;
    public float RC_PosX, RC_PosY, RC_W, RC_H;  //Red Clicked
    public Rect RA;
    public Color RA_Color;
    public float RA_PosX, RA_PosY, RA_W, RA_H;  //Red Active
    public Rect RI;
    public Color RI_Color;
    public float RI_PosX, RI_PosY, RI_W, RI_H;  //Red Inactive

    //Red Team Variables
    public Rect BC;
    public Color BC_Color;
    public float BC_PosX, BC_PosY, BC_W, BC_H;  //Blu Clicked
    public Rect BA;
    public Color BA_Color;
    public float BA_PosX, BA_PosY, BA_W, BA_H;  //Blu Active
    public Rect BI;
    public Color BI_Color;
    public float BI_PosX, BI_PosY, BI_W, BI_H;  //Blue Inactive


    // Use this for initialization
    void Start()
    {
        //TODO: Init all recs
        //Red Rects
        RC = new Rect(RC_PosX, RC_PosY, RC_W, RC_H);
        RA_PosY = RC_PosY + (RC_H / 2) + (RA_H / 2);
        RA = new Rect(RA_PosX, RA_PosY, RA_W, RA_H); //Get Y pos by adding half of height to RC pos
        RI_PosY = RA_PosY + (RA_H / 2) + (RI_H / 2);
        RI = new Rect(RI_PosX, RI_PosY, RI_W, RI_H); //Get Y pos by adding half of height to RA pos

        //Blue Rects
        BC = new Rect(BC_PosX, BC_PosY, BC_W, BC_H);
        BA_PosY = BC_PosY + (BC_H / 2) + (BA_H / 2);
        BA = new Rect(BA_PosX, BA_PosY, BA_W, BA_H); //Get Y pos by adding half of height to RC pos
        BI_PosY = BA_PosY + (BA_H / 2) + (BI_H / 2);
        BI = new Rect(BI_PosX, BI_PosY, BI_W, BI_H); //Get Y pos by adding half of height to RA pos
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

    void DrawRec(Rect rect, Color color)
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

        //Setting up Vertex3's for GL calls when creating squares
        float halfHeight = rect.height / 2;
        float halfWidth = rect.width / 2;

        Vector3 BottomLeft = new Vector3(rect.x - halfWidth, rect.y - halfHeight, 0);
        Vector3 BottomRight = new Vector3(rect.x + halfWidth, rect.y - halfHeight, 0);
        Vector3 TopRight = new Vector3(rect.x + halfWidth, rect.y + halfHeight, 0);
        Vector3 TopLeft = new Vector3(rect.x - halfWidth, rect.y + halfHeight, 0);

        //Using Unity OpenGL calls, create the square

        material.SetPass(0);

        GL.Color(color);
        GL.Begin(GL.QUADS);
        GL.Vertex3(BottomLeft.x, BottomLeft.y, BottomLeft.z);
        GL.Vertex3(BottomRight.x, BottomRight.y, BottomRight.z);
        GL.Vertex3(TopRight.x, TopRight.y, TopRight.z);
        GL.Vertex3(TopLeft.x, TopLeft.y, TopLeft.z);
        GL.End();

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
