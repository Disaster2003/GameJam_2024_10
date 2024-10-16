using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove3 : Enemymove
{
    public float MoveUpSpeed;       //上下の速度
    public float Haba;              //上下幅
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
    //上下移動
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
