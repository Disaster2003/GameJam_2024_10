using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter : MonoBehaviour
{
    private static ItemCounter instance; // �N���X�̃C���X�^���X

    private int numberItem; // �A�C�e����

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // Singleton
            instance = this;
        }

        numberItem = 0; // �A�C�e�����̏�����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static ItemCounter GetInstance() { return instance; }

    /// <summary>
    /// �A�C�e�������擾����
    /// </summary>
    public int GetNumberItem() { return numberItem; }

    /// <summary>
    /// �A�C�e�����𑝂₷
    /// </summary>
    public void IncreaseNumberItem() { if (numberItem < 20) numberItem++; }
}
