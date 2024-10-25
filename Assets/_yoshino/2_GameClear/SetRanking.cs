using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    [SerializeField, Header("����̃^�C��")]
    private Text txtThisTime;
    [SerializeField, Header("�����L���O�p�^�C���z��")]
    private Text[] txtRank;
    private float thisTime;
    float[] rank = new float[9]; // �n�C�X�R�A�����p�̔z��

    // Start is called before the first frame update
    void Start()
    {
        thisTime = PlayerPrefs.GetFloat("Time");
        int minute = Mathf.FloorToInt(thisTime / 60); // �����v�Z
        int second = Mathf.FloorToInt(thisTime % 60); // �b���v�Z

        // ���ƕb��"�Z�Zm�Z�Zs"�`���ŕ\��
        txtThisTime.text = $"{minute}m{second}s";

        if (PlayerPrefs.HasKey("Rank1"))
        {
            LoadData(); // �f�[�^���[�h����
        }
        else
        {
            InitData(); // �f�[�^����������
        }

        JudgeRank();
    }

    /// <summary>
    /// �f�[�^����������
    /// </summary>
    void InitData()
    {
        for (int idx = 1; idx <= 8; idx++)
        {
            rank[idx] = 0;
        }
        SaveData(); // �f�[�^�Z�[�u����
    }

    /// <summary>
    /// �f�[�^���[�h����
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
    /// �f�[�^�Z�[�u����
    /// </summary>
    void SaveData()
    {
        for (int idx = 1; idx <= 8; idx++)
        {
            int minute = Mathf.FloorToInt(rank[idx] / 60); // �����v�Z
            int second = Mathf.FloorToInt(rank[idx] % 60); // �b���v�Z

            // ���ƕb��"�Z�Zm�Z�Zs"�`���ŕ\��
            txtRank[idx - 1].text = $"{minute}m{second}s";

            string keyString = "Rank" + idx;
            PlayerPrefs.SetFloat(keyString, rank[idx]);
        }
    }

    /// <summary>
    /// �n�C�X�R�A����o�^����
    /// </summary>
    void JudgeRank()
    {
        int newRank = 0; // �܂�0�ʂƉ��肷��B
        for (int idx = 8; idx > 0; idx--)
        { 
            // 8...1
            if (rank[idx] < thisTime)
            { 
                // ���݂̃����L���O�ƏƉ��B
                newRank = idx; // �V���������N�����߂�B
            }
        }
        if (newRank != 0)
        { 
            // 0�ʂ̂܂܂łȂ������烉���N�C���m��
            for (int idx = 8; idx > newRank; idx--)
            {
                rank[idx] = rank[idx - 1]; // �J�艺������
            }
            rank[newRank] = thisTime; // �V�����N�ɓo�^
            SaveData();            // PlayerPrefs�ɏ�������
        }
    }
}
