using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    float DropChance = 0.5f;        //アイテムドロップの確率 
    GameObject Item;                                //ドロップアイテム
    // Start is called before the first frame update
    void Start()
    {
        
    }


   


    public void Die()                      //敵が死亡した時の処理
    {

        DropItem();                 //Dieが送られてきたらアイテムドロップとEnemyの削除
        Destroy(gameObject);
    }

    void DropItem()
    {
        if (Random.value  < DropChance)
        {
            Vector3 dropposition = transform.position;               //アイテムの位置を決定Enemyの位置
            Instantiate(Item, dropposition, Quaternion.identity);
            Debug.Log("drop");
        }
        else
        {
            Debug.Log("not drop");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
