using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot1 : EnemyShot //EnemyShot wo keishou
{
    private float spawnwait;
    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;

    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)  //taikizikan wo koetara
        {
            ShotSpawn();
        }

    }


}
