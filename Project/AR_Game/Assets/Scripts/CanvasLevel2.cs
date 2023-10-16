using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class CanvasLevel2 : MonoBehaviour
{
    public GameObject CatTextBuy, HandImg, BuyButton, MoneyErrorText, PlaceBedButton, LooseText, QButtons, RButton, CanvasLevel3obj, BedMenuButton, Canvas3D, Bed1, Bed2, Bed3, PlacementAnchorImage, RoomAudio;
    public static bool BedReq = false;
    public static bool bedPlaced = false;
    public int BedNumber;
    // Start is called before the first frame update
    void Start()
    {
        HandImg.SetActive(false);
        BuyButton.SetActive(false);
        MoneyErrorText.SetActive(false);
        PlaceBedButton.SetActive(false);
        LooseText.SetActive(false);
        QButtons.SetActive(false);
        RButton.SetActive(false);
        PlacementAnchorImage.SetActive(false);
        BedMenuButton.SetActive(false);
        CatTextBuy.SetActive(false);
        Instantiate(RoomAudio);
    }

    // Update is called once per frame
    void Update()
    {


        if (PlayerNear.isNear == true && BedReq == false)
        {
            BedMenuButton.SetActive(true);
            CatTextBuy.SetActive(true);
        }
        else
        {
            BedMenuButton.SetActive(false);
            CatTextBuy.SetActive(false);
        }


    }

    public void BedMenuBut()
    {
        BedReq = true;
        BedMenuButton.SetActive(false);
        CatTextBuy.SetActive(false);
        var ARCam = GameObject.FindWithTag("ARCam");
        float x = ARCam.transform.position[0] + Canvas3D.transform.position[0];
        float y = ARCam.transform.position[1] + Canvas3D.transform.position[1];
        float z = ARCam.transform.position[2] + Canvas3D.transform.position[2];
        Vector3 posi = new Vector3(x, y, z);

        Instantiate(Canvas3D, posi, Quaternion.identity);

        BuyButton.SetActive(true);
        HandImg.SetActive(true);
        QButtons.SetActive(true);
        RButton.SetActive(true);
    }

    public void BuyBut()
    {
        RaycastHit hited;
        var ARCam = GameObject.FindWithTag("ARCam");
        if (Physics.Raycast(ARCam.transform.position, ARCam.transform.forward, out hited))
        {
            if (hited.transform.tag == "Bed200")
            {
                if (GameData.Coins >= 200)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3D");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceBedButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 200;
                    BedNumber = 1;
                    GameData.BedTag = "Bed200";

                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }

            if (hited.transform.tag == "Bed250")
            {
                if (GameData.Coins >= 250)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3D");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceBedButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 250;
                    BedNumber = 3;
                    GameData.BedTag = "Bed250";
                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }

            if (hited.transform.tag == "Bed225")
            {
                if (GameData.Coins >= 225)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3D");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceBedButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 225;
                    BedNumber = 2;
                    GameData.BedTag = "Bed225";
                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }
        }
    }

    public void PutBedBut()
    {
        RaycastHit hit;
        var ARCam = GameObject.FindWithTag("ARCam");
        if (Physics.Raycast(ARCam.transform.position, ARCam.transform.forward, out hit))
        {
            if (hit.transform.name == "Floor")
            {
                var flooor = GameObject.FindGameObjectWithTag("Floor");
                float x = ARCam.transform.position[0];
                float y = flooor.transform.position[1] + 0.05f;
                float z = ARCam.transform.position[2] + 1;
                Vector3 BedPos = new Vector3(x, y, z);
                Quaternion BedRot = new Quaternion(0, 180, 0, 1);
                if (BedNumber == 1)
                {
                    Instantiate(Bed1, BedPos, BedRot);
                    bedPlaced = true;
                }
                if (BedNumber == 2)
                {
                    Instantiate(Bed2, BedPos, BedRot);
                    bedPlaced = true;
                }
                if (BedNumber == 3)
                {
                    Instantiate(Bed3, BedPos, BedRot);
                    bedPlaced = true;
                }
                Instantiate(CanvasLevel3obj);
                var Canvas2 = GameObject.FindGameObjectWithTag("Canv2");
                Destroy(Canvas2);


            }


        }
    }

}
