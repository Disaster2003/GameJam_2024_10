using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Bullet))]
#endif

public class Bullet1 : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
