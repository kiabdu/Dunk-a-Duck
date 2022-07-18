using UnityEngine;
using Random = UnityEngine.Random;

public class DuckController : MonoBehaviour
{
    private Rigidbody2D _rig;
    private bool _crosshairOverDuck = false;

    // Start is called before the first frame update
    public void Start()
    {
        _rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        _rig.velocity = Vector2.right * Random.Range(0.25f, 10f);
        
        //in eigene Funktion packen
        KillDuck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            _crosshairOverDuck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            _crosshairOverDuck = false;
        }
    }
    
    private void KillDuck()
    {
        if (_crosshairOverDuck && GameController.IsShooting())
        {
            GameController.SetDuckPosition(transform.GetChild(0).position);
            GameController.DuckKilled(true);
            Destroy(gameObject);
        }

        if (transform.position.x > 11f)
        {
            Destroy(gameObject);
        }
    }
}
