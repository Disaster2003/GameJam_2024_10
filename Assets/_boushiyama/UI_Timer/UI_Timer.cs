using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Timer : MonoBehaviour
{
    private static UI_Timer instance;
    private static float survivalTime = 0f; // ��������
    public TMP_Text survivalTimeText;   //�������ԃe�L�X�gUI


    //���Ԃ̃f�[�^��ۑ�����
    private void Awake()
    {
        // �V���O���g���p�^�[��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����ύX����Ă��j�����Ȃ�
        }
        else
        {
            Destroy(gameObject); // �d�������C���X�^���X��j��
        }
    }

    //�V�[���؂�ւ����Text���Ď擾
  
    private void Start()
    {
        if(survivalTimeText == null)
        {
            survivalTimeText = FindObjectOfType<TMP_Text>();
        }
        UpdateSurvivalTimeUI();
    }


    // �������Ԃ����Z
    private void Update()
    {
        if (instance == this) // ���̃C���X�^���X�̂݉��Z
        {
            survivalTime += Time.deltaTime; // �������Ԃ����Z
            UpdateSurvivalTimeUI(); // UI���X�V
        }
    }



    //�������Ԃ̌v�Z������

    private void UpdateSurvivalTimeUI()
    {
        if (survivalTimeText != null)
        {
            int minutes = Mathf.FloorToInt(survivalTime / 60);      //��
            int seconds = Mathf.FloorToInt(survivalTime % 60);      //�b
            survivalTimeText.text = $"{minutes}m{seconds}s";
        }
    }

    //�^�C�}�[�̃��Z�b�g�֐�

    public void ResetTimer()
    {
        survivalTime = 0f; // �������Ԃ����Z�b�g
        UpdateSurvivalTimeUI(); // UI���X�V
    }
}
