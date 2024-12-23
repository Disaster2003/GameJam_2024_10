using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRapidFire : MonoBehaviour
{
    [SerializeField, Header("弾")]
    private GameObject bullet;
    [SerializeField, Header("発射間隔")]
    private float intervalSpawnBullet;
    private float timerSpawn;

    [SerializeField, Header("弾数")]
    private int ammo;
    private int ammoRemain;
    [SerializeField, Header("連射間隔")]
    private float intervalSpawnRapid;
    private float timerRapid;

    // Start is called before the first frame update
    void Start()
    {
        // タイマーの初期化
        timerSpawn = intervalSpawnBullet;
        timerRapid = intervalSpawnRapid;

        // 弾数の初期化
        ammoRemain = ammo;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
    }

    /// <summary>
    /// 弾を生成する
    /// </summary>
    private void SpawnBullet()
    {
        if (timerSpawn <= 0)
        {
            // 弾の生成
            if(timerRapid <= 0)
            {
                timerRapid = intervalSpawnRapid;
                ammoRemain--;
                Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);

                if(ammoRemain <= 0)
                {
                    timerSpawn = intervalSpawnBullet;
                    ammoRemain = ammo;
                }
            }
            else
            {
                timerRapid -= Time.deltaTime;
            }
        }
        else
        {
            timerSpawn += -Time.deltaTime;
        }
    }
}
