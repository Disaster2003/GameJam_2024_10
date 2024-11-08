using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindowSwitch : MonoBehaviour
{
    [SerializeField, Header("MenuWindow")]
    private GameObject window;

    // Start is called before the first frame update
    void Start()
    {
        window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            window.SetActive(!window.activeSelf);
        }
    }
}
