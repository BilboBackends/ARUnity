using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class placementindicatorscript : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    void Start()
    {
        //get compopnents
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        //hide the placement visual
        visual.SetActive(false);
    }

    void Update ()
    {
        //shoot raycast from center of screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if we hit AR plane update position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if(!visual.activeInHierarchy)
                visual.SetActive(true);
        }
    }
}
