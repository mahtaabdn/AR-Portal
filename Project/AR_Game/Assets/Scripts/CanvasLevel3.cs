using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevel3 : MonoBehaviour
{
    public GameObject CatTextReady, ReadyButton, ShootImage, ShootButton, LooseText, QButtons, RButton, CanvasLevel4obj;
    public static bool ready2 = false;
    // Start is called before the first frame update
    void Start()
    {
        CatTextReady.SetActive(false);
        ReadyButton.SetActive(false);
        ShootImage.SetActive(false);
        ShootButton.SetActive(false);
        QButtons.SetActive(false);
        RButton.SetActive(false);
        LooseText.SetActive(false);
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

        if (GameData.BedPlaced == true && ready2 == false)
        {
            if(PlayerNear.isNear == true)
            {
                CatTextReady.SetActive(true);
                ReadyButton.SetActive(true);
            }
            else
            {
                CatTextReady.SetActive(false);
                ReadyButton.SetActive(false);
            }

        }
        if (TimeBoard.levelFinish == true && ready2 == true)
        {
            Instantiate(CanvasLevel4obj);
            var Canvas3 = GameObject.FindGameObjectWithTag("Canv3");
            ready2 = false;
            Destroy(Canvas3);
        }
    }


    public void Ready2But()
    {
        var RoomAu = GameObject.FindGameObjectWithTag("Audio1");
        Destroy(RoomAu);
        GameData.LevelWaiting -= 1;
        GameData.levelSpeed += 0.2f;
        CatTextReady.SetActive(false);
        ReadyButton.SetActive(false);
        ShootImage.SetActive(true);
        ShootButton.SetActive(true);
        TimeBoard.StopSpawning = false;
        TimeBoard.levelFinish = false;
        ready2 = true;
        SpawnMonster.once = false;

        TimeBoard.CountDown = TimeBoard.MaxTime;
        TimeBoard.CountDownint = System.Convert.ToInt32(TimeBoard.MaxTime);

    }
}
