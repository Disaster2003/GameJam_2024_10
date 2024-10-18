using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    
    [SerializeField] private float speed;

    [SerializeField] Vector3 StartPosition;

    [SerializeField] private float ResetPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //前景のスクロール
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);

        //初期位置に戻す
        if(transform.position.x <= ResetPosition)
        {
            transform.position = StartPosition;
        }
    }
}
