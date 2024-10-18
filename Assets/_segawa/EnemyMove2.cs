using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove2 : MonoBehaviour
{
    public Vector2 titen;   //止まる場所
    public float MoveSpeed;//移動速度

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight(1);   //右側の指定された方向へ移動
        LeftRight(-1);  //左側の指定された方向へ移動
    }
    //左右移動
    private void LeftRight(int left)
    {
        if (left*transform.position.x < left*titen.x)    
        {
            transform.Translate(new Vector2(left * MoveSpeed * Time.deltaTime, 0));
            if (left * transform.position.x >= left * titen.x) Destroy(this);
        }

    }
}
