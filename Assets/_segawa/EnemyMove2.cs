using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove2 : MonoBehaviour
{
    public Vector2 titen;   //tomaru basho
    public float MoveSpeed;//idousokudo

    private int yoko;
    // Start is called before the first frame update
    void Start()
    {
        yoko = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < titen.x&&yoko==0)    //migi gawa no sitei sareta houkou he idou
        {
            transform.Translate(new Vector2(MoveSpeed * Time.deltaTime, 0));
            if(transform.position.x >= titen.x)yoko = 1;
        }
        else if (transform.position.x > titen.x && yoko == 0)   //hidari gawa no sitei sareta houkou he idou
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));
            if (transform.position.x <= titen.x) yoko = 1;
        }

    }
}
