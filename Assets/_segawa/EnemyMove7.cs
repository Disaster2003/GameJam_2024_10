using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove7 : Enemymove
{
    public float wait;          //‘Ò‚¿ŠÔ‚ğw’è‚·‚é•Ï”

    private float matizikan;    //‘Ò‚¿ŠÔ‚Ìˆ—
    private int way;            //•ûŒü‚Ìˆ— 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        matizikan += Time.deltaTime;
        //•ûŒü‚Ìw’è
        if (wait <= matizikan && way % 2 == 0)ReverseWay();
        else if (wait/2 <= matizikan&&way%2 == 1)ReverseWay();

        //ˆÚ“®
        if(way%2== 0)Move();
        else ReverseMove();
    }

    //”½‘Î•ûŒü‚ÉˆÚ“®‚·‚é
    private void ReverseMove()
    {
        transform.Translate(new Vector2(MoveSpeed * Time.deltaTime,0));//“G‚ğˆÚ“®‚³‚¹‚é

    }

    //•ûŒü‚ğ”½‘Î‚É‚·‚é
    private void ReverseWay()
    {
        way++;
        matizikan = 0;
    }
}
