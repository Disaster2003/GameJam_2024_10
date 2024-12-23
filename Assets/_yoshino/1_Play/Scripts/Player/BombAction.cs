using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    private void FixedUpdate()
    {
        // ポーズ中
        if(GameManager.GetInstance().GetIsPausing()) return;

        //EnemyDelete();
    }

    /// <summary>
    /// 敵を消去する
    /// </summary>
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

            // 敵の死亡演出へ
            GetComponent<EnemyBase>().Dead();
        }
    }

    public void BombActionResult()
    {
        EnemyDelete();
    }
}
