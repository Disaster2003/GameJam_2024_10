using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerComponent : MonoBehaviour
{
    private static PlayerComponent instance;

    private Rigidbody2D rb;

    [SerializeField, Header("�����ʒu")]
    private Vector3 positionInitialize;

    private Vector3 inputMove;
    [SerializeField, Header("�ړ����x")]
    private float speedMove;
    [SerializeField, Header("�ړ��͈�")]
    private Vector3 positionMoveLimit;

    [SerializeField, Header("�e")]
    private GameObject bullet;
    [SerializeField, Header("���e")]
    private GameObject bomb;

    [SerializeField, Header("�ő�̗�")]
    private int hpMax;
    private int hp;

    private SpriteRenderer sr;
    private bool isInvincible;
    [SerializeField, Header("���G����")]
    private float timeInvincible;
    [SerializeField, Header("�L�[���͕s����")]
    private float timeImpossibleInputKey;
    private float timerInvincible;
    [SerializeField, Header("�_�Ŏ���")]
    private float cycleBlink;

    private Animator animator;

    [SerializeField, Header("�ʏ펞�̉摜")]
    private Sprite normalSprite;

    [SerializeField, Header("��e���̉摜")]
    private Sprite hitSprites;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // �C���X�^���X�̐���
            instance = this;
        }

        rb = GetComponent<Rigidbody2D>(); // �R���|�[�l���g�̎擾
        rb.freezeRotation = true;         // ��]�s��

        // �����z�u
        transform.position = positionInitialize;

        // ���͂̏�����
        inputMove = Vector3.zero;

        // �̗͂̏�����
        hp = hpMax;

        // ���G�֘A�̏�����
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        isInvincible = false;
        timerInvincible = 0;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HitEffect();

        // �_���[�W���͓����Ȃ�
        if (timerInvincible > timeInvincible - timeImpossibleInputKey) return;
        Move();
        SpawnBullet();
        SpawnBomb();
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static PlayerComponent GetInstance() {  return instance; }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        // �R���g���[���[�Ȃ�AGetAxis
        inputMove.x = Input.GetAxisRaw("Horizontal");
        inputMove.y = Input.GetAxisRaw("Vertical");
        transform.Translate(inputMove * speedMove * Time.deltaTime);

        ReturnBackPosition(positionMoveLimit);
    }

    /// <summary>
    /// �͈͓��ֈʒu����������
    /// </summary>
    /// <param name="positionLimit">�����͈͂̈ʒu</param>
    private void ReturnBackPosition(Vector3 positionLimit)
    {
        // null�`�F�b�N
        if(positionLimit == Vector3.zero) return;

        // �ʒu���w�肳�ꂽ�͈͓���
        Vector3 positionRange = Vector3.zero;
        positionRange.x = Mathf.Clamp(transform.position.x, -positionLimit.x, positionLimit.x);
        positionRange.y = Mathf.Clamp(transform.position.y, -positionLimit.y, positionLimit.y);
        transform.position = positionRange;
    }

    /// <summary>
    /// �e�𐶐�����
    /// </summary>
    private void SpawnBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    /// <summary>
    /// ���e�𐶐�����
    /// </summary>
    private void SpawnBomb()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bomb, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // null�`�F�b�N
        if (collision == null) return;

        if(collision.CompareTag("Enemy"))
        {
            // ���G��
            if (isInvincible) return;

            // �_���[�W
            hp--;
            isInvincible = true;
            timerInvincible = timeInvincible;

            SetDamageSprite();

        }
    }

    /// <summary>
    /// �̗͂��擾����
    /// </summary>
    public int GetHp() {  return hp; }

    /// <summary>
    /// �q�b�g�G�t�F�N�g
    /// </summary>
    private void HitEffect()
    {
        if (!isInvincible)
        {
            // �ʏ���
            sr.color = Color.white;
            return;
        }

        if(timerInvincible <= 0)
        {
            // ���G�I��
            isInvincible = false;
            animator.enabled = true;
            sr.sprite = normalSprite;
            sr.enabled = true;
        }
        else
        {
            // ���G���Ԃ̌���
            timerInvincible += -Time.deltaTime;
            // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
            sr.enabled = Mathf.Repeat(timerInvincible, cycleBlink) <= cycleBlink * 0.5f;
        }
    }

    public void SetDamageSprite()
    {
        animator.enabled = false;
        sr.sprite = hitSprites;
    }

}
