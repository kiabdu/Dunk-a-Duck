using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Rigidbody2D rig;
    private float startPosX_Bottom = 1.432f;
    private float startPosX_Top = -9.12f; //1.98f;
    
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        
        //wert 0.53 für y-Pos. durch ausprobieren ermittelt
        if (gameObject.tag.Equals("waterTop"))
        {
            transform.position = new Vector3(startPosX_Top, 1.07f, -1f);
            rig.velocity = Vector2.right;
        } else if (gameObject.tag.Equals("waterBottom"))
        {
            transform.position = new Vector3(startPosX_Bottom, 0.53f, -3f);
            rig.velocity = Vector2.left;
        }
    }
    
    void FixedUpdate()
    {
        if (gameObject.tag.Equals("waterTop"))
        {
            if (transform.position.x >= startPosX_Bottom)
            {
                transform.position = new Vector3(startPosX_Top, transform.position.y, -1f);
            }
        }
        else
        {
            if (transform.position.x <= startPosX_Top)
            {
                transform.position = new Vector3(startPosX_Bottom, transform.position.y, -3f);
            }
        }
    }
}
