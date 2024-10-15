using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove3 : MonoBehaviour
{
    public float MoveLeftSpeed;
    public float MoveUpSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-MoveLeftSpeed * Time.deltaTime, MoveUpSpeed*Time.deltaTime));
    }
}
