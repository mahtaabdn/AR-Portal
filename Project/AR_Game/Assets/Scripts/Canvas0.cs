using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas0 : MonoBehaviour
{
    public float MaxTime = 10;
    public float CountDown = 0;
    public GameObject CanvasLevel0, CanvasLevel1obj;
    // Start is called before the first frame update
    void Start()
    {
        CountDown = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown >= 0)
        {
            CountDown -= Time.deltaTime;
        }
        else
        {
            Instantiate(CanvasLevel1obj);
            Destroy(CanvasLevel0);
        }
    }
}
