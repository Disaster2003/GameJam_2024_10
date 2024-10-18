using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymuve : MonoBehaviour
{
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-MoveSpeed * Time.deltaTime, 0));
    }
}
