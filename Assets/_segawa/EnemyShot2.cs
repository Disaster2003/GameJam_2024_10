using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot2 : EnemyShot
{
    public int RapidShot;   //連射弾数
    public float RapidWait; //連射間隔

    private float rapidmati;    //連射間隔の処理
    private int rapidtama;      //連射弾数の処理
    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;
        rapidmati = RapidWait;
        rapidtama = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)  //待機時間を超えたら
        {
            for (int i=0;i<RapidShot;i++)//設定した数弾を撃つ
            {
                if (rapidmati <= 0) rapidshot();
            }
            if(rapidtama==10)rapidreset();
            if(rapidmati!=0) rapidmati -= Time.deltaTime;

        }
    }

    //連射の弾を撃つ
    private void rapidshot()
    {
        ShotSpawn();
        rapidmati = 0;
        rapidtama++;
        rapidmati = RapidWait;
    }

    //連射のリセット
    private void rapidreset()
    {
        spawnwait = 0;
        rapidtama = 0;

    }
}
