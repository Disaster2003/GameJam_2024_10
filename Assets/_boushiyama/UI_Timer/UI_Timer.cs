using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;            //�e�L�X�g�v�����g�p���邽��
public class UI_Timer : MonoBehaviour
{
    private float survivalTime = 0f; // ��������
    public TMP_Text survivalTimeText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSurvivalTimeUI();
    }

    // Update is called once per frame
  
    private void Update()
    {
        // �������Ԃ����Z
        survivalTime += Time.deltaTime;

        // �������Ԃ�UI�ɕ\��
        UpdateSurvivalTimeUI();
    }

    private void UpdateSurvivalTimeUI()
    {
        if (survivalTimeText != null)
        {
            int minutes = Mathf.FloorToInt(survivalTime / 60); // �����v�Z
            int seconds = Mathf.FloorToInt(survivalTime % 60); // �b���v�Z

            // ���ƕb��"�Z�Zm�Z�Zs"�`���ŕ\��
            survivalTimeText.text = $"{minutes}m{seconds}s";
        }
    }
}
