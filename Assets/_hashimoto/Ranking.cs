using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Ranking : MonoBehaviour
{
    public float[] Rank = new float[9]; //ハイスコア処理用の配列

    public Text[] Texts = new Text[9];

    Text[] ScoreText = new Text[9];

    int idx;

    public float score;


    public void Start()
    {
        JudgeRank();

        Texts[0].text = "今回のスコア"+score.ToString();

        for(idx =1; idx < Rank.Length; idx++)
        {
            Texts[idx].text = idx + Rank[idx].ToString();
        }

    }

    //データセーブ処理 
    void SaveData()
    {
        for (idx = 1; idx <= 8; idx++)
        {
            string keyString = "Rank" + idx;
            PlayerPrefs.SetFloat(keyString, Rank[idx]);
        }
    }

    //ハイスコア判定登録処理 
    void JudgeRank()
    {
        int newRank = 0; //まず0位と仮定する。 
        for (idx = 8; idx > 0; idx--)
        {  //5...1 
            if (Rank[idx] < score)
            { //現在のランキングと照会する。 
                newRank = idx; //新しいランクを求める。 
            }
        }
        if (newRank != 0)
        { //0位のままでなかったらランクイン確定 
            for (idx = 8; idx > newRank; idx--)
            {
                Rank[idx] = Rank[idx - 1];  //繰り下げ処理 
            }
            Rank[newRank] = score; //新ランクに登録 
            SaveData(); //PlayerPrefsに書きこみ 
        }
    }
}
