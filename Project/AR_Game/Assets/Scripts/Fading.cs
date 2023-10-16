using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{

    public Image whiteFade;
    // Start is called before the first frame update
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0.0f);
        FadeIn();

    }

    // Update is called once per frame
    public void FadeIn()
    {
        whiteFade.CrossFadeAlpha(1, 2, false);
    }
}
