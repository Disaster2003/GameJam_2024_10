using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    private static ItemCounter instance;

    [SerializeField, Header("�{���`���[�W�̍ő吔")]
    private int countBombChargeMax;
    private int counterBombCharge;

    [SerializeField, Header("�J�E���^�[��")]
    private Image imgBomb;
    [SerializeField, Header("�ʏ펞�摜")]
    private Sprite spNormal;
    [SerializeField, Header("�ő�l�摜")]
    private Sprite spMax;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // �C���X�^���X�̐���
            instance = this;
        }

        // �{���`���[�W�̏�����
        counterBombCharge = 0;
        GetComponent<Text>().text = $"{counterBombCharge}/{countBombChargeMax}";

        //// �摜�̏�����
        //imgBomb.sprite = spNormal;
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static ItemCounter GetInstance() { return instance; }

    /// <summary>
    /// �{���`���[�W�����擾����
    /// </summary>
    public int GetBombChargeCounter() { return counterBombCharge; }

    /// <summary>
    /// �{���`���[�W���𑝂₷
    /// </summary>
    public void IncreaseBombChargeCounter()
    {
        if (counterBombCharge == countBombChargeMax)
        {
            //// �摜�ύX
            //imgBomb.sprite = spMax;
        }
        else if (counterBombCharge < countBombChargeMax)
        {
            // �{���`���[�W���𑝂₷
            counterBombCharge++;
            GetComponent<Text>().text = $"{counterBombCharge}/{countBombChargeMax}";
        }
    }

    /// <summary>
    /// �{���`���[�W���E�摜�̃��Z�b�g
    /// </summary>
    public void ResetBombChargeCounter()
    { 
        counterBombCharge = 0;
        //imgBomb.sprite= spNormal;
    }
}
