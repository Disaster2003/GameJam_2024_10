using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class PlayerController : MonoBehaviour
{   

    //移動量x
    private float _x;
    //移動量y
    private float _y;
    //体力
    public int _currentHP;

    //移動範囲（X方向　_xLimit=-方向　_xLimit2=+方向）
    public float _xLimit;
    public float _xLimit2;

    //移動範囲（Y方向）
    public float _yLimit;

    //移動スピードと点滅の間隔
    [SerializeField] float _speed;
    //点滅させるためのSpriteRenderer
    SpriteRenderer _sp;
    //コライダーをオンオフするためのCircleCollider2D
    CircleCollider2D _cc2d;

    //ダメージ処理
    public int _st;//操作ステータス
    public int _pst;//無敵ステータス
    public float _timer;//ヒットストップ
    public float _timer2;//無敵処置
    public float _Mtimer;
    public bool _HitStop;

    // 点滅させる対象
    [SerializeField] private Renderer _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;


    //攻撃
    public GameObject BulletObj;  // 弾のゲームオブジェクト
    Vector3 bulletPoint;                // 弾の位置
   



    private void Start()
    {
        _pst = 0;
        _st = 1;
        
        //SpriteRenderer格納
       _sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D格納
       _cc2d = GetComponent<CircleCollider2D>();

        //玉の発射ポイント
        bulletPoint = transform.Find("BulletPoint").localPosition;
       
    }


    // Update is called once per frame
    void Update()
    {

        //ヒットストップ
        if (_HitStop == false)
        {
            if (_st == 1)
            {
                _x = Input.GetAxisRaw("Horizontal");
                _y = Input.GetAxisRaw("Vertical");
                transform.Translate(new Vector3(_x, _y, 0) * _speed * Time.deltaTime);


                //現在のポジションを保持する
                Vector3 currentPos = transform.position;

                //Mathf.ClampでX,Yの値それぞれが最小～最大の範囲内に収める。
                //範囲を超えていたら範囲内の値を代入する
                currentPos.x = Mathf.Clamp(currentPos.x, -_xLimit, _xLimit2);
                currentPos.y = Mathf.Clamp(currentPos.y, -_yLimit, _yLimit);

                //追加　positionをcurrentPosにする
                transform.position = currentPos;



                Tama();
            }



            //無敵処理
            if (_pst == 1)
            {
                
               _Mtimer += Time.deltaTime;
                _cc2d.enabled = false;
                // 周期cycleで繰り返す値の取得
                // 0～cycleの範囲の値が得られる
                var repeatValue = Mathf.Repeat((float)_Mtimer, _cycle);
                // 内部時刻timeにおける明滅状態を反映
                _target.enabled = repeatValue <= _cycle * 0.5f;

               
                _timer2 += Time.deltaTime;
                if (_timer2 >= 5f)
                {
                    _Mtimer = 0;
                    _timer2 = 0;
                    _cc2d.enabled = true;
                    _sp.color = Color.white;
                    _pst = 0;
                }
            }
        }
    }


    void Tama()
    {
        // 玉発射ボタン
        if (Input.GetKeyDown("space"))
        {
            // 弾の生成
            Instantiate(BulletObj, transform.position + bulletPoint, Quaternion.identity);
        }
      
       
    }


    void FixedUpdate()
    {
        //ヒットストップ
        if (_HitStop)
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.5f)
            {
                _timer = 0;
                _HitStop = false;
                _st = 1;


                
            }

        }

        

    }

    //当たったときの処理
    void OnTriggerEnter2D(Collider2D collision)
    {


        //エネミーヒットでダメージ
        if (collision.gameObject.tag == "Enemy")
        {
            _currentHP = _currentHP - 1;
            _HitStop = true;
            _Mtimer = 0;
            _pst = 1;

        }
        

        //回復系ヒットで回復（MAX　HP10まで）
        if (collision.gameObject.tag == "Life")
        {
            _currentHP = _currentHP + 1;

            if (_currentHP > 10)
            {
                _currentHP = 10;

            }
            Debug.Log("Life");
        }
    }

    



}
