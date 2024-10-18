using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed; //idousuru sokudo
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //tama wo idousaseru kansuu
    public void Move()
    {
        transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
    }

    //pireiya- ni atattara kieru kannsuu
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
