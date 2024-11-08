using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance;

    private float timerSurvival;

    [SerializeField, Header("���ԕ\���p�̕���")]
    private CountFont[] countFonts = new CountFont[4];

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
        if(timerSurvival >= GameManager.GetInstance().GetClearTime()) return;

        // �^�C�}�[�̍X�V
        timerSurvival += Time.deltaTime;
        int minute = Mathf.FloorToInt(timerSurvival / 60); // �����v�Z
        int second = Mathf.FloorToInt(timerSurvival % 60); // �b���v�Z

        //���̕\��
        countFonts[1].SetSprite(minute);

        //�b�̕\��
        countFonts[2].SetSprite(second/10);
        countFonts[3].SetSprite(second%10);


    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static Timer GetInstance() { return instance; }

    /// <summary>
    /// �^�C�}�[���擾����
    /// </summary>
    public float GetSurvivalTimer() { return timerSurvival; }

    private void OnDestroy()
    {
        // ���[�J���Ƀ^�C����ۑ�
        PlayerPrefs.SetFloat("Time", timerSurvival);
    }
}
