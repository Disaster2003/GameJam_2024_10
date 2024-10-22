using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public enum STATE_SCENE
    {
        TITLE, // �^�C�g�����
        PLAY,  // �v���C���
        CLEAR, // �N���A���
        OVER,  // �Q�[���I�[�o�[���
        NONE,  // ���ݒ�
    }
    private STATE_SCENE state_scene;

    [SerializeField, Header("�N���A�^�C��")]
    private int timeClear;

    [SerializeField, Header("�t�F�[�h�C��/�A�E�g�p�摜")]
    private Image imgFade;
    [SerializeField, Header("�t�F�[�h�C��/�A�E�g�p�{��")]
    private float fadeTime;
    private bool isFadeOut; // true = �t�F�[�h�A�E�g, false = �t�F�[�h�C��

    private bool isPausing; // true = �|�[�Y��, false = �|�[�Y����

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            // �C���X�^���X�̐���
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // �V�[���̏�����
        state_scene = STATE_SCENE.TITLE;

        imgFade.color = Color.black; // �t�F�[�h�A�E�g���
        isFadeOut = false;           // �t�F�[�h�C����
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                break;
            case STATE_SCENE.PLAY:
                SetPause();
                GameSet();
                break;
            case STATE_SCENE.CLEAR:
                break;
            case STATE_SCENE.OVER:
                break;
        }
    }

    private void FixedUpdate()
    {
        FadeInOrOut(Time.fixedDeltaTime);
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
        if(SceneManager.GetActiveScene().buildIndex != (int)state_scene) return;

        if (Timer.GetInstance().GetSurvivalTimer() >= timeClear)
        {
            // �Q�[���N���A��ʂ�
            SetNextScene(STATE_SCENE.CLEAR);
        }
        if (PlayerComponent.GetInstance().GetHp() <= 0)
        {
            // �Q�[���I�[�o�[��ʂ�
            SetNextScene(STATE_SCENE.OVER);
        }
    }

    /// <summary>
    /// ���̃V�[���ɐݒ肷��
    /// </summary>
    /// <param name="_state_scene">�ݒ肷��V�[��</param>
    public void SetNextScene(STATE_SCENE _state_scene = STATE_SCENE.NONE)
    {
        state_scene = _state_scene;
        imgFade.enabled = true;
        isFadeOut = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// �N���A�^�C�����擾����
    /// </summary>
    public float GetClearTime() {  return timeClear; }


    /// <summary>
    /// �t�F�[�h�C��/�A�E�g
    /// </summary>
    /// <param name="_fixedDeltaTime">�X�V����</param>
    private void FadeInOrOut(float _fixedDeltaTime)
    {
        if (isFadeOut)
        {
            if (imgFade.color == Color.black)
            {
                // ���̃V�[����
                isFadeOut = false;
                SceneManager.LoadSceneAsync((int)state_scene);
            }
            // �t�F�[�h�A�E�g
            imgFade.color = Color.Lerp(imgFade.color, Color.black, fadeTime * _fixedDeltaTime);
        }
        else if(imgFade.color != Color.clear)
        {
            if (imgFade.color.a < 0.05f)
            {
                // ����̍폜
                imgFade.enabled = false;
                Time.timeScale = 1;
                return;
            }
            // �t�F�[�h�C��
            imgFade.color = Color.Lerp(imgFade.color, Color.clear, fadeTime * _fixedDeltaTime);
        }
    }

    /// <summary>
    /// �|�[�Y�̏�Ԃ��擾����
    /// </summary>
    public bool GetIsPausing() {  return isPausing; }

    /// <summary>
    /// �|�[�Y����
    /// </summary>
    private void SetPause()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // �|�[�Y��ʂ̐؂�ւ�
            isPausing ^= true;
        }
        if (isPausing)
        {
            // deltaTime��OFF
            Time.timeScale = 0;
            return;
        }
        else if (FindFirstObjectByType<BombAction>() == null)
        {
            // deltaTime��ON
            Time.timeScale = 1;
        }
    }
}
