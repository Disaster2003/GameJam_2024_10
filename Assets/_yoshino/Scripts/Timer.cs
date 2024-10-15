using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance; // �N���X�̃C���X�^���X

    private float timer; // �^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // Singleton
            instance = this;
        }

        timer = 1; // �^�C�}�[�̏�����
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("imgFade").GetComponent<Image>().fillAmount > 0) return;

        // �^�C�}�[�̍X�V
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("F1") + "s";
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static Timer GetInstance() { return instance; }

    /// <summary>
    /// �^�C�}�[���擾����
    /// </summary>
    public float GetTimer() { return timer; }
}
