using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Timer : MonoBehaviour
{
    private static UI_Timer instance;
    private static float survivalTime = 0f; // 生存時間
    public TMP_Text survivalTimeText;   //生存時間テキストUI


    //時間のデータを保存する
    private void Awake()
    {
        // シングルトンパターン
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンが変更されても破棄しない
        }
        else
        {
            Destroy(gameObject); // 重複したインスタンスを破棄
        }
    }

    //シーン切り替え後にTextを再取得
  
    private void Start()
    {
        if(survivalTimeText == null)
        {
            survivalTimeText = FindObjectOfType<TMP_Text>();
        }
        UpdateSurvivalTimeUI();
    }


    // 生存時間を加算
    private void Update()
    {
        if (instance == this) // このインスタンスのみ加算
        {
            survivalTime += Time.deltaTime; // 生存時間を加算
            UpdateSurvivalTimeUI(); // UIを更新
        }
    }



    //生存時間の計算をする

    private void UpdateSurvivalTimeUI()
    {
        if (survivalTimeText != null)
        {
            int minutes = Mathf.FloorToInt(survivalTime / 60);      //分
            int seconds = Mathf.FloorToInt(survivalTime % 60);      //秒
            survivalTimeText.text = $"{minutes}m{seconds}s";
        }
    }

    //タイマーのリセット関数

    public void ResetTimer()
    {
        survivalTime = 0f; // 生存時間をリセット
        UpdateSurvivalTimeUI(); // UIも更新
    }
}
