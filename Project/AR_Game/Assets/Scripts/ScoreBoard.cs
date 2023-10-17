using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    public TextMesh ScoreText = null;
    public string ScorePrefix = string.Empty;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (ScoreText != null)
            ScoreText.text = ScorePrefix + GameData.Coins.ToString();
    }
}
