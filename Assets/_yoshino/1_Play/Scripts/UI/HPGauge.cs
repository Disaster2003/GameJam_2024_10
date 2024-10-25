using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    [SerializeField, Header("‘Ì—Í‰æ‘œ”Ô†")]
    private int indexHP;

    [SerializeField, Header("‘Ì—Í‰æ‘œ”Ô†")]
    private Sprite activeSprite;

    [SerializeField, Header("‘Ì—Í‰æ‘œ”Ô†")]
    private Sprite nonactiveSprite;

    // Update is called once per frame
    void Update()
    {
        if(indexHP <= PlayerComponent.GetInstance().GetHp())
        {
            // ‰æ‘œ‚Ì•\¦
            GetComponent<Image>().sprite = activeSprite;
        }
        else
        {
            // ‰æ‘œ‚Ì”ñ•\¦
            GetComponent<Image>().sprite = nonactiveSprite;
        }
    }
}
