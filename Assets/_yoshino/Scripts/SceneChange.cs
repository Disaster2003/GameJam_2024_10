using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField, Header("�J�ڐ�̃V�[�����")]
    private GameManager.STATE_SCENE state_scene;

    // Start is called before the first frame update
    void Start()
    {
        // �J�ڐ�̃V�[����Ԃ̐ݒ�
        GetComponent<Button>().onClick.AddListener(() => GameManager.GetInstance().SetNextScene(state_scene));
    }
}
