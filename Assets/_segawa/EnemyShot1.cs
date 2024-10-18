using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyShot))]
#endif

public class EnemyShot1 : EnemyShot
{
    private float spawnwait;
    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;

    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)
        {
            ShotSpawn();
        }

    }


}
