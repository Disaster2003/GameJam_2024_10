using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot1 : EnemyShot //EnemyShotを継承
{
    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;

    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)  //待機時間を超えたら
        {
            ShotSpawn();
        }

    }


}
