using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider Col)
    {

        if (Col.name == "StoneMonster(Clone)")
        {
            if(GameData.Health > 0)
            {
                GameData.Health -= 1;
            }

            Destroy(Col.gameObject);
        }
    }
}
