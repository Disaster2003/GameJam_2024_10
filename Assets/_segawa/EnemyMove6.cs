using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove6 : Enemymove
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpMove();
    }

    //上に移動する
    private void UpMove()
    {
        transform.Translate(new Vector2(0, (MoveSpeed / 2) * Time.deltaTime));//敵を移動させる
    }

}
