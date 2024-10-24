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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; // 回転不可
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // nullチェック
        if (collision == null) return;

        if (collision.CompareTag("Bullet"))
        {
            // ダメージ
            hp--;

            if (hp <= 0)
            {
                Dead();
            }
        }
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    public void Dead()
    {
        if (hp <= 0)
        {
            ItemDrop();
        }

        // 自身の破壊
        Destroy(gameObject);
    }

    /// <summary>
    /// アイテムを生成する
    /// </summary>
    private void ItemDrop()
    {
        // 確率の探索
        probability = Random.Range(0, probability);
        if (probability == 0)
        {
            // アイテムの生成
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
