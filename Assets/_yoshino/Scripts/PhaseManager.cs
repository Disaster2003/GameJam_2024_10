using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager instance; // �N���X�̃C���X�^���X

    [SerializeField] int intervalPhase; // �t�F�[�Y�Ԋu
    private int indexPhase;             // �t�F�[�Y�ԍ�

    // Start is called before the first frame update
    void Start()
    {
        indexPhase = 0; // �t�F�[�Y�ԍ�
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Timer>().GetTimer() % intervalPhase < 0.01f)
        {
            // �t�F�[�Y�̍X�V
            indexPhase++;
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
}
