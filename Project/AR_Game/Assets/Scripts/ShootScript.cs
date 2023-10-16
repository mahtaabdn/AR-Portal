using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    //public GameObject arCamera;
    public GameObject smoke;
    public void Shoot()
    {
        RaycastHit hit;
        var ARCam = GameObject.FindWithTag("ARCam");
        if(Physics.Raycast(ARCam.transform.position, ARCam.transform.forward,out hit))
        {
            if(hit.transform.tag == "Monster")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                GameData.Coins += 20;
            }
        }
    }

}
