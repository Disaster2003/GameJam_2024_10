using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove7 : Enemymove
{
    public float wait;          //待ち時間を指定する変数

    private float matizikan;    //待ち時間の処理
    private int way;            //方向の処理 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        matizikan += Time.deltaTime;
        //方向の指定
        if (wait <= matizikan && way % 2 == 0)ReverseWay();
        else if (wait/2 <= matizikan&&way%2 == 1)ReverseWay();

        //移動
        if(way%2== 0)Move();
        else ReverseMove();
    }

    //反対方向に移動する
    private void ReverseMove()
    {
        transform.Translate(new Vector2(MoveSpeed * Time.deltaTime,0));//敵を移動させる

    }

    //方向を反対にする
    private void ReverseWay()
    {
        way++;
        matizikan = 0;
    }
}
