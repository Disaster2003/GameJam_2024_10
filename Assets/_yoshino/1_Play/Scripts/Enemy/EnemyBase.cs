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

    [SerializeField, Header("半透明化の時間")]
    private float timeDeath;
    private float timerUntilDeath;

    [SerializeField, Header("半透明時の見た目")]
    private Sprite DeathSprite;

    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; // 回転不可

        // タイマーの初期化
        timerUntilDeath = 0;
    }

    private void FixedUpdate()
    {
        if (GetDeathFlag())
        {
            if (timerUntilDeath >= timeDeath)
            {
                // 自身の破壊
                Destroy(gameObject);
            }
            // 死が迫る
            timerUntilDeath += Time.fixedDeltaTime;
        }         
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
                // 死亡開始
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

        // 半透明化
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        // 画像の切り替え
        GetComponent<SpriteRenderer>().sprite = DeathSprite;
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

    public bool GetDeathFlag()
    {
        //半透明の状態だとtrueを返す
        return GetComponent<SpriteRenderer>().color.a != 1;
    }
}
