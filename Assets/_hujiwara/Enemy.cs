using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemyprefab;
    private Life life;
    int EnemyHP = 5;                   //敵のHP
    Rigidbody2D rb;
    public float at = 1f;              //エネミーの攻撃力
    public float Espeed;               //エネミーのスピード
    public float PHP = 1f;             //プレイヤーのHP(仮)
    public float EAI = 1f;             //Enemies Appear Intervalの略，敵が出現する間隔
    public float EAPY = 0f;            //－－positionの略,エネミーがが出現するｙ座標
    public float EMS = 3f;             //Enemy Move Speedの略、エネミーの移動速度
    public float duration = 2.0f; // 演出の所要時間（秒）
    public int transparency = 128; // 透明度 (0 ～ 255)
    private float elapsedTime = 0.0f; // 経過時間
    private bool isEffectPlaying = false; // 演出が再生中かどうかのフラグ
    private SpriteRenderer sr; // エネミーのスプライトレンダラー


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = GetComponent<Life>();
        InvokeRepeating(nameof(Appear), 0f, EAI);
        sr = GetComponent<SpriteRenderer>();
    }
   
   　public void Appear()           //エネミーを右から出現させる処理
    {
        Vector3 EAP = new Vector3(Screen.width, EAPY, 0);
        EAP = Camera.main.ScreenToWorldPoint(EAP);
        EAP.z = 0;

        GameObject enemy = Instantiate(enemyprefab, EAP, Quaternion.identity);
        StartCoroutine(MoveEnemy(enemy));
    }

    private System.Collections.IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            enemy.transform.position += Vector3.left * Espeed * Time.deltaTime;
            if (enemy.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)        //画面外に出たら破棄
            {
                Destroy(enemy);
            }
            yield return null;          //次のフレームまで待つ
        }
    }
    public void Eattack(Collision collision)                  //敵の攻撃
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // PHP php = collision.gameObject.GetComponent<PHP>      //プレイヤーのスクリプト名がわからないので
       Debug.Log("プレイヤーがダメージを受けた");                   //コメントにしています（エネミーがプレイヤーに
        }                                                           //に当たった時の処理)    
        
        
    }
    public void Animation()           //この関数名は(仮)です,
    {                                 //この関数が呼び出されると、エネミーの透明度が即時に設定され、演出が開始されます。
        // 透明度を設定
        stp(transparency);
        elapsedTime = 0.0f; // 経過時間をリセット
        isEffectPlaying = true; // 演出を再生状態に設定

    }
    private void stp(int alpha)       // スプライトの透明度を設定する関数,SetTransparencyの略
    {
        Color color = sr.color;
        color.a = Mathf.Clamp(alpha / 255f, 0f, 1f); // 0 ～ 1 の範囲に正規化
        sr.color = color;
    }

    public void Damege(int damege)     //敵がダメージを受けるときの処理
    {
        EnemyHP -= 1;          //damegeを受けたらHP減少
        if (EnemyHP < 0)            //EnemyHPが0以下になったらDieを送る
        {
            EnemyHP = 0;
            life.Die();
        }
    }
    
    public void UnNormalDestory()   //ボムなどのアイテムドロップしない
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        if (EnemyHP < 0)
        {
            life.NormalDestory();
        }

        if (isEffectPlaying)
        {
            elapsedTime += Time.deltaTime;       // 経過時間を更新
            if (elapsedTime >= duration)         // 経過時間が所要時間を超えた場合
            {
                isEffectPlaying = false;         // 演出終了
                /*ここに破壊処理を追加*/
                Destroy(gameObject);
            }
        }
    }
}
