using UnityEngine;

public class SmoothDragObject : MonoBehaviour
{
    public GameObject targetObject;   // �ړ����������I�u�W�F�N�g���w��
    public float smoothSpeed = 5f;    // �I�u�W�F�N�g�̒Ǐ]���x

    private bool isDragging = false;  // �h���b�O��Ԃ�ێ�����t���O
    private Vector3 targetPosition;   // �ڕW�ʒu��ێ�����ϐ�

    void Update()
    {
        // �}�E�X�̍��{�^���������ꂽ��h���b�O�J�n
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                isDragging = true;
            }
        }

        // �}�E�X�̍��{�^���������ꂽ��h���b�O�I��
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // �h���b�O���̓I�u�W�F�N�g���}�E�X�̈ʒu�Ɋ��炩�ɒǏ]������
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // �}�E�X�ʒu��x��z���W��ڕW�ʒu�Ƃ��Đݒ肵�Ay���W�̓I�u�W�F�N�g�̏����������ێ�
                targetPosition = new Vector3(hit.point.x, targetObject.transform.position.y, hit.point.z);

                // ��Ԃ��g���ăI�u�W�F�N�g�����炩�ɖڕW�ʒu�Ɉړ�
                targetObject.transform.position = Vector3.Lerp(
                    targetObject.transform.position,
                    targetPosition,
                    Time.deltaTime * smoothSpeed
                );
            }
        }
    }
}
