using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class CanvasPlane : MonoBehaviour
{
    public GameObject placetext, placementImage, NextLevelButton, CatText, ShootImage, ShootButton, WinLooseText, RestartButton, QuitButton, CatTextOne, ARCam, Canvas3D, BuyButton, HandImg, MoneyErrorText, Bed1, Bed2, Bed3 , PlaceBedBut, CatTextTwo, CatTextThree;
    private static bool bedPlaced = false;
    public static bool readyy = false;



    // Start is called before the first frame update
    void Start()
    {
        placetext.SetActive(true);
        placementImage.SetActive(true);
        NextLevelButton.SetActive(false);
        CatText.SetActive(false);
        ShootImage.SetActive(false);
        ShootButton.SetActive(false);
        WinLooseText.SetActive(false);
        RestartButton.SetActive(false);
        QuitButton.SetActive(false);
        CatTextOne.SetActive(false);
        BuyButton.SetActive(false);
        HandImg.SetActive(false);
        MoneyErrorText.SetActive(false);
        PlaceBedBut.SetActive(false);
        CatTextTwo.SetActive(false);
        CatTextThree.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if(PlacementManager.Oneobj == true)
        {
            placetext.SetActive(false);
            placementImage.SetActive(false);
        }

        if(readyy == false)
        {
            if (PlayerNear.isNear == true)
            {
                NextLevelButton.SetActive(true);
                if(GameData.GameLevel == 1)
                    CatText.SetActive(true);
                if(GameData.GameLevel == 2 && bedPlaced == false)
                    CatTextOne.SetActive(true);
                if(bedPlaced == true)
                    CatTextTwo.SetActive(true);
                if (GameData.GameLevel == 3)
                    CatTextThree.SetActive(true);
            }

            else
            {
                NextLevelButton.SetActive(false);
                CatText.SetActive(false);
                CatTextOne.SetActive(false);
                CatTextTwo.SetActive(false);
                CatTextThree.SetActive(false);
            }
        }

        if(GameData.GameOver == true)
        {
            ShootButton.SetActive(false);
            ShootImage.SetActive(false);
            WinLooseText.SetActive(true);
            QuitButton.SetActive(true);
            RestartButton.SetActive(true);
        }

        if(TimeBoard.levelFinish == true && GameData.GameLevel == 1)
        {
            ShootButton.SetActive(false);
            ShootImage.SetActive(false);
        }



    }
    public void LevelButton()
    {
        if(GameData.GameLevel == 1 || bedPlaced == true)
        {
            readyy = true;
            TimeBoard.StopSpawning = false;
            SpawnMonster.once = false;
            ShootButton.SetActive(true);
            ShootImage.SetActive(true);
            TimeBoard.CountDown = TimeBoard.MaxTime;
            TimeBoard.CountDownint = System.Convert.ToInt32(TimeBoard.MaxTime);

            NextLevelButton.SetActive(false);
            CatText.SetActive(false);
            CatTextTwo.SetActive(false);
        }
        if(GameData.GameLevel == 2 && bedPlaced == false)
        {
            //readyy = true;
            NextLevelButton.SetActive(false);
            CatTextOne.SetActive(false);
            float x = ARCam.transform.position[0] + Canvas3D.transform.position[0];
            float y = ARCam.transform.position[1] + Canvas3D.transform.position[1];
            float z = ARCam.transform.position[2] + Canvas3D.transform.position[2];
            Vector3 posi = new Vector3(x, y, z);

            Instantiate(Canvas3D,posi, Quaternion.identity);

            BuyButton.SetActive(true);
            HandImg.SetActive(true);
            QuitButton.SetActive(true);
            RestartButton.SetActive(true);


        }


        //SceneManager.LoadScene(1);
    }

    public void RestartBut()
    {
        PlacementManager.Oneobj = false;
        readyy = false;
        SpawnMonster.once = false;
        TimeBoard.levelFinish = false;
        SceneManager.LoadScene(0);
    }
    public void QuitBut()
    {
        Application.Quit();
    }

    public void BuyBut()
    {
        RaycastHit hited;
        if (Physics.Raycast(ARCam.transform.position, ARCam.transform.forward, out hited))
        {
            if (hited.transform.tag == "Bed200")
            {
                if (GameData.Coins >= 200)
                {
                    MoneyErrorText.SetActive(false);
                    var canv3 = GameObject.FindWithTag("Canvas3D");
                    Destroy(canv3);
                    RestartButton.SetActive(false);
                    QuitButton.SetActive(false);
                    BuyButton.SetActive(false);
                    //HandImg.SetActive(false);
                    PlaceBedBut.SetActive(true);
                    //HandImg.SetActive(true);
                    GameData.Coins -= 200;
                    PlayerPrefs.SetInt("BedNum", 1);

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
                    RestartButton.SetActive(false);
                    QuitButton.SetActive(false);
                    BuyButton.SetActive(false);
                    //HandImg.SetActive(false);
                    PlaceBedBut.SetActive(true);
                    //ShootImage.SetActive(true);
                    GameData.Coins -= 250;
                    PlayerPrefs.SetInt("BedNum", 3);
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
                    RestartButton.SetActive(false);
                    QuitButton.SetActive(false);
                    BuyButton.SetActive(false);
                    //HandImg.SetActive(false);
                    PlaceBedBut.SetActive(true);
                    //ShootImage.SetActive(true);
                    GameData.Coins -= 225;
                    PlayerPrefs.SetInt("BedNum", 2);
                }
                else
                {
                    MoneyErrorText.SetActive(true);
                }
            }
        }
    }

    public void PlaceBed()
    {
        RaycastHit hit;
        if (Physics.Raycast(ARCam.transform.position, ARCam.transform.forward, out hit))
        {
            if (hit.transform.name == "Floor")
            {
                var flooor = GameObject.FindGameObjectWithTag("Floor");
                int BedNumber = PlayerPrefs.GetInt("BedNum");
                float x = ARCam.transform.position[0];
                float y = flooor.transform.position[1];
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
                PlaceBedBut.SetActive(false);
                HandImg.SetActive(false);
                GameData.levelSpeed += 0.1f;
                GameData.LevelWaiting -= 1;
            }

                
        }
    }
}
