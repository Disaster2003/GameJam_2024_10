using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject Shot;
    public float wait;

    private float spawnwait;          //‘Ò‹@ŽžŠÔ‚Ìˆ—   

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

    public void ShotSpawn()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)
        {
            Instantiate(Shot, transform.position, transform.rotation);
            spawnwait = 0;

        }
    }
}
