using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove3 : MonoBehaviour
{
    public float MoveLeftSpeed;     //yoko idousokudo
    public float MoveUpSpeed;       //jouge no sokudo
    public float Haba;              //jouge haba
    // Start is called before the first frame update
    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-MoveLeftSpeed * Time.deltaTime, 0));

        if (transform.position.y < Haba)    //ue ni idou
        {
            transform.Translate(new Vector2(0, MoveLeftSpeed * Time.deltaTime));
            if (transform.position.y >= Haba) Haba *= -1;   //Haba wo - ka + ni kaeru
        }   
        else if (transform.position.y > Haba)   //sita nii idou
        {
            transform.Translate(new Vector2(0, -MoveLeftSpeed * Time.deltaTime));
            if (transform.position.y <= Haba) Haba *= -1;   //Haba wo - ka + ni kaeru
        }   

    }   
}   
