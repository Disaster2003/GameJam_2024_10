using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharge : MonoBehaviour
{
    private GameObject UICounter; // アイテムカウンター
    private float speedMove;      // 移動速度
    [SerializeField] float accel; // 加速度
    private float timer;          // タイマー

    // Start is called before the first frame update
    void Start()
    {
        UICounter = GameObject.Find("txtTimer");
        speedMove = 0; // 移動速度の初期化
        timer = 1;     // タイマーの初期化
    }

    // Update is called once per frame
    void Update()
    {
        // カメラ内でのワールド座標に変換する
        Vector3 UIposition = Camera.main.ScreenToWorldPoint(UICounter.GetComponent<RectTransform>().transform.position);
        if (Vector3.Distance(transform.position, UIposition) < 1)
        {
            // 自身を破棄する
            Destroy(gameObject);
        }
        else if(timer <= 0)
        {
            // アイテムのカウントをしているUIに近づく
            transform.position = Vector3.MoveTowards(transform.position, UIposition, speedMove);
            speedMove += accel * Time.deltaTime;
        }
        else
        {
            // 時間経過
            timer += -Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        // nullチェック
        if (UICounter == null) return;

        // アイテム数を+1する
        UICounter.GetComponent<ItemCounter>().IncreaseBombChargeCounter();
    }
}
