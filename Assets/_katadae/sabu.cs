using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class sabu : MonoBehaviour
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
    [SerializeField] float _speed, _flashInterval;
    //点滅させるときのループカウント
    [SerializeField] int _loopCount;
    //点滅させるためのSpriteRenderer
    SpriteRenderer _sp;
    //コライダーをオンオフするためのBoxCollider2D
    CircleCollider2D _cc2d;

    //(ステータス _st=1(ノーマル）_st=2=（ダメージ）_st=3=(無敵)
    public int _st;

    public float _Count;
    private float _timar;

    //攻撃
    public GameObject BulletObj;  // 弾のゲームオブジェクト
    Vector3 bulletPoint;                // 弾の位置




    private void Start()
    {
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
        
        //パターン2


        //ステートがダメージならリターン
        if (_st == 2)
        {
            return;
        }


        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(_x, _y, 0) * _speed * Time.deltaTime);


        //現在のポジションを保持する
        Vector3 currentPos = transform.position;

        //Mathf.ClampでX,Yの値それぞれが最小〜最大の範囲内に収める。
        //範囲を超えていたら範囲内の値を代入する
        currentPos.x = Mathf.Clamp(currentPos.x, -_xLimit, _xLimit2);
        currentPos.y = Mathf.Clamp(currentPos.y, -_yLimit, _yLimit);

        //追加　positionをcurrentPosにする
        transform.position = currentPos;



        Tama();
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
        //this.transform.Translate(_vx/50, _vy/50, 0);

    }


    //当たったときの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {


        //エネミーヒットでダメージ
        if (collision.gameObject.tag == "Enemy")
        {
            _currentHP = _currentHP - 1;

            //ノーマルじゃない（ダメージ中、無敵中）ときはリターン
            if (_st != 1)
            {
                return;
            }
            _st = 2;
            _hit();


        }


        //IEnumerator _hit()
        //{
        //    //_Count += Time.deltaTime;
        //    _cc2d.enabled = false;
        //    for (int i = 0; i < _loopCount; i++)
        //    {


        //        yield return new WaitForSeconds(_flashInterval);
        //        _sp.enabled = false;
        //        yield return new WaitForSeconds(_flashInterval);
        //        _sp.enabled = true;
        //        if (i > 20)
        //        {
        //            _st = 3;

        //            //if (_st == 3&&_Count>=10f)
        //            //{


        //            //}
        //        }
        //    }

        //    _st=1;
        //    _cc2d.enabled = true;
        //    _sp.color = Color.white;
        //}


        void _hit()
        {
            _cc2d.enabled = false;
            _timar += Time.deltaTime;
            if (_timar >=2.0f)
            {
                _cc2d.enabled = true;
                _timar = 0;
              
               
            }
            // _st = 1;
            _st = 3;
            //_sp.color = Color.white;

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