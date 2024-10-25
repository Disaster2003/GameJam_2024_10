using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountFont : MonoBehaviour
{
    [SerializeField, Header("ÉtÉHÉìÉgëfçﬁ")]
    private Sprite[] numberSprites = new Sprite[10];

    private Image image;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = numberSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(int number)
    {
        image.sprite = numberSprites[number];
    }


}
