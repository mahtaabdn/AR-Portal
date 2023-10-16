using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int Health;
    public static int Coins;
    public static int LevelWaiting;
    public static bool GameOver;
    public static int GameLevel;
    public static float levelSpeed;
    public static string BedTag;
    public static string ChairTag;
    public static string BookTag;
    public static bool BedPlaced = false;
    public static bool ChairPlaced = false;
    public static bool BookPlaced = false;
    public static bool OpenClick = false;
    // Start is called before the first frame update
    void Start()
    {
        Health = 5;
        Coins = 0;
        LevelWaiting = 4;
        GameOver = false;
        GameLevel = 1;
        levelSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            GameOver = true;
        }
    }
}
