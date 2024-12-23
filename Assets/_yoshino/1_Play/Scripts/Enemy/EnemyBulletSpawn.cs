using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    [SerializeField, Header("弾")]
    private GameObject bullet;
    [SerializeField, Header("発射間隔")]
    private float intervalSpawnBullet;
    private float timerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // タイマーの初期化
        timerSpawn = intervalSpawnBullet;
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
            timerSpawn = intervalSpawnBullet;
            Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);
        }
        timerSpawn += -Time.deltaTime;
    }
}
