using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class SimpleMeshColliderGenerator : MonoBehaviour
{
    public MeshFilter targetMeshFilter;  // ���̃��b�V�����w��
    private Mesh simpleMesh;

    void Start()
    {
        GenerateSimpleMesh();
    }

    void GenerateSimpleMesh()
    {
        // �I���W�i�����b�V���̃o�E���f�B���O�{�b�N�X���擾
        Bounds bounds = targetMeshFilter.sharedMesh.bounds;

        // �ȈՓI�ȃ{�b�N�X���b�V���𐶐�
        simpleMesh = new Mesh();
        Vector3[] vertices = {
            bounds.min,  // ������
            new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),  // �E����
            new Vector3(bounds.max.x, bounds.max.y, bounds.min.z),  // �E�㉜
            new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),  // ���㉜
            new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),  // ������O
            new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),  // �E����O
            bounds.max,  // �E���O
            new Vector3(bounds.min.x, bounds.max.y, bounds.max.z)   // �����O
        };

        int[] triangles = {
            0, 2, 1, 0, 3, 2,  // ��
            4, 5, 6, 4, 6, 7,  // ��O
            0, 1, 5, 0, 5, 4,  // ��
            3, 7, 6, 3, 6, 2,  // ��
            0, 4, 7, 0, 7, 3,  // ��
            1, 2, 6, 1, 6, 5   // �E
        };

        // �ȈՓI��UV�}�b�s���O�i�e���_�ɑΉ�����UV���W�j
        Vector2[] uv = {
            new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1),
            new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1)
        };

        // ���b�V���̐ݒ�
        simpleMesh.vertices = vertices;
        simpleMesh.triangles = triangles;
        simpleMesh.uv = uv;
        simpleMesh.RecalculateNormals();

        // MeshCollider�ɊȈՃ��b�V����K�p
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = simpleMesh;

        // �\���m�F�p��MeshFilter�ɂ��ȈՃ��b�V����K�p�i�s�v�Ȃ�폜�j
        GetComponent<MeshFilter>().mesh = simpleMesh;
    }
}
