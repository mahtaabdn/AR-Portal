using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorNear : MonoBehaviour
{
    public GameObject DoorCanvas;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ARCam"))
        {
            Instantiate(DoorCanvas);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ARCam"))
        {
            var Canv = GameObject.FindGameObjectWithTag("DoorCanvas");
            Destroy(Canv);
        }
    }

}

