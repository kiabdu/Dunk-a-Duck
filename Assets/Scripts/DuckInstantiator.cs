using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckInstantiator : MonoBehaviour
{
    public GameObject duck;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateDuck", 1f, Random.Range(1.5f, 3f));
    }

    void InstantiateDuck()
    {
        Instantiate(duck, new Vector3(-1f, 1.5f, -2f), Quaternion.identity);
    }
}
