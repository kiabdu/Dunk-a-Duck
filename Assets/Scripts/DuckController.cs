using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = Vector2.right * Random.Range(0.25f, 4f);

        if (transform.position.x > 11f)
        {
            Destroy(gameObject);
        }
    }
}
