using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    [SerializeField, Header("敵")]
    private GameObject[] enemyArray;
    [SerializeField, Header("発射間隔")]
    private float intervalSpawnEnemy;
    private float timerSpawn;
    [SerializeField, Header("生成数の最大値")]
    private int countSpawnMax;
    private int countSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // タイマーの初期化
        timerSpawn = intervalSpawnEnemy;

        // 生成数の初期化
        countSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    /// <summary>
    /// 敵を生成する
    /// </summary>
    private void SpawnEnemy()
    {
        if(countSpawn >= countSpawnMax)
        {
            // 自身の破壊
            Destroy(gameObject);
        }

        if (timerSpawn <= 0)
        {
            timerSpawn = intervalSpawnEnemy;
            countSpawn++;
            int index = Random.Range(0, enemyArray.Length);
            Instantiate(enemyArray[index], transform.position + Vector3.left, Quaternion.identity);
        }
        timerSpawn += -Time.deltaTime;
    }
}
