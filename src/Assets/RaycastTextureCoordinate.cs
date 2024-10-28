using UnityEngine;
public class RaycastTextureCoordinate : MonoBehaviour
{
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
                // テクスチャ座標の取得
                Vector2 textureCoord = hit.textureCoord;

                // 交点の情報をログに表示
                Debug.Log("テクスチャ座標: " + textureCoord);
            }
        }
    }
}
