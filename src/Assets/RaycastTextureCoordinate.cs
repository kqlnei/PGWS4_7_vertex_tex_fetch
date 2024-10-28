using UnityEngine;
public class RaycastTextureCoordinate : MonoBehaviour
{
    void Update()
    {
        // �}�E�X���N���b�N�̌��o
        if (Input.GetMouseButtonDown(0))
        {
            // �J��������N���b�N�ʒu�ւ̃��C���쐬
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���C�L���X�g�ŃI�u�W�F�N�g�̃R���C�_�[�Ƃ̌�_���`�F�b�N
            if (Physics.Raycast(ray, out hit))
            {
                // �e�N�X�`�����W�̎擾
                Vector2 textureCoord = hit.textureCoord;

                // ��_�̏������O�ɕ\��
                Debug.Log("�e�N�X�`�����W: " + textureCoord);
            }
        }
    }
}
