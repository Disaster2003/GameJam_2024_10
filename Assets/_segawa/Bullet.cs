using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed; //移動する速度
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //弾を移動する
    public void Move()
    {
        transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
    }

    //プレイヤーに当たったら消える
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
