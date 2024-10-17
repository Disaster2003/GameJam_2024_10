using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    int EnemyHP = 5;
    GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TakeDamege(int damege)
    {
        EnemyHP -= damege;
        if (EnemyHP < 0)
        {
            EnemyHP = 0;
            Die();
        }
    }
    void Die()
    {
        DropItem();
        Destroy(gameObject);
    }

    void DropItem()
    {
        Vector3 dropposition = transform.position + new Vector3(0,1,0);
        Instantiate(Item, dropposition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
