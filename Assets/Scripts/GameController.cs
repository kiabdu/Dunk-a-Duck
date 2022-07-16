using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject rifle;
    private Transform rifleTransform;
    public GameObject shotMarker;
    
    void Start()
    {
        rifle = GameObject.Find("Rifle");
        rifleTransform = rifle.transform;
    }
    
    void Update()
    {
        MoveRifle();
        Shoot();
    }

    void MoveRifle()
    {
        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //fuer Maus-Constraints gewaehlte Werte durch trial and error bestimmt
        
        //solange sich die Maus innerhalb des Spielfensters befindet
        if (currentMousePos.x >= 1.5f && currentMousePos.x <= 10f)
        {
            //Position des Gewaehrs = Mausposition
            rifleTransform.position = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                rifleTransform.position.y,
                rifleTransform.position.z);
        }

        if (currentMousePos.y >= 0.25f && currentMousePos.y <= 2.5f)
        {
            rifleTransform.position = new Vector3(
                rifleTransform.position.x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                rifleTransform.position.z);
        }
    }

    void Shoot()
    {
        //wenn linke maustaste geklickt wird
        if (Input.GetMouseButtonDown(0))
        {
            //Einschuss-Sprite an der Position des Fadenkreuz generieren
            Instantiate(shotMarker, new Vector3(rifleTransform.GetChild(1).position.x, rifleTransform.GetChild(1).position.y, 9f), Quaternion.identity);
            
            //Spiele Schuss-Animation ab
            rifle.GetComponent<Animation>().Play();
        }
    }
}
