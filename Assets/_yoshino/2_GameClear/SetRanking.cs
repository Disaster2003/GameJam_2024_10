using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    [SerializeField, Header("今回のタイム")]
    private Text txtThisTime;
    [SerializeField, Header("ランキング用タイム配列")]
    private Text[] txtRank;
    private float thisTime;
    float[] rank = new float[9]; // ハイスコア処理用の配列

    // Start is called before the first frame update
    void Start()
    {
        thisTime = PlayerPrefs.GetFloat("Time");
        int minute = Mathf.FloorToInt(thisTime / 60); // 分を計算
        int second = Mathf.FloorToInt(thisTime % 60); // 秒を計算

        // 分と秒を"〇〇m〇〇s"形式で表示
        txtThisTime.text = $"{minute}m{second}s";

        if (PlayerPrefs.HasKey("Rank1"))
        {
            LoadData(); // データロード処理
        }
        else
        {
            InitData(); // データ初期化処理
        }

        JudgeRank();
    }

    /// <summary>
    /// データ初期化処理
    /// </summary>
    void InitData()
    {
        for (int idx = 1; idx <= 8; idx++)
        {
            rank[idx] = 0;
        }
        SaveData(); // データセーブ処理
    }

    /// <summary>
    /// データロード処理
    /// </summary>
    void LoadData()
    {
        for (int idx = 1; idx <= 8; idx++)
        {
            string keyString = "Rank" + idx;
            rank[idx] = PlayerPrefs.GetFloat(keyString);
        }
    }

    /// <summary>
    /// データセーブ処理
    /// </summary>
    void SaveData()
    {
        for (int idx = 1; idx <= 8; idx++)
        {
            int minute = Mathf.FloorToInt(rank[idx] / 60); // 分を計算
            int second = Mathf.FloorToInt(rank[idx] % 60); // 秒を計算

            // 分と秒を"〇〇m〇〇s"形式で表示
            txtRank[idx - 1].text = $"{minute}m{second}s";

            string keyString = "Rank" + idx;
            PlayerPrefs.SetFloat(keyString, rank[idx]);
        }
    }

    /// <summary>
    /// ハイスコア判定登録処理
    /// </summary>
    void JudgeRank()
    {
        int newRank = 0; // まず0位と仮定する。
        for (int idx = 8; idx > 0; idx--)
        { 
            // 8...1
            if (rank[idx] < thisTime)
            { 
                // 現在のランキングと照会する。
                newRank = idx; // 新しいランクを求める。
            }
        }
        if (newRank != 0)
        { 
            // 0位のままでなかったらランクイン確定
            for (int idx = 8; idx > newRank; idx--)
            {
                rank[idx] = rank[idx - 1]; // 繰り下げ処理
            }
            rank[newRank] = thisTime; // 新ランクに登録
            SaveData();            // PlayerPrefsに書きこみ
        }
    }
}
