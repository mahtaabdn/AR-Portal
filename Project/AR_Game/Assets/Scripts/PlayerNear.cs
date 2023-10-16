using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNear : MonoBehaviour
{
    public static bool isNear = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ARCam"))
        {
            isNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ARCam"))
        {
            isNear = false;
        }
    }
}
