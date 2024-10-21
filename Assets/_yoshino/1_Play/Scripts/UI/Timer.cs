using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance;

    private float timerSurvival;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // �C���X�^���X�̐���
            instance = this;
        }

        timerSurvival = 0; // �^�C�}�[�̏�����
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[�̍X�V
        timerSurvival += Time.deltaTime;
        int minute = Mathf.FloorToInt(timerSurvival / 60); // �����v�Z
        int second = Mathf.FloorToInt(timerSurvival % 60); // �b���v�Z

        // ���ƕb��"�Z�Zm�Z�Zs"�`���ŕ\��
        GetComponent<Text>().text = $"{minute}m{second}s";
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static Timer GetInstance() { return instance; }

    /// <summary>
    /// �^�C�}�[���擾����
    /// </summary>
    public float GetSurvivalTimer() { return timerSurvival; }
}
