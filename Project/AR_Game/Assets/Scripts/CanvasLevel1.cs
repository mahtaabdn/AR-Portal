using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class CanvasLevel1 : MonoBehaviour
{
    public GameObject PlaceRoomText, PlacementAnchorImage, ReadyButton, CatText, ShootImage, ShootButton, LooseText, CanvasLevel2obj, QButtons, RButton;
    public static bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        ReadyButton.SetActive(false);
        CatText.SetActive(false);
        ShootButton.SetActive(false);
        ShootImage.SetActive(false);
        LooseText.SetActive(false);
        QButtons.SetActive(false);
        RButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.GameOver == true)
        {
            ShootButton.SetActive(false);
            ShootImage.SetActive(false);
            LooseText.SetActive(true);
            QButtons.SetActive(true);
            RButton.SetActive(true);
        }

        if (PlacementManager.Oneobj == true)
        {
            PlaceRoomText.SetActive(false);
            PlacementAnchorImage.SetActive(false);
        }

        if(PlayerNear.isNear == true && ready == false)
        {
            ReadyButton.SetActive(true);
            CatText.SetActive(true);
        }
        else
        {
            ReadyButton.SetActive(false);
            CatText.SetActive(false);
        }
        if(TimeBoard.levelFinish == true)
        {
            Instantiate(CanvasLevel2obj);
            var Canvas1 = GameObject.FindGameObjectWithTag("Canv1");
            Destroy(Canvas1);
        }
    }

    public void ReadyBut()
    {
        ready = true;
        ShootButton.SetActive(true);
        ShootImage.SetActive(true);
        SpawnMonster.once = false;
        var RoomAu = GameObject.FindGameObjectWithTag("Audio1");
        Destroy(RoomAu);
    }

    public void RestartBut()
    {
        PlacementManager.Oneobj = false;
        ready = false;
        SpawnMonster.once = false;
        TimeBoard.levelFinish = false;
        SceneManager.LoadScene(0);
    }
    public void QuitBut()
    {
        Application.Quit();
    }
}
