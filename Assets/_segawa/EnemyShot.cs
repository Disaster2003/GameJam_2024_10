using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject Shot;             //弾のプレビュー
    public float wait;                  //待機時間


    private float spawnwait;          //待機時間の処理

    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;

    }

    // Update is called once per frame
    void Update()
    {
            ShotSpawn();
    }

    //弾をスポーンさせる関数
    public void ShotSpawn()
    {
        spawnwait += Time.deltaTime;
        //待機時間を超えたら弾をスポーンさせる
        if (spawnwait >= wait)
        {
            Instantiate(Shot, transform.position, transform.rotation);
            spawnwait = 0;

        }
    }
}
