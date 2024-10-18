using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove4 : MonoBehaviour
{
    public Vector2 titen;           //tomaru basho
    public float MoveLeftSpeed;     //yoko idou sokudo
    public float MoveUpSpeed;       //jouge sokudo
    public float Wait;              //matizikan

    private int yoko;               //yoko idoui kara tate idou nikaeru shori
    private float matizikan;        // matizikan no shori
    // Start is called before the first frame update
    void Start()
    {
        yoko = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < titen.x && yoko == 0)    //migi gawa no sitei sareta houkou he idou
        {
            transform.Translate(new Vector2(MoveLeftSpeed * Time.deltaTime, 0));
            if (transform.position.x >= titen.x) yoko = 1;  //yoko idou kara tate idou ni kaeru
        }   
        else if (transform.position.x > titen.x && yoko == 0)   //hidari gawa no sitei sareta houkou he idou
        {
            transform.Translate(new Vector2(-MoveLeftSpeed * Time.deltaTime, 0));
            if (transform.position.x <= titen.x) yoko = 1;  //yoko idou kara tate idou nikaeru
        }   
        if (transform.position.y < titen.y && yoko == 1&&matizikan<=0)  //ue ni idou
        {
            transform.Translate(new Vector2(0,MoveLeftSpeed * Time.deltaTime));
            if (transform.position.y >= titen.y) houkou();
            
        }   
        else if (transform.position.y > titen.y && yoko == 1&&matizikan<=0) //sita ni idou
        {
            transform.Translate(new Vector2(0,-MoveLeftSpeed * Time.deltaTime));
            if (transform.position.y <= titen.y) houkou();
            
        }  

        //matizikan no shori
        if (matizikan > 0)
        {
            matizikan -= Time.deltaTime;
        }
    }

    //titen.y wo - ka + nikaeru
    //matizikan wo settei suru
    private void houkou()
    {
        titen.y *= -1;
        matizikan =Wait;
    }
}
