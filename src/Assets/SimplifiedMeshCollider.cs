using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class SimpleMeshColliderGenerator : MonoBehaviour
{
    public MeshFilter targetMeshFilter;  // 元のメッシュを指定
    private Mesh simpleMesh;

    void Start()
    {
        GenerateSimpleMesh();
    }

    void GenerateSimpleMesh()
    {
        // オリジナルメッシュのバウンディングボックスを取得
        Bounds bounds = targetMeshFilter.sharedMesh.bounds;

        // 簡易的なボックスメッシュを生成
        simpleMesh = new Mesh();
        Vector3[] vertices = {
            bounds.min,  // 左下奥
            new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),  // 右下奥
            new Vector3(bounds.max.x, bounds.max.y, bounds.min.z),  // 右上奥
            new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),  // 左上奥
            new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),  // 左下手前
            new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),  // 右下手前
            bounds.max,  // 右上手前
            new Vector3(bounds.min.x, bounds.max.y, bounds.max.z)   // 左上手前
        };

        int[] triangles = {
            0, 2, 1, 0, 3, 2,  // 奥
            4, 5, 6, 4, 6, 7,  // 手前
            0, 1, 5, 0, 5, 4,  // 下
            3, 7, 6, 3, 6, 2,  // 上
            0, 4, 7, 0, 7, 3,  // 左
            1, 2, 6, 1, 6, 5   // 右
        };

        // 簡易的なUVマッピング（各頂点に対応するUV座標）
        Vector2[] uv = {
            new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1),
            new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1)
        };

        // メッシュの設定
        simpleMesh.vertices = vertices;
        simpleMesh.triangles = triangles;
        simpleMesh.uv = uv;
        simpleMesh.RecalculateNormals();

        // MeshColliderに簡易メッシュを適用
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = simpleMesh;

        // 表示確認用にMeshFilterにも簡易メッシュを適用（不要なら削除可）
        GetComponent<MeshFilter>().mesh = simpleMesh;
    }
}
