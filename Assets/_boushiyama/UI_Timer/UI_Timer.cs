using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;            //テキストプロを使用するため
public class UI_Timer : MonoBehaviour
{
    private float survivalTime = 0f; // 生存時間
    public TMP_Text survivalTimeText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSurvivalTimeUI();     //時間更新の計算関数
    }

    // Update is called once per frame


    //時間をUIで表示
    private void Update()
    {
        // 生存時間を加算
        survivalTime += Time.deltaTime;

        // 生存時間をUIに表示
        UpdateSurvivalTimeUI();
    }
    //時間を更新する計算
    private void UpdateSurvivalTimeUI()
    {
        if (survivalTimeText != null)
        {
            int minutes = Mathf.FloorToInt(survivalTime / 60); // 分を計算
            int seconds = Mathf.FloorToInt(survivalTime % 60); // 秒を計算

            // 分と秒を"〇〇m〇〇s"形式で表示
            survivalTimeText.text = $"{minutes}m{seconds}s";
        }
    }
}
