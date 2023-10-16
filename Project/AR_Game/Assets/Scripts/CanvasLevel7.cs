using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLevel7 : MonoBehaviour
{
    public GameObject QButtons, RButton, CatText;
    void Start()
    {
        QButtons.SetActive(false);
        RButton.SetActive(false);
        CatText.SetActive(false);
    }
    void Update()
    {
        if (PlayerNear.isNear == true)
        {
            QButtons.SetActive(true);
            RButton.SetActive(true);
            CatText.SetActive(true);
        }
        else
        {
            QButtons.SetActive(false);
            RButton.SetActive(false);
            CatText.SetActive(false);
        }
    }
}
