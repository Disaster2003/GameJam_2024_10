using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    // �Q�[�����I�������郁�\�b�h
    public void QuitGame()
    {
        // �Q�[�����G�f�B�^�Ŏ��s���̏ꍇ�́A�G�f�B�^���~����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^���~
#else
        Application.Quit(); // �r���h�łŃQ�[�����I��
#endif
        // �I�������̌�A�K�v�ɉ����ă��\�[�X�̉���Ȃǂ��s�����Ƃ��ł��܂��B
        Debug.Log("�Q�[�����I�����܂����B");
    }
}
