using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottonSizeChange : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public float scaleSpeed = 2.0f;          // �g��E�k���̑��x
    public float maxScale = 1.2f;       // �ő�T�C�Y�{��
    public float minScale = 1.0f;       // �ŏ��T�C�Y�{���i�ʏ�̃T�C�Y�j

    private bool isHovering = false;  // �}�E�X��UI��ɂ��邩�ǂ����̃t���O
    private RectTransform rectTransform; // UI�v�f��RectTransform
    private float targetScale;         // ���݂̃X�P�[���^�[�Q�b�g
    private Vector3 initialScale;

    // ����������
    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // RectTransform�R���|�[�l���g���擾
        targetScale = minScale; // �����^�[�Q�b�g�X�P�[�����ŏ��X�P�[���ɐݒ�
        initialScale = rectTransform.localScale;
    }

    // �t���[�����Ƃ̍X�V����
    void Update()
    {
        if (isHovering) // �}�E�X��UI��ɂ���ꍇ
        {
            // �X�P�[�����X�V
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, new Vector3(targetScale, targetScale, 1), Time.unscaledDeltaTime * scaleSpeed);

            // �X�P�[���̃^�[�Q�b�g��؂�ւ�
            if (Mathf.Abs(rectTransform.localScale.x - targetScale) < 0.01f) // �X�P�[�����ڕW�ɋ߂Â�����
            {
                targetScale = targetScale == minScale ? maxScale : minScale; // �^�[�Q�b�g��؂�ւ���
            }
        }
    }

    // �}�E�X��UI�v�f�ɏ�������̏���
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true; // �}�E�X��UI��ɏ������Ԃɂ���
        Debug.Log("Enter");
    }

    // �}�E�X��UI�v�f���痣�ꂽ���̏���
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false; // �}�E�X��UI���痣�ꂽ��Ԃɂ���
        rectTransform.localScale = initialScale; // �����X�P�[���ɖ߂�
        Debug.Log("Enter");
    }
}
