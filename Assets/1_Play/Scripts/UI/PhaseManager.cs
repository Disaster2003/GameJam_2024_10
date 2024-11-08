using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager instance; // �N���X�̃C���X�^���X

    [SerializeField, Header("�t�F�[�Y�Ԋu")] int[] intervalPhase;
    private int indexPhase;

    [SerializeField, Header("Spawner")] 
    private GameObject[] spawner = new GameObject[12];

    float Updateinterval;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�͂�");

        if (instance == null)
        {
            // �C���X�^���X�̐���
            instance = this;
        }

        // �t�F�[�Y�ԍ��̏�����
        indexPhase = 0;

        Updateinterval = 2f;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �t�F�[�Y�i�s
        int timer = (int)GetComponent<Timer>().GetSurvivalTimer();
        if(Updateinterval < 0)
        {
            if (timer > 120)
            {
                UpdatePhase(timer, 1);
            }
            else
            {
                UpdatePhase(timer, 0);
            }
        }
        else
        {
            Updateinterval -= Time.deltaTime;
        }
       
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static PhaseManager GetInstance() { return instance; }

    /// <summary>
    /// �t�F�[�Y�ԍ����擾����
    /// </summary>
    public int GetIndexPhase() { return indexPhase; }

    /// <summary>
    /// �t�F�[�Y���X�V����
    /// </summary>
    /// <param name="_timer">�^�C�}�[</param>
    /// <param name="index">�w�肷��b���z��̃C���f�b�N�X</param>
    private void UpdatePhase(int _timer, int index)
    {
        
        if (_timer % intervalPhase[index] == 0)
        {
            Debug.Log(_timer);
            // �t�F�[�Y�̍X�V
            indexPhase++;
            EnemyDelete();
            SpawnerChange();
            BulletDelete();

            Updateinterval = 2f;

            audioSource.Play();

            Debug.Log("�X�V������");
        }
    }

    /// <summary>
    /// �t�F�[�Y�i�s���ɓG����������
    /// </summary>
    private void EnemyDelete()
    {
        // "Enemy"�^�O�����S�Ă�GameObject���擾
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // �擾����GameObject������j��
        foreach (GameObject enemy in enemies)
        {
            // �G�̎��S���o��
            EnemyBase enemybase = enemy.GetComponent<EnemyBase>();
            enemybase.Dead();
        }

    }

    /// <summary>
    /// �t�F�[�Y�i�s���ɓG����������
    /// </summary>
    private void BulletDelete()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            BulletComponent bulletComponent = bullet.GetComponent<BulletComponent>();

            if(bulletComponent != null)
            {
                if (!bulletComponent.GetisPlayerBullet())
                {
                    bulletComponent.DestoryBullet();
                    continue;
                }
            }

            
        }
    }

    /// <summary>
    /// �t�F�[�Y�i�s���Ɏg���Ă����X�|�i�[��OFF�A
    /// ���Ɏg���X�|�i�[��ON
    /// </summary>
    private void SpawnerChange()
    {
        for(int i = 0; i < spawner.Length; i++)
        {
            if(i == indexPhase)
            {
                spawner[i].SetActive(true);
            }
            else
            {
                spawner[i].SetActive(false);
            }
        }

        
    }
}
