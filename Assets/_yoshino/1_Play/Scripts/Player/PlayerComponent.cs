using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerComponent : MonoBehaviour
{
    private static PlayerComponent instance;

    private Rigidbody2D rb;

    [SerializeField, Header("初期位置")]
    private Vector3 positionInitialize;

    private Vector3 inputMove;
    [SerializeField, Header("移動速度")]
    private float speedMove;
    [SerializeField, Header("移動範囲")]
    private Vector3 positionMoveLimit;

    [SerializeField, Header("弾")]
    private GameObject bullet;
    [SerializeField, Header("爆弾")]
    private GameObject bomb;

    [SerializeField, Header("最大体力")]
    private int hpMax;
    private int hp;

    private SpriteRenderer sr;
    private bool isInvincible;
    [SerializeField, Header("無敵時間")]
    private float timeInvincible;
    [SerializeField, Header("キー入力不可時間")]
    private float timeImpossibleInputKey;
    private float timerInvincible;
    [SerializeField, Header("点滅周期")]
    private float cycleBlink;

    private Animator animator;

    [SerializeField, Header("通常時の画像")]
    private Sprite normalSprite;

    [SerializeField, Header("被弾時の画像")]
    private Sprite hitSprites;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // インスタンスの生成
            instance = this;
        }

        rb = GetComponent<Rigidbody2D>(); // コンポーネントの取得
        rb.freezeRotation = true;         // 回転不可

        // 初期配置
        transform.position = positionInitialize;

        // 入力の初期化
        inputMove = Vector3.zero;

        // 体力の初期化
        hp = hpMax;

        // 無敵関連の初期化
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        isInvincible = false;
        timerInvincible = 0;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HitEffect();

        // ダメージ時は動けない
        if (timerInvincible > timeInvincible - timeImpossibleInputKey) return;
        Move();
        SpawnBullet();
        SpawnBomb();
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static PlayerComponent GetInstance() {  return instance; }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        // コントローラーなら、GetAxis
        inputMove.x = Input.GetAxisRaw("Horizontal");
        inputMove.y = Input.GetAxisRaw("Vertical");
        transform.Translate(inputMove * speedMove * Time.deltaTime);

        ReturnBackPosition(positionMoveLimit);
    }

    /// <summary>
    /// 範囲内へ位置を矯正する
    /// </summary>
    /// <param name="positionLimit">制限範囲の位置</param>
    private void ReturnBackPosition(Vector3 positionLimit)
    {
        // nullチェック
        if(positionLimit == Vector3.zero) return;

        // 位置を指定された範囲内へ
        Vector3 positionRange = Vector3.zero;
        positionRange.x = Mathf.Clamp(transform.position.x, -positionLimit.x, positionLimit.x);
        positionRange.y = Mathf.Clamp(transform.position.y, -positionLimit.y, positionLimit.y);
        transform.position = positionRange;
    }

    /// <summary>
    /// 弾を生成する
    /// </summary>
    private void SpawnBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    /// <summary>
    /// 爆弾を生成する
    /// </summary>
    private void SpawnBomb()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bomb, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // nullチェック
        if (collision == null) return;

        if(collision.CompareTag("Enemy"))
        {
            // 無敵中
            if (isInvincible) return;

            // ダメージ
            hp--;
            isInvincible = true;
            timerInvincible = timeInvincible;

            SetDamageSprite();

        }
    }

    /// <summary>
    /// 体力を取得する
    /// </summary>
    public int GetHp() {  return hp; }

    /// <summary>
    /// ヒットエフェクト
    /// </summary>
    private void HitEffect()
    {
        if (!isInvincible)
        {
            // 通常状態
            sr.color = Color.white;
            return;
        }

        if(timerInvincible <= 0)
        {
            // 無敵終了
            isInvincible = false;
            animator.enabled = true;
            sr.sprite = normalSprite;
            sr.enabled = true;
        }
        else
        {
            // 無敵時間の減少
            timerInvincible += -Time.deltaTime;
            // 内部時刻timeにおける明滅状態を反映
            sr.enabled = Mathf.Repeat(timerInvincible, cycleBlink) <= cycleBlink * 0.5f;
        }
    }

    public void SetDamageSprite()
    {
        animator.enabled = false;
        sr.sprite = hitSprites;
    }

}
