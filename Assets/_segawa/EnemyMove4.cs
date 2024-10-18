using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove4 : MonoBehaviour
{
    public Vector2 titen;
    public float MoveLeftSpeed;
    public float MoveUpSpeed;
    public float Wait;

    private int yoko;
    private float matizikan;
    // Start is called before the first frame update
    void Start()
    {
        yoko = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < titen.x && yoko == 0)
        {
            transform.Translate(new Vector2(MoveLeftSpeed * Time.deltaTime, 0));
            if (transform.position.x >= titen.x) yoko = 1;
        }
        else if (transform.position.x > titen.x && yoko == 0)
        {
            transform.Translate(new Vector2(-MoveLeftSpeed * Time.deltaTime, 0));
            if (transform.position.x <= titen.x) yoko = 1;
        }

        if (transform.position.y < titen.y && yoko == 1&&matizikan<=0)
        {
            transform.Translate(new Vector2(0,MoveLeftSpeed * Time.deltaTime));
            if (transform.position.y >= titen.y) houkou();
            ;
        }
        else if (transform.position.y > titen.y && yoko == 1&&matizikan<=0)
        {
            transform.Translate(new Vector2(0,-MoveLeftSpeed * Time.deltaTime));
            if (transform.position.y <= titen.y) houkou();
            
        }

        if (matizikan > 0)
        {
            matizikan -= Time.deltaTime;
        }
    }

    private void houkou()
    {
        titen.y *= -1;
        matizikan =Wait;
    }
}
