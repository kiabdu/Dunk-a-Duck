using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Rigidbody2D _rig;
    private const float StartPosXBottom = 1.432f;
    private const float StartPosXTop = -9.12f; //1.98f;
    
    void Start()
    {
        _rig = gameObject.GetComponent<Rigidbody2D>();
        
        //wert 0.53 für y-Pos. durch ausprobieren ermittelt
        if (gameObject.tag.Equals("waterTop"))
        {
            transform.position = new Vector3(StartPosXTop, 1.07f, -1f);
            _rig.velocity = Vector2.right;
        } else if (gameObject.tag.Equals("waterBottom"))
        {
            transform.position = new Vector3(StartPosXBottom, 0.53f, -3f);
            _rig.velocity = Vector2.left;
        }
    }
    
    void FixedUpdate()
    {
        if (gameObject.tag.Equals("waterTop"))
        {
            if (transform.position.x >= StartPosXBottom)
            {
                transform.position = new Vector3(StartPosXTop, transform.position.y, -1f);
            }
        }
        else
        {
            if (transform.position.x <= StartPosXTop)
            {
                transform.position = new Vector3(StartPosXBottom, transform.position.y, -3f);
            }
        }
    }
}
