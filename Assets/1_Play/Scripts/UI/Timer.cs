using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance;

    private float timerSurvival;

    [SerializeField, Header("時間表示用の文字")]
    private CountFont[] countFonts = new CountFont[4];

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
        if(timerSurvival >= GameManager.GetInstance().GetClearTime()) return;

        // タイマーの更新
        timerSurvival += Time.deltaTime;
        int minute = Mathf.FloorToInt(timerSurvival / 60); // 分を計算
        int second = Mathf.FloorToInt(timerSurvival % 60); // 秒を計算

        //分の表示
        countFonts[1].SetSprite(minute);

        //秒の表示
        countFonts[2].SetSprite(second/10);
        countFonts[3].SetSprite(second%10);


    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static Timer GetInstance() { return instance; }

    /// <summary>
    /// タイマーを取得する
    /// </summary>
    public float GetSurvivalTimer() { return timerSurvival; }

    private void OnDestroy()
    {
        // ローカルにタイムを保存
        PlayerPrefs.SetFloat("Time", timerSurvival);
    }
}
