using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QRButtons : MonoBehaviour
{
    public void RestartBut()
    {
        var Room = GameObject.FindGameObjectWithTag("Room");
        Destroy(Room);
        PlacementManager.Oneobj = false;
        SpawnMonster.once = true;
        TimeBoard.levelFinish = false;
        CanvasLevel6.BookPlaced = false;
        CanvasLevel6.BookReq = false;
        CanvasLevel5.ready2 = false;
        CanvasLevel4.chairPlaced = false;
        CanvasLevel4.ChairReq = false;
        CanvasLevel3.ready2 = false;
        CanvasLevel2.bedPlaced = false;
        CanvasLevel2.BedReq = false;
        CanvasLevel1.ready = false;
        GameData.BedPlaced = false;
        GameData.ChairPlaced = false;
        GameData.BookPlaced = false;
        SceneManager.LoadScene(0);
    }
    public void QuitBut()
    {
        Application.Quit();
    }
}
