using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�O�i�̃X�N���[��
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);

        //�����ʒu�ɖ߂�
        if(transform.position.x <=-5f)
        {
            transform.position = new Vector3(3.9207f,-2.56f, 0);
        }
    }
}
