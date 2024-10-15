using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �N���X�̃C���X�^���X

    private enum STATE_SCENE
    {
        TITLE, // �^�C�g�����
        PLAY,  // �v���C���
        CLEAR, // �N���A���
        OVER,  // �Q�[���I�[�o�[���
        NONE,  // ���ݒ�
    }
    private STATE_SCENE state_scene;

    [SerializeField] int timeClear; // �N���A�^�C��

    [SerializeField] Image imgFade; // �t�F�[�h�C��/�A�E�g�p�摜
    private bool isFadeOut; // �t�F�[�h�A�E�g���邩�ǂ���

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        state_scene = STATE_SCENE.TITLE; // �V�[���̏�����

        imgFade.fillAmount = 1; // �t�F�[�h�A�E�g���
        isFadeOut = false;      // �t�F�[�h�C����
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                break;
            case STATE_SCENE.PLAY:
                GameSet();
                break;
            case STATE_SCENE.CLEAR:
                break;
            case STATE_SCENE.OVER:
                break;
        }

        FadeInOrOut();
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static GameManager GetInstance() { return instance; }

    /// <summary>
    /// �Q�[���I�������ł̕��򏈗�
    /// </summary>
    private void GameSet()
    {
        if (Timer.GetInstance().GetTimer() >= timeClear)
        {
            // �Q�[���N���A��ʂ�
            SetNextScene(STATE_SCENE.CLEAR);
        }
        //if()
        //{
        //    // �Q�[���I�[�o�[��ʂ�
        //    SetNextScene(STATE_SCENE.OVER);
        //}
    }

    /// <summary>
    /// ���̃V�[���ɐݒ肷��
    /// </summary>
    /// <param name="_state_scene"></param>
    private void SetNextScene(STATE_SCENE _state_scene = STATE_SCENE.NONE)
    {
        state_scene = _state_scene;
        isFadeOut = true;
    }

    /// <summary>
    /// �t�F�[�h�C��/�A�E�g
    /// </summary>
    private void FadeInOrOut()
    {
        if (isFadeOut)
        {
            if (imgFade.fillAmount >= 1)
            {
                // ���̃V�[����
                isFadeOut = false;
                SceneManager.LoadSceneAsync((int)state_scene);
            }
            // �t�F�[�h�A�E�g
            imgFade.fillAmount += Time.deltaTime;
        }
        else if(imgFade.fillAmount > 0)
        {
            // �t�F�[�h�C��
            imgFade.fillAmount += -Time.deltaTime;
        }
    }
}
