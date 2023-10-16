using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] balloons;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(1);

        i = Random.Range(0, 10);
        Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);


        StartCoroutine(StartSpawning());

    }
}
