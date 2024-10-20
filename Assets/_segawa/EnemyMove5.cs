using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove5 : Enemymove
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DownMove();
    }

    //‰º‚ÉˆÚ“®‚·‚é
    private void DownMove()
    {
        transform.Translate(new Vector2(0,-(MoveSpeed/2) * Time.deltaTime));//“G‚ðˆÚ“®‚³‚¹‚é
    }
}
