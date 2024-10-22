using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("体力")]
    private int hp;

    [SerializeField, Header("アイテム")]
    private GameObject item;
    [SerializeField, Header("1/?でアイテムドロップ")]
    private int probability;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // nullチェック
        if (collision == null) return;

        if(collision.CompareTag("Bullet"))
        {
            // ダメージ
            hp--;

            if (hp <= 0)
            {
                // 自身の破壊
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        // 確率の探索
        probability = Random.Range(0, probability);
        if(probability == 0)
        {
            // アイテムの生成
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
