using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject monster;
    int i;
    public static bool once = true;
    public Quaternion MonsterRot = new Quaternion(0, 180, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(once == false)
        {
            StartCoroutine(StartSpawning());
            once = true;
        }

    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(GameData.LevelWaiting);
        if (TimeBoard.StopSpawning == true)
        {
            StopCoroutine(StartSpawning());

        }
        else
        {


            i = Random.Range(0, 10);
            Instantiate(monster, spawnPoints[i].position, MonsterRot);


            StartCoroutine(StartSpawning());
        }

    }
}
