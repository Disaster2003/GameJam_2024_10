using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    int EnemyHP = 5;                                //敵のHP
    GameObject Item;                                //ドロップアイテム
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void TakeDamege(int damege)     //敵がダメージを受けるときの処理
    {
        EnemyHP -= 1;          //damegeを受けたらHP減少
        if (EnemyHP < 0)            //EnemyHPが0以下になったらDieを送る
        {
            EnemyHP = 0;
            Die();
        }
    }


    void Die()                      //敵が死亡した時の処理
    {
        DropItem();                 //Dieが送られてきたらアイテムドロップとEnemyの削除
        Destroy(gameObject);
    }

    void DropItem()
    {
        Vector3 dropposition = transform.position + new Vector3(0,1);         //アイテムの位置を決定Enemyの位置？
        Instantiate(Item, dropposition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
