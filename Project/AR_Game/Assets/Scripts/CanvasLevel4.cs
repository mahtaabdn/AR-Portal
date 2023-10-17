using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevel4 : MonoBehaviour
{
    public GameObject CatTextBuy, HandImg, BuyButton, MoneyErrorText, PlaceChairButton, LooseText, QButtons, RButton, CanvasLevel5obj, ChairMenuButton, Canvas3DChairs, Chair1, Chair2, Chair3, PlacementAnchorImage, RoomAudio;
    public static bool ChairReq = false;
    public static bool chairPlaced = false;
    public int ChairNumber;
    // Start is called before the first frame update
    void Start()
    {
        HandImg.SetActive(false);
        BuyButton.SetActive(false);
        MoneyErrorText.SetActive(false);
        PlaceChairButton.SetActive(false);
        LooseText.SetActive(false);
        QButtons.SetActive(false);
        RButton.SetActive(false);
        PlacementAnchorImage.SetActive(false);
        ChairMenuButton.SetActive(false);
        CatTextBuy.SetActive(false);
        Instantiate(RoomAudio);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerNear.isNear == true && ChairReq == false)
        {
            ChairMenuButton.SetActive(true);
            CatTextBuy.SetActive(true);
        }
        else
        {
            ChairMenuButton.SetActive(false);
            CatTextBuy.SetActive(false);
        }

    }

    public void ChairMenuBut()
    {
        ChairReq = true;
        ChairMenuButton.SetActive(false);
        CatTextBuy.SetActive(false);
        var ARCam = GameObject.FindWithTag("ARCam");
        float x = ARCam.transform.position[0] + Canvas3DChairs.transform.position[0];
        float y = ARCam.transform.position[1] + Canvas3DChairs.transform.position[1];
        float z = ARCam.transform.position[2] + Canvas3DChairs.transform.position[2];
        Vector3 posi = new Vector3(x, y, z);

        Instantiate(Canvas3DChairs, posi, Quaternion.identity);

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
            if (hited.transform.tag == "Chair320")
            {
                if (GameData.Coins >= 320)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3DChairs");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceChairButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 320;
                    ChairNumber = 1;
                    GameData.ChairTag = "Chair320";

                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }

            if (hited.transform.tag == "Chair345")
            {
                if (GameData.Coins >= 345)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3DChairs");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceChairButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 345;
                    ChairNumber = 2;
                    GameData.ChairTag = "Chair345";
                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }

            if (hited.transform.tag == "Chair370")
            {
                if (GameData.Coins >= 370)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3DChairs");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceChairButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 370;
                    ChairNumber = 3;
                    GameData.ChairTag = "Chair370";
                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }
        }
    }

    public void PutChairBut()
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
                Vector3 ChairPos = new Vector3(x, y, z);
                Quaternion ChairRot = new Quaternion(0, 180, 0, 1);
                if (ChairNumber == 1)
                {
                    Instantiate(Chair1, ChairPos, ChairRot);
                    chairPlaced = true;
                }
                if (ChairNumber == 2)
                {
                    Instantiate(Chair2, ChairPos, ChairRot);
                    chairPlaced = true;
                }
                if (ChairNumber == 3)
                {
                    Instantiate(Chair3, ChairPos, ChairRot);
                    chairPlaced = true;
                }
                Instantiate(CanvasLevel5obj);
                var Canvas4 = GameObject.FindGameObjectWithTag("Canv4");
                Destroy(Canvas4);


            }


        }
    }

}
