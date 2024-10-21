using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance;

    private float timerSurvival;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // インスタンスの生成
            instance = this;
        }

        timerSurvival = 0; // タイマーの初期化
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーの更新
        timerSurvival += Time.deltaTime;
        int minute = Mathf.FloorToInt(timerSurvival / 60); // 分を計算
        int second = Mathf.FloorToInt(timerSurvival % 60); // 秒を計算

        // 分と秒を"〇〇m〇〇s"形式で表示
        GetComponent<Text>().text = $"{minute}m{second}s";
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static Timer GetInstance() { return instance; }

    /// <summary>
    /// タイマーを取得する
    /// </summary>
    public float GetSurvivalTimer() { return timerSurvival; }
}
