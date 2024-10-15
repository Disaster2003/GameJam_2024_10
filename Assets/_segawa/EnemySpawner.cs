using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField,Header("�G�I�u�W�F�N�g")]
    public GameObject[] _enemy;
    [SerializeField, Header("�ҋ@����")]
    public int wait;

    private int number;             //�����_���ɑI�΂ꂽ�G�̃C���f�b�N�X
    private int spawnwait;          //�ҋ@���Ԃ̏���   
    private int spawncount;         //�G�̃X�|�[�����𐔂���

    // Start is called before the first frame update
    void Start()
    {
        spawncount = 0;
        spawnwait = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait++;
        if (spawnwait % wait == 0)
        {
            EnemySpawn();
        }
    }
    
    //�G���X�|�[��������֐�
    private void EnemySpawn()
    {
        number = Random.Range(0, _enemy.Length);
        Instantiate(_enemy[number],transform.position,transform.rotation);
        spawncount++;
    }

    //�X�|�i�[��j�󂷂�֐�
    private void SpawnerDestroy()
    {
        Destroy(this);
    }
}