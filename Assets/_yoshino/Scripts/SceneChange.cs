using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField, Header("遷移先のシーン状態")]
    private GameManager.STATE_SCENE state_scene;

    // Update is called once per frame
    void Update()
    {
        // 遷移先のシーン状態の設定
        GetComponent<Button>().onClick.AddListener(() => GameManager.GetInstance().SetNextScene(state_scene));
    }
}
