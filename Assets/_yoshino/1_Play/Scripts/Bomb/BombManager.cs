using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField, Header("アイテムカウンター")]
    private ItemCounter itemCounter;

   

    [SerializeField, Header("ボムスポナー")]
    private Spawner[] spawner = new Spawner[20];

   

    [SerializeField, Header("ボム演出の時間")]
    private float bombTime = 2f;

    private EnemyBase enemyBase;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if (itemCounter.GetisBombChargeMax())
            {
                itemCounter.ResetBombChargeCounter();
                for(int i = 0; i < spawner.Length; i++)
                {
                    spawner[i].SpawnBomb();
                }
                EnemyDelete();
            }


        }
    }

    private IEnumerator ActionBomb(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);  // 2秒待機
        EnemyDelete();
       
    }

    private void EnemyDelete()
    {
        // "Enemy"タグを持つ全てのGameObjectを取得
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 取得したGameObjectを一つずつ破壊
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name.Contains("EnemyBullet"))
            {
                // 弾の破壊
                Destroy(enemy);
                continue;
            }

            enemyBase = enemy.GetComponent<EnemyBase>();
            // 敵の死亡演出へ
            enemyBase.Dead();
        }
    }

   
}
