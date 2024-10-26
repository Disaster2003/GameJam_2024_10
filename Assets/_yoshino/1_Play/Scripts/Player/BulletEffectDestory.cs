using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffectDestory : MonoBehaviour
{
    [SerializeField, Header("エフェクトの生存時間")]
    private float effectTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, effectTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
