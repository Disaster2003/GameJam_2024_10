using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("�ő�̗�")]
    private int Maxhp;

    private int hp;

    [SerializeField, Header("HP�o�[")]
    private GameObject slider;

    Slider hpSlider;

    [SerializeField, Header("HP�o�[�\������")]
    private float sliderVisbleTimeBace = 0.5f;

    private float sliderVisbleTime = 0.5f;

    private bool isVisibleSlider = false;

    [SerializeField, Header("�A�C�e��")]
    private GameObject item;
    [SerializeField, Header("1/?�ŃA�C�e���h���b�v")]
    private int probability;

    [SerializeField, Header("���������̎���")]
    private float timeDeath;
    private float timerUntilDeath;

    [SerializeField, Header("���������̌�����")]
    private Sprite DeathSprite;

    EnemyRapidFire enemyRapidFire;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; // ��]�s��
        boxCollider = GetComponent<BoxCollider2D>();
        enemyRapidFire = GetComponent<EnemyRapidFire>();

        // �^�C�}�[�̏�����
        timerUntilDeath = 0;
        hp = Maxhp;

        hpSlider = slider.GetComponent<Slider>();

        slider.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (GetDeathFlag())
        {
            if (timerUntilDeath >= timeDeath)
            {
                Debug.Log(1);
                // ���g�̔j��
                Destroy(gameObject);
            }
            // ��������
            timerUntilDeath += Time.fixedDeltaTime;
        }         

        if(isVisibleSlider)
        {
            sliderVisbleTime -= Time.deltaTime;
            if(sliderVisbleTime<0)
            {
                isVisibleSlider = false;
                slider.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // null�`�F�b�N
        if (collision == null) return;

        if (collision.CompareTag("Bullet"))
        {
            BulletComponent bullet = collision.GetComponent<BulletComponent>();

            if (bullet == null) return;

            if (bullet.GetisPlayerBullet())
            {
                // �_���[�W
                hp--;

                if (!isVisibleSlider)
                {
                    slider.SetActive(true);

                    hpSlider.value = (float)hp / (float)Maxhp;

                    isVisibleSlider = true;
                    sliderVisbleTime = sliderVisbleTimeBace;
                }
                else
                {
                    hpSlider.value = (float)hp / (float)Maxhp;
                }
                

                if (hp <= 0)
                {
                    // ���S�J�n
                    Dead();
                }
            }
           
        }
    }

    /// <summary>
    /// ���S����
    /// </summary>
    public void Dead()
    {
        if (hp <= 0)
        {
            ItemDrop();
        }

        if(boxCollider != null)
        {
            boxCollider.enabled = false;
        }
       
        if(enemyRapidFire != null)
        {
            enemyRapidFire.enabled = false;
        }
       

        // ��������
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        // �摜�̐؂�ւ�
        GetComponent<SpriteRenderer>().sprite = DeathSprite;
    }

    /// <summary>
    /// �A�C�e���𐶐�����
    /// </summary>
    private void ItemDrop()
    {
        // �m���̒T��
        probability = Random.Range(0, probability);
        if (probability == 0)
        {
            // �A�C�e���̐���
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    public bool GetDeathFlag()
    {
        //�������̏�Ԃ���true��Ԃ�
        return GetComponent<SpriteRenderer>().color.a != 1;
    }

    public void DestroyWhenExitScreen()
    {
        if(transform.localPosition.x<-10)
        {
            Destroy(gameObject);
        }
    }

}
