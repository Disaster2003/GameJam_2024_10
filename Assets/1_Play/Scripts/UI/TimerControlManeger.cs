using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimerControlManeger : MonoBehaviour
{
    public RectTransform[] uiElements; // �g�傷��UI�̔z��
    public float scaleDuration = 10f; // �g��ɂ����鎞�ԁi10�b�j
    public float maxScale = 10f;      //�g��T�C�Y
    public float waitBeforeHide = 2f; // ������܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        // �S�Ă�UI���\����
        HideAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        ShowAndScaleUI(PhaseManager.GetInstance().GetIndexPhase());
    }
    // �w�肵���C���f�b�N�X��UI�v�f��\������֐�

    public void ShowAndScaleUI(int index)
    {
        if (index < 0 || index >= uiElements.Length)
        {
            Debug.LogWarning("�C���f�b�N�X�������ł�: " + index);      //�w�肵���C���f�b�N�X�ȊO�̓��͂ŃG���[

            return;
        }

        StartCoroutine(ScaleAndHideUI(uiElements[index]));      //�C���f�b�N�X���L���ȏꍇ�Ɋg��A�폜�̊֐����Ăяo��
    }

    
    private IEnumerator ScaleAndHideUI(RectTransform uiElement) //�g��\���Ɣ�\���ɂ�����UI�̎w��
    {
        // UI��\��
        uiElement.gameObject.SetActive(true);

        // �g��̂��߂̎��Ԍo��
        float elapsedTime = 0f;
        Vector3 initialScale = uiElement.localScale;    //���̉摜�T�C�Y�̎擾
        Vector3 targetScale = initialScale * maxScale;  //�w��T�C�Y

        while (elapsedTime < scaleDuration)
        {
            //�g�又�������炩�ɂ��邽�߂̏���
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / scaleDuration);

            //�����̑傫������w�肵���傫���܂Ŋg�傷��܂ŉ��Z
            elapsedTime += Time.deltaTime;

            //���̃t���[���܂őҋ@
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
            uiElement.gameObject.SetActive(false);      //UI���\���ɂ���
        }
    }
}
