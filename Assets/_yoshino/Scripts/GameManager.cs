using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �N���X�̃C���X�^���X

    private enum STATE_SCENE
    {
        TITLE, // �^�C�g�����
        PLAY,  // �v���C���
        CLEAR, // �N���A���
        OVER,  // �Q�[���I�[�o�[���
        NONE,  // ���I��
    }
    private STATE_SCENE state_scene;

    [SerializeField] int timeClear; // �N���A�^�C��

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
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                break;
            case STATE_SCENE.PLAY:
                if(Timer.GetInstance().GetTimer() >= timeClear)
                {
                    // �Q�[���N���A��ʂ�
                    SetNextScene(STATE_SCENE.CLEAR);
                }
                //if()
                //{
                //    // �Q�[���I�[�o�[��ʂ�
                //    SetNextScene(STATE_SCENE.OVER);
                //}
                break;
            case STATE_SCENE.CLEAR:
                break;
            case STATE_SCENE.OVER:
                break;
        }
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static GameManager GetInstance() { return instance; }

    /// <summary>
    /// ���̃V�[���ɐݒ肷��
    /// </summary>
    /// <param name="_state_scene"></param>
    private void SetNextScene(STATE_SCENE _state_scene = STATE_SCENE.NONE)
    {
        // null�`�F�b�N
        if(_state_scene == STATE_SCENE.NONE)
        {
            Debug.LogError("���̃V�[�������ݒ�ł�");
            return;
        }

        state_scene = _state_scene;
        SceneManager.LoadSceneAsync((int)state_scene);
    }
}
