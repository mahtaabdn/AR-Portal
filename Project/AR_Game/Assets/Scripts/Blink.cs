using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public Text blinkText;
    float speed = 2.0f;
    Vector4 C;
    // Start is called before the first frame update
    void Start()
    {
        C = blinkText.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        blinkText.GetComponent<Text>().color = new Vector4(C[0], C[1], C[2], Mathf.Round(Mathf.PingPong(Time.time * speed, 1.0f)));
    }
}
