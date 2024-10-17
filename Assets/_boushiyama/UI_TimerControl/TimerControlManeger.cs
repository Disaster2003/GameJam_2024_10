using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerControlManeger : MonoBehaviour
{
    public RectTransform[] uiElements; // �g�傷��UI�v�f�̔z��
    public float scaleDuration = 10f; // �g��ɂ����鎞�ԁi10�b�j
    public float maxScale = 10f; // �ő�X�P�[��
    public float waitBeforeHide = 2f; // ������܂ł̑ҋ@����

    // Start is called before the first frame update
    void Start()
    {
        // ������ԂőS�Ă�UI���\����
        HideAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // �w�肵���C���f�b�N�X��UI�v�f��\������֐�
    public void ShowAndScaleUI(int index)
    {
        if (index < 0 || index >= uiElements.Length)
        {
            Debug.LogWarning("�C���f�b�N�X�������ł�: " + index);
            return;
        }

        StartCoroutine(ScaleAndHideUI(uiElements[index]));
    }

    private IEnumerator ScaleAndHideUI(RectTransform uiElement)
    {
        // UI��\��
        uiElement.gameObject.SetActive(true);

        // �g��̂��߂̎��Ԍo��
        float elapsedTime = 0f;
        Vector3 initialScale = uiElement.localScale;
        Vector3 targetScale = initialScale * maxScale;

        while (elapsedTime < scaleDuration)
        {
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        uiElement.localScale = targetScale; // �ŏI�I�ȃX�P�[���ɐݒ�

        // �w�肳�ꂽ���ԑ҂�
        yield return new WaitForSeconds(waitBeforeHide);

        // UI���\��
        uiElement.gameObject.SetActive(false);
    }

    // ���ׂĂ�UI���\���ɂ���֐�
    private void HideAllUI()
    {
        foreach (RectTransform uiElement in uiElements)
        {
            uiElement.gameObject.SetActive(false);
        }
    }

    //
    public void OnbottonClick(int imageIndex)
    {
        ShowAndScaleUI(imageIndex);
    }

}
