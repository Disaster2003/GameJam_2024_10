using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject Shot;             //tama no purehabu
    public float wait;                  //taikizikan


    private float spawnwait;          //taikizikan no shori

    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;

    }

    // Update is called once per frame
    void Update()
    {
            ShotSpawn();
    }

    //tama wo supo-nn saseru kannsuu
    public void ShotSpawn()
    {
        spawnwait += Time.deltaTime;
        //taikizikan wo koetara teki wo supo-nn saseru
        if (spawnwait >= wait)
        {
            Instantiate(Shot, transform.position, transform.rotation);
            spawnwait = 0;

        }
    }
}
