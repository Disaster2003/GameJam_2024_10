using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove4 : MonoBehaviour
{
    public Vector2 titen;           //止まる場所
    public float MoveLeftSpeed;     //横移動の速度
    public float MoveUpSpeed;       //上下の速度
    public float Wait;              //待ち時間

    private int yoko;               //横移動から縦移動に変える
    private float matizikan;        // 待ち時間の処理
    // Start is called before the first frame update
    void Start()
    {
        yoko = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight(1);   //右側の指定された方向へ移動 
        LeftRight(-1);  //左側の指定された方向へ移動
        Updown(1); //上に移動
        Updown(-1); //下に移動
        wait();
    }

    //titen.y に-をかける
    //matizikan を設定する
    private void Way()
    {
        titen.y *= -1;
        matizikan =Wait;
    }

    //左右に移動する
    private void LeftRight(int left)
    {
        if (left*transform.position.x < left*titen.x && yoko == 0)    
        {
            transform.Translate(new Vector2(left * MoveLeftSpeed * Time.deltaTime, 0));
            if (left * transform.position.x >= left * titen.x) yoko = 1;  //横移動から縦移動に変える
        }
    }

    //上下に移動する
    private void Updown(int up)
    {
        if (up*transform.position.y < up*titen.y && yoko == 1 && matizikan <= 0)  
        {
            transform.Translate(new Vector2(0, up * MoveLeftSpeed * Time.deltaTime));
            if (up * transform.position.y >= up * titen.y) Way();
        }
    }

    //待ち時間の処理
    private void wait()
    {
        if (matizikan > 0)
        {
            matizikan -= Time.deltaTime;
        }
    }

}
