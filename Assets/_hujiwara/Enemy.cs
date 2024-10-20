using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Life life;
    int EnemyHP = 5;            //敵のHP
    Rigidbody2D rb;
    float at = 1f;              //エネミーの攻撃力
    public float PHP = 1f;      //プレイヤーのHP(仮)
    public float EAI = 1f;             //Enemies Appear Intervalの略，敵が出現する間隔
    public float EAPY = 0f;             //－－positionの略,エネミーがが出現するｙ座標
    public float EMS = 3f;             //Enemy Move Speedの略、エネミーの移動速度
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = GetComponent<Life>();
        InvokeRepeating(nameof(Appear), 0f, EAI);
    }
   
    void Appear()           //エネミーを右から出現させる処理
    {
        Vector3 EAP = new Vector3(Screen.width, EAP, 0);
        EAP = Camera.main.ScreenToWorldPoint(EAP);
        EAP.z = 0;
    }
    void Eattack(Collision collision)                  //敵の攻撃
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // PHP php = collision.gameObject.GetComponent<PHP>      //プレイヤーのスクリプト名がわからないので
       Debug.Log("プレイヤーがダメージを受けた");                   //コメントにしています（エネミーがプレイヤーに
        }                                                           //に当たった時の処理)    
        
        
    }

    void TakeDamege(int damege)     //敵がダメージを受けるときの処理
    {
        EnemyHP -= 1;          //damegeを受けたらHP減少
        if (EnemyHP < 0)            //EnemyHPが0以下になったらDieを送る
        {
            EnemyHP = 0;
            life.Die();
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-1f, rb.velocity.y);  //左に進む
    }
}
