using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager instance; // �N���X�̃C���X�^���X

    [SerializeField] int[] intervalPhase; // �t�F�[�Y�Ԋu
    private int indexPhase;             // �t�F�[�Y�ԍ�

    // Start is called before the first frame update
    void Start()
    {
        indexPhase = 0; // �t�F�[�Y�ԍ��̏�����
    }

    // Update is called once per frame
    void Update()
    {
        // �t�F�[�Y�i�s
        float timer = GetComponent<Timer>().GetTimer();
        if (timer > 120)
        {
            UpdatePhase(timer, 1);
        }
        else
        {
            UpdatePhase(timer, 0);
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
    private void UpdatePhase(float _timer, int index)
    {
        if (_timer % intervalPhase[index] < 0.01f)
        {
            // �t�F�[�Y�̍X�V
            indexPhase++;
            //EnemyDelete();
            //SpawnerChange();
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
            
        }
    }

    /// <summary>
    /// �t�F�[�Y�i�s���Ɏg���Ă����X�|�i�[��OFF�A
    /// ���Ɏg���X�|�i�[��ON
    /// </summary>
    private void SpawnerChange()
    {
        // �Q�[���I�u�W�F�N�g�̔z����擾
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        // �z����̊e�Q�[���I�u�W�F�N�g�����[�v�ŏ���
        foreach (GameObject obj in allObjects)
        {
            // �I�u�W�F�N�g�̖��O�� "Spawner" + indexPhase ���܂�ł��邩�`�F�b�N
            if (obj.name.Contains("Spawner" + indexPhase))
            {
                obj.SetActive(true);
            }
            else if (obj.name.Contains("Spawner"))
            {
                obj.SetActive(false);
            }
        }
    }
}
