using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove3 : Enemymove
{
    public float MoveUpSpeed;       //è„â∫ÇÃë¨ìx
    public float Haba;              //è„â∫ïù
    // Start is called before the first frame update
    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {
        Move();
        UpDown(1);
        UpDown(-1);
    }   
    //è„â∫à⁄ìÆ
    private void UpDown(int up)
    {
        if (up * transform.position.y < up * Haba)
        {
            transform.Translate(new Vector2(0, up * MoveUpSpeed * Time.deltaTime));
            if (up * transform.position.y >= up * Haba)
            {
                Haba *= -1;
            }
        }
    }
}   
