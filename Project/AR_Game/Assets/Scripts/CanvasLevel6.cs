using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevel6 : MonoBehaviour
{
    public GameObject CatTextBuy, HandImg, BuyButton, MoneyErrorText, PlaceBookButton, LooseText, QButtons, RButton, CanvasLevel7obj, BookMenuButton, Canvas3DBooks, Book1, Book2, PlacementAnchorImage, RoomAudio;
    public static bool BookReq = false;
    public static bool BookPlaced = false;
    public int BookNumber;
    // Start is called before the first frame update
    void Start()
    {
        HandImg.SetActive(false);
        BuyButton.SetActive(false);
        MoneyErrorText.SetActive(false);
        PlaceBookButton.SetActive(false);
        LooseText.SetActive(false);
        QButtons.SetActive(false);
        RButton.SetActive(false);
        PlacementAnchorImage.SetActive(false);
        BookMenuButton.SetActive(false);
        CatTextBuy.SetActive(false);
        Instantiate(RoomAudio);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerNear.isNear == true && BookReq == false)
        {
            BookMenuButton.SetActive(true);
            CatTextBuy.SetActive(true);
        }
        else
        {
            BookMenuButton.SetActive(false);
            CatTextBuy.SetActive(false);
        }
    }

    public void ChairMenuBut()
    {
        BookReq = true;
        BookMenuButton.SetActive(false);
        CatTextBuy.SetActive(false);
        var ARCam = GameObject.FindWithTag("ARCam");
        float x = ARCam.transform.position[0] + Canvas3DBooks.transform.position[0];
        float y = ARCam.transform.position[1] + Canvas3DBooks.transform.position[1];
        float z = ARCam.transform.position[2] + Canvas3DBooks.transform.position[2];
        Vector3 posi = new Vector3(x, y, z);

        Instantiate(Canvas3DBooks, posi, Quaternion.identity);

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
            if (hited.transform.tag == "Book400")
            {
                if (GameData.Coins >= 400)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3DBooks");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceBookButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 400;
                    BookNumber = 1;
                    GameData.BookTag = "Book400";

                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }

            if (hited.transform.tag == "Book450")
            {
                if (GameData.Coins >= 500)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3DBooks");
                    Destroy(canv3);
                    QButtons.SetActive(false);
                    RButton.SetActive(false);
                    BuyButton.SetActive(false);
                    HandImg.SetActive(false);
                    PlaceBookButton.SetActive(true);
                    PlacementAnchorImage.SetActive(true);
                    GameData.Coins -= 500;
                    BookNumber = 2;
                    GameData.BookTag = "Book450";
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
                float y = flooor.transform.position[1] + 0.1f;
                float z = ARCam.transform.position[2] + 1;
                Vector3 BookPos = new Vector3(x, y, z);
                Quaternion ChairRot = new Quaternion(0, 0, 0, 1);

                if (BookNumber == 1)
                {

                    Instantiate(Book1, BookPos, ChairRot);
                    BookPlaced = true;
                }
                if (BookNumber == 2)
                {
                    Instantiate(Book2, BookPos, ChairRot);
                    BookPlaced = true;
                }

                Instantiate(CanvasLevel7obj);
                var Canvas6 = GameObject.FindGameObjectWithTag("Canv6");
                Destroy(Canvas6);


            }


        }
    }

}
