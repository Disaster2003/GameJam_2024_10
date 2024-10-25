using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    [SerializeField, Header("‘Ì—Í‰æ‘œ”Ô†")]
    private int indexHP;

    // Update is called once per frame
    void Update()
    {
        if(indexHP <= PlayerComponent.GetInstance().GetHp())
        {
            // ‰æ‘œ‚Ì•\¦
            GetComponent<Image>().enabled = true;
        }
        else
        {
            // ‰æ‘œ‚Ì”ñ•\¦
            GetComponent<Image>().enabled = false;
        }
    }
}
