using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtons : MonoBehaviour
{
    private float moveStep = 0.1f;
    private float rotStep = 45f;
    // Start is called before the first frame update
    public void OkBut()
    {
        if (GameData.BedPlaced == true && GameData.ChairPlaced == true)
        {
            GameData.BookPlaced = true;
        }

        if (GameData.BedPlaced == true && GameData.ChairPlaced == false)
        {
            GameData.ChairPlaced = true;
        }

        if (GameData.BedPlaced == false)
        {
            GameData.BedPlaced = true;
        }


        var buts = GameObject.FindGameObjectWithTag("MoveButtons");
        Destroy(buts);
    }

    public void UpBut()
    {
        if(GameData.BedPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BedTag);
            Moveob.transform.Translate(Vector3.back * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == false)
        {

            var Moveob = GameObject.FindGameObjectWithTag(GameData.ChairTag);
            Moveob.transform.Translate(Vector3.forward * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == true)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BookTag);
            Moveob.transform.Translate(Vector3.forward * moveStep);
        }
    }

    public void DownBut()
    {
        if (GameData.BedPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BedTag);
            Moveob.transform.Translate(Vector3.forward * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.ChairTag);
            Moveob.transform.Translate(Vector3.back * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == true)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BookTag);
            Moveob.transform.Translate(Vector3.back * moveStep);
        }
    }

    public void RightBut()
    {
        if (GameData.BedPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BedTag);
            Moveob.transform.Translate(Vector3.left * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.ChairTag);
            Moveob.transform.Translate(Vector3.right * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == true)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BookTag);
            Moveob.transform.Translate(Vector3.right * moveStep);
        }
    }

    public void LeftBut()
    {
        if (GameData.BedPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BedTag);
            Moveob.transform.Translate(Vector3.right * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.ChairTag);
            Moveob.transform.Translate(Vector3.left * moveStep);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == true)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BookTag);
            Moveob.transform.Translate(Vector3.left * moveStep);
        }
    }

    public void RotateBut()
    {
        if (GameData.BedPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BedTag);
            Moveob.transform.Rotate(0,rotStep,0);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == false)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.ChairTag);
            Moveob.transform.Rotate(0, rotStep, 0);
        }
        if (GameData.BedPlaced == true && GameData.ChairPlaced == true)
        {
            var Moveob = GameObject.FindGameObjectWithTag(GameData.BookTag);
            Moveob.transform.Rotate(0, rotStep, 0);
        }
    }
}
