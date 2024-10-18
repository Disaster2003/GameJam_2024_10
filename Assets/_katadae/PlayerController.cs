using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] float _speed, _flashInterval;
    //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] int _loopCount;
    //�_�ł����邽�߂�SpriteRenderer
    SpriteRenderer _sp;
    //�R���C�_�[���I���I�t���邽�߂�BoxCollider2D
    CircleCollider2D _cc2d;

    //(�X�e�[�^�X _st=1(�m�[�}���j_st=2=�i�_���[�W�j_st=3=(���G)
    public int _st;

    public float _Count;


    //�U��
    public GameObject BulletObj;  // �e�̃Q�[���I�u�W�F�N�g
    Vector3 bulletPoint;                // �e�̈ʒu
   



    private void Start()
    {
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
        //�p�^�[��1
        //_x = 0;
        //_y = 0;

        //if (Input.GetKey("right") || Input.GetKey("d"))
        //{
        //    _x = _speed;
        //}

        //else if (Input.GetKey("left") || Input.GetKey("a"))
        //{
        //    _x = -_speed;
        //}

        //if (Input.GetKey("up") || Input.GetKey("w"))
        //{
        //    _y = _speed;
        //}

        //else if (Input.GetKey("down") || Input.GetKey("s"))
        //{
        //    _y = -_speed;
        //}

        //�p�^�[��2


        //�X�e�[�g���_���[�W�Ȃ烊�^�[��
        if (_st == 2 )
        {
            return;
        }


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
        //this.transform.Translate(_vx/50, _vy/50, 0);

    }


    //���������Ƃ��̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {


        //�G�l�~�[�q�b�g�Ń_���[�W
        if (collision.gameObject.tag == "Enemy")
        {
            _currentHP = _currentHP - 1;

            //�m�[�}������Ȃ��i�_���[�W���A���G���j�Ƃ��̓��^�[��
            if (_st != 1)
            {
                return;
            }
            _st = 2;
            StartCoroutine(_hit());


        }


        //IEnumerator _hit()
        //{
        //    //_Count += Time.deltaTime;
        //    _cc2d.enabled = false;
        //    for (int i = 0; i < _loopCount; i++)
        //    {


        //        yield return new WaitForSeconds(_flashInterval);
        //        _sp.enabled = false;
        //        yield return new WaitForSeconds(_flashInterval);
        //        _sp.enabled = true;
        //        if (i > 20)
        //        {
        //            _st = 3;

        //            //if (_st == 3&&_Count>=10f)
        //            //{


        //            //}
        //        }
        //    }

        //    _st=1;
        //    _cc2d.enabled = true;
        //    _sp.color = Color.white;
        //}


        IEnumerator _hit()
        {
            //_Count += Time.deltaTime;
            _cc2d.enabled = false;
            for (int i = 0; i < _loopCount; i++)
            {


                yield return new WaitForSeconds(_flashInterval);
                _sp.enabled = false;
                yield return new WaitForSeconds(_flashInterval);
                _sp.enabled = true;
                if (i > 20)
                {
                    _st = 3;

                    //if (_st == 3&&_Count>=10f)
                    //{


                    //}
                }
            }

            _st = 1;
            _cc2d.enabled = true;
            _sp.color = Color.white;
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    ////�G�l�~�[�q�b�g�Ń_���[�W
    //    //if (collision.gameObject.tag == "Enemy")
    //    //{
    //    //    _currentHP = _currentHP - 1;
    //    //    if (_isHit == true)
    //    //    {
    //    //        _currentHP = _currentHP - 1;
    //    //    }
    //    //    Debug.Log("Enemy");
    //    //}

    //    //    //�񕜌n�q�b�g�ŉ񕜁iMAX�@HP10�܂Łj
    //    //    if (collision.gameObject.tag == "Life")
    //    //{
    //    //    _currentHP = _currentHP + 1;

    //    //    if (_currentHP > 10)
    //    //    {
    //    //        _currentHP = 10;

    //    //    }
    //    //    Debug.Log("Life");
    //    //}
    //}



}
