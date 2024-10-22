using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    public bool ClearFlag = false;


    public enum GameState
    {
        play,
        stop,
    }

    public GameState state = GameState.play;


    // Start is called before the first frame update
    void Start()
    {
        //íÜêgÇ™ë∂ç›ÇµÇƒÇ¢Ç»Ç¢Ç∆Ç´
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            state = GameState.stop;
        }
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    state = GameState.naming;
        //}

        //if (state == GameState.play)
        //{
        //    MyTime -= Time.deltaTime;

        //}
        //else
        if (state == GameState.stop)
        {
            if (ClearFlag == false)
            {
                SceneManager.LoadScene("GameClear");
                ClearFlag = true;
            }

        }
    }
}
