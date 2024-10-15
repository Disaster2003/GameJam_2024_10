using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove3 : MonoBehaviour
{
    public Vector2 titen;
    public float MoveSpeed;

    private int yoko;
    // Start is called before the first frame update
    void Start()
    {
        yoko = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < titen.x&&yoko==0)
        {
            transform.Translate(new Vector2(MoveSpeed * Time.deltaTime, 0));
            if(transform.position.x >= titen.x)yoko = 1;
        }
        else if (transform.position.x > titen.x && yoko == 0)
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));
            if (transform.position.x <= titen.x) yoko = 1;
        }

    }
}
