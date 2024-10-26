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
                BulletDelete();
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
            // 敵の死亡演出へ
            EnemyBase enemybase = enemy.GetComponent<EnemyBase>();
            enemybase.Dead();
        }

    }

    
    private void BulletDelete()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            BulletComponent bulletComponent = bullet.GetComponent<BulletComponent>();

            if (bulletComponent != null)
            {
                if (!bulletComponent.GetisPlayerBullet())
                {
                    bulletComponent.DestoryBullet();
                    continue;
                }
            }
        }
    }


}
