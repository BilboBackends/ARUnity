using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private placementindicatorscript placementindicatorscript;

    void Start ()
    {

        placementindicatorscript = FindObjectOfType<placementindicatorscript>();
    }

    void Update ()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
        {
            GameObject obj = Instantiate(objectToSpawn, placementindicatorscript.transform.position, placementindicatorscript.transform.rotation);
        }
    }

    void Destruction(){
        Destroy(this.gameObject);
    }
}
