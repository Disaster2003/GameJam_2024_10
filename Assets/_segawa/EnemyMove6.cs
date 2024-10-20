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

    //ã‚ÉˆÚ“®‚·‚é
    private void UpMove()
    {
        transform.Translate(new Vector2(0, (MoveSpeed / 2) * Time.deltaTime));//“G‚ğˆÚ“®‚³‚¹‚é
    }

}
