using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSelector: MonoBehaviour
{
    [SerializeField] private Sprite[] sprites; // 複数のスプライトを格納する配列
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRendererコンポーネントが見つかりません。");
            return;
        }

        // Order in Layerを101に設定
        spriteRenderer.sortingOrder = 101;

        // ランダムなスプライトを選択
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
            Debug.LogWarning("スプライトが設定されていません。");
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
            Debug.LogError("Rigidbody2Dコンポーネントが見つかりません。");
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
