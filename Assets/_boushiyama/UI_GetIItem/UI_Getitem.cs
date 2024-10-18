using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Getitem : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 20; // UI��؂�ւ���X�R�A
    public GameObject newUI; // �؂�ւ���UI RED
    public GameObject oldUI; // ���݂�UI BLUE
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        oldUI.SetActive(true);
        newUI.SetActive(false);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[����������X�R�A���Z
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddScore(1);
        }
    }
    void AddScore(int item)
    {
        score += item;
        Debug.Log("Score: " + score);
        UpdateScoreText();
        // �X�R�A���^�[�Q�b�g�ɒB������UI��؂�ւ�
        if (score >= targetScore)
        {
            SwitchUI();
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "�~" + score;       //�X�R�A�\��
    }
    //�Â�UI�������ĐV����UI��\������
    void SwitchUI()
    {
        oldUI.SetActive(false);
        newUI.SetActive(true);
    }
}
