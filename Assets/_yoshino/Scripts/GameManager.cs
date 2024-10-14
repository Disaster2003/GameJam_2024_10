using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum STATE_SCENE
    {
        TITLE,
        PLAY,
        GAMECLEAR,
        GAMEOVER,
    }
    private STATE_SCENE state_scene;

    [SerializeField] int timeFinish;

    // Start is called before the first frame update
    void Start()
    {
        state_scene = STATE_SCENE.TITLE;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.GetInstance().GetTimer() >= timeFinish)
        {
            // �Q�[���N���A��ʂ�
            SetNextScene(STATE_SCENE.GAMECLEAR);
        }
        //if()
        //{
        //    // �Q�[���I�[�o�[��ʂ�
        //    SetNextScene(STATE_SCENE.GAMEOVER);
        //}
    }

    /// <summary>
    /// ���̃V�[���ɐݒ肷��
    /// </summary>
    /// <param name="_state_scene"></param>
    private void SetNextScene(STATE_SCENE _state_scene)
    {
        state_scene = _state_scene;
        SceneManager.LoadSceneAsync((int)state_scene);
    }
}
