using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    // 動かしたいオブジェクトを指定
    public GameObject targetObject;

    // ワールド座標へのスケール変換用変数
    public Vector2 worldScale = new Vector2(10f, 10f); // ワールド座標へのスケール調整

    // 固定する z 座標
    private float fixedZ;

    void Start()
    {
        // targetObject が設定されている場合の z 座標を取得
        if (targetObject != null)
        {
            fixedZ = targetObject.transform.position.z;
        }
    }

    void Update()
    {
        // マウス左クリックの検出
        if (Input.GetMouseButtonDown(0))
        {
            // カメラからクリック位置へのレイを作成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // レイキャストでオブジェクトのコライダーとの交点をチェック
            if (Physics.Raycast(ray, out hit))
            {
                // テクスチャ座標の取得 (0〜1の範囲)
                Vector2 textureCoord = hit.textureCoord;

                // テクスチャ座標をワールド座標に変換
                Vector3 worldPosition = new Vector3(textureCoord.x * worldScale.x * -0.4f, textureCoord.y * worldScale.y * 0.4f, fixedZ);

                // targetObjectが設定されている場合、位置を更新
                if (targetObject != null)
                {
                    targetObject.transform.position = worldPosition;
                }

                // テクスチャ座標をログに表示
                Debug.Log("テクスチャ座標: " + textureCoord);
            }
        }
    }
}
