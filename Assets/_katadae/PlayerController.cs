using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class PlayerController : MonoBehaviour
{   

    //�ړ���x
    private float _x;
    //�ړ���y
    private float _y;
    //�̗�
    public int _currentHP;

    //�ړ��͈́iX�����@_xLimit=-�����@_xLimit2=+�����j
    public float _xLimit;
    public float _xLimit2;

    //�ړ��͈́iY�����j
    public float _yLimit;

    //�ړ��X�s�[�h�Ɠ_�ł̊Ԋu
    [SerializeField] float _speed;
    //�_�ł����邽�߂�SpriteRenderer
    SpriteRenderer _sp;
    //�R���C�_�[���I���I�t���邽�߂�CircleCollider2D
    CircleCollider2D _cc2d;

    //�_���[�W����
    public int _st;//����X�e�[�^�X
    public int _pst;//���G�X�e�[�^�X
    public float _timer;//�q�b�g�X�g�b�v
    public float _timer2;//���G���u
    public float _Mtimer;
    public bool _HitStop;

    // �_�ł�����Ώ�
    [SerializeField] private Renderer _target;
    // �_�Ŏ���[s]
    [SerializeField] private float _cycle = 1;


    //�U��
    public GameObject BulletObj;  // �e�̃Q�[���I�u�W�F�N�g
    Vector3 bulletPoint;                // �e�̈ʒu
   



    private void Start()
    {
        _pst = 0;
        _st = 1;
        
        //SpriteRenderer�i�[
       _sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D�i�[
       _cc2d = GetComponent<CircleCollider2D>();

        //�ʂ̔��˃|�C���g
        bulletPoint = transform.Find("BulletPoint").localPosition;
       
    }


    // Update is called once per frame
    void Update()
    {

        //�q�b�g�X�g�b�v
        if (_HitStop == false)
        {
            if (_st == 1)
            {
                _x = Input.GetAxisRaw("Horizontal");
                _y = Input.GetAxisRaw("Vertical");
                transform.Translate(new Vector3(_x, _y, 0) * _speed * Time.deltaTime);


                //���݂̃|�W�V������ێ�����
                Vector3 currentPos = transform.position;

                //Mathf.Clamp��X,Y�̒l���ꂼ�ꂪ�ŏ��`�ő�͈͓̔��Ɏ��߂�B
                //�͈͂𒴂��Ă�����͈͓��̒l��������
                currentPos.x = Mathf.Clamp(currentPos.x, -_xLimit, _xLimit2);
                currentPos.y = Mathf.Clamp(currentPos.y, -_yLimit, _yLimit);

                //�ǉ��@position��currentPos�ɂ���
                transform.position = currentPos;



                Tama();
            }



            //���G����
            if (_pst == 1)
            {
                
               _Mtimer += Time.deltaTime;
                _cc2d.enabled = false;
                // ����cycle�ŌJ��Ԃ��l�̎擾
                // 0�`cycle�͈̔͂̒l��������
                var repeatValue = Mathf.Repeat((float)_Mtimer, _cycle);
                // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
                _target.enabled = repeatValue <= _cycle * 0.5f;

               
                _timer2 += Time.deltaTime;
                if (_timer2 >= 5f)
                {
                    _Mtimer = 0;
                    _timer2 = 0;
                    _cc2d.enabled = true;
                    _sp.color = Color.white;
                    _pst = 0;
                }
            }
        }
    }


    void Tama()
    {
        // �ʔ��˃{�^��
        if (Input.GetKeyDown("space"))
        {
            // �e�̐���
            Instantiate(BulletObj, transform.position + bulletPoint, Quaternion.identity);
        }
      
       
    }


    void FixedUpdate()
    {
        //�q�b�g�X�g�b�v
        if (_HitStop)
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.5f)
            {
                _timer = 0;
                _HitStop = false;
                _st = 1;


                
            }

        }

        

    }

    //���������Ƃ��̏���
    void OnTriggerEnter2D(Collider2D collision)
    {


        //�G�l�~�[�q�b�g�Ń_���[�W
        if (collision.gameObject.tag == "Enemy")
        {
            _currentHP = _currentHP - 1;
            _HitStop = true;
            _Mtimer = 0;
            _pst = 1;

        }
        

        //�񕜌n�q�b�g�ŉ񕜁iMAX�@HP10�܂Łj
        if (collision.gameObject.tag == "Life")
        {
            _currentHP = _currentHP + 1;

            if (_currentHP > 10)
            {
                _currentHP = 10;

            }
            Debug.Log("Life");
        }
    }

    



}
