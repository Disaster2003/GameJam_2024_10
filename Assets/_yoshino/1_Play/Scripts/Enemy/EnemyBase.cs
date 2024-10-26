using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("最大体力")]
    private int Maxhp;

    private int hp;

    [SerializeField, Header("HPバー")]
    private GameObject slider;

    Slider hpSlider;

    [SerializeField, Header("HPバー表示時間")]
    private float sliderVisbleTimeBace = 0.5f;

    private float sliderVisbleTime = 0.5f;

    private bool isVisibleSlider = false;

    [SerializeField, Header("アイテム")]
    private GameObject item;
    [SerializeField, Header("1/?でアイテムドロップ")]
    private int probability;

    [SerializeField, Header("半透明化の時間")]
    private float timeDeath;
    private float timerUntilDeath;

    [SerializeField, Header("半透明時の見た目")]
    private Sprite DeathSprite;

    EnemyRapidFire enemyRapidFire;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; // 回転不可
        boxCollider = GetComponent<BoxCollider2D>();
        enemyRapidFire = GetComponent<EnemyRapidFire>();

        // タイマーの初期化
        timerUntilDeath = 0;
        hp = Maxhp;

        hpSlider = slider.GetComponent<Slider>();

        slider.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (GetDeathFlag())
        {
            if (timerUntilDeath >= timeDeath)
            {
                Debug.Log(1);
                // 自身の破壊
                Destroy(gameObject);
            }
            // 死が迫る
            timerUntilDeath += Time.fixedDeltaTime;
        }         

        if(isVisibleSlider)
        {
            sliderVisbleTime -= Time.deltaTime;
            if(sliderVisbleTime<0)
            {
                isVisibleSlider = false;
                slider.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // nullチェック
        if (collision == null) return;

        if (collision.CompareTag("Bullet"))
        {
            BulletComponent bullet = collision.GetComponent<BulletComponent>();

            if (bullet == null) return;

            if (bullet.GetisPlayerBullet())
            {
                // ダメージ
                hp--;

                if (!isVisibleSlider)
                {
                    slider.SetActive(true);

                    hpSlider.value = (float)hp / (float)Maxhp;

                    isVisibleSlider = true;
                    sliderVisbleTime = sliderVisbleTimeBace;
                }
                else
                {
                    hpSlider.value = (float)hp / (float)Maxhp;
                }
                

                if (hp <= 0)
                {
                    // 死亡開始
                    Dead();
                }
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

        if(boxCollider != null)
        {
            boxCollider.enabled = false;
        }
       
        if(enemyRapidFire != null)
        {
            enemyRapidFire.enabled = false;
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

    public void DestroyWhenExitScreen()
    {
        if(transform.localPosition.x<-10)
        {
            Destroy(gameObject);
        }
    }

}
