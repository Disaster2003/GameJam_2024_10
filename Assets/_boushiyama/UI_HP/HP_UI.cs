using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    public int maxHealth = 10; // �ő僉�C�t
    public int currentHealth; // ���݂̃��C�t
    public Image[] heartImages; // �n�[�g��Image�R���|�[�l���g

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �X�y�[�X�L�[�Ń_���[�W
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.H)) // H�L�[�ŉ�
        {
            Heal(1);
        }
    }
    //�_���[�W
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthUI();
    }
    //��
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
                heartImages[i].enabled = true; // �n�[�g��\��
            else
                heartImages[i].enabled = false; // �n�[�g���\��
        }
    }
}
