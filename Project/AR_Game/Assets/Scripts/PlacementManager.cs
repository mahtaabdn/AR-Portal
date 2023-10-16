using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject arObj;
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    public static bool Oneobj = false;
    public static Pose pose;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Oneobj == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
                if (_raycastManager.Raycast(ray, _hits))
                {
                    pose = _hits[0].pose;
                    Instantiate(arObj, pose.position, arObj.transform.rotation);

                    //GameObject.FindGameObjectWithTag("BedMenu").SetActive(false);
                    Oneobj = true;
                    var DetP = GameObject.FindGameObjectWithTag("PlaneDetector");
                    Destroy(DetP);
                    // GameObject.FindGameObjectWithTag("BedMenu").SetActive(true);
                    //Instantiate(arObj, pose.position, Quaternion.identity);



                }
            }
        }
    }
}
