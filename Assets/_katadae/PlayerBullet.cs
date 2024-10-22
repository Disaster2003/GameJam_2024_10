using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float MoveSpeed;         // 移動値
    GameObject playerObj = null;     // プレイヤーオブジェクト
    int frameCount = 0;             // フレームカウント
    public  int deleteFrame;    // 削除フレーム(650推奨）

 
  

    // Start is called before the first frame update
    void Start()
    {
        // ヒエラルキービューにある player を取得
        playerObj = GameObject.Find("Player");
    }


 

    // Update is called once per frame
    void Update()
    {
        // 位置の更新
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        float distance = (playerObj.transform.position - transform.position).sqrMagnitude;

        // 一定フレームで消す
        if (++frameCount > deleteFrame)
        {
            Destroy(gameObject);
        }

       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {


        //エネミーヒットでダメージ
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);

        }
    }

  }
