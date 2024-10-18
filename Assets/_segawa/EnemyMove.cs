using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public float MoveSpeed; //敵の移動速度
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));//敵を移動させる

    }
}
