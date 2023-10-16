using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoard : MonoBehaviour
{

    public TextMesh HealthText = null;
    public string HealthPrefix = string.Empty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HealthText != null)
            HealthText.text = HealthPrefix + GameData.Health.ToString();
    }
}
