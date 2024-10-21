using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyTest : MonoBehaviour
{


    public int _currentHP;
    public int _damage;
    public GameObject Main;

    void Damage()
    {
        
        _currentHP--;

    }

    // Update is called once per frame
    void Update()
    {

        if (_currentHP < 1)
        {
          

            Destroy(Main);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Shot"))
        {
            Debug.Log("WeaponCollision");
            Damage();

          
        }

    }
}
