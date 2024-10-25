using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSelector: MonoBehaviour
{
    [SerializeField] private Sprite[] sprites; // �����̃X�v���C�g���i�[����z��
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer�R���|�[�l���g��������܂���B");
            return;
        }

        // Order in Layer��101�ɐݒ�
        spriteRenderer.sortingOrder = 101;

        // �����_���ȃX�v���C�g��I��
        SelectRandomSprite();
    }

    void SelectRandomSprite()
    {
        if (sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];
        }
        else
        {
            Debug.LogWarning("�X�v���C�g���ݒ肳��Ă��܂���B");
        }
    }

    public void Launch(Vector2 force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody2D�R���|�[�l���g��������܂���B");
        }
    }

    public void LaunchUpward(float force)
    {
        Launch(new Vector2(0, force));
    }

    public void LaunchSideways(float force)
    {
        Launch(new Vector2(force, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
