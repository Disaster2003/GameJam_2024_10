using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField, Header("ゲーム開始時の位置")]
    private Vector3 startposition;

    [SerializeField, Header("初期化した際の位置")]
    private Vector3 positionInitialize;

    [SerializeField, Header("スクロール終了位置のx座標")]
    private float position_xEnd;
    [SerializeField, Header("移動速度")]
    private float speedMove;


    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        transform.position = startposition;
    }

    // Update is called once per frame
    void Update()
    {
        // 前景のスクロール
        transform.Translate(speedMove * Time.deltaTime, 0, 0);

        if (transform.position.x <= position_xEnd)
        {
            // 初期位置に戻す
            transform.position = positionInitialize;
        }
    }
}
