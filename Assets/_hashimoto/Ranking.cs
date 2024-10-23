using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Ranking : MonoBehaviour
{
    public float[] Rank = new float[9]; //�n�C�X�R�A�����p�̔z��

    public Text[] Texts = new Text[9];

    Text[] ScoreText = new Text[9];

    int idx;

    public float score;


    public void Start()
    {
        JudgeRank();

        Texts[0].text = "����̃X�R�A"+score.ToString();

        for(idx =1; idx < Rank.Length; idx++)
        {
            Texts[idx].text = idx + Rank[idx].ToString();
        }

    }

    //�f�[�^�Z�[�u���� 
    void SaveData()
    {
        for (idx = 1; idx <= 8; idx++)
        {
            string keyString = "Rank" + idx;
            PlayerPrefs.SetFloat(keyString, Rank[idx]);
        }
    }

    //�n�C�X�R�A����o�^���� 
    void JudgeRank()
    {
        int newRank = 0; //�܂�0�ʂƉ��肷��B 
        for (idx = 8; idx > 0; idx--)
        {  //5...1 
            if (Rank[idx] < score)
            { //���݂̃����L���O�ƏƉ��B 
                newRank = idx; //�V���������N�����߂�B 
            }
        }
        if (newRank != 0)
        { //0�ʂ̂܂܂łȂ������烉���N�C���m�� 
            for (idx = 8; idx > newRank; idx--)
            {
                Rank[idx] = Rank[idx - 1];  //�J�艺������ 
            }
            Rank[newRank] = score; //�V�����N�ɓo�^ 
            SaveData(); //PlayerPrefs�ɏ������� 
        }
    }
}
