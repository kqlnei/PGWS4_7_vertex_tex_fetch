using UnityEngine;

public class SmoothDragObject : MonoBehaviour
{
    public GameObject targetObject;   // 移動させたいオブジェクトを指定
    public float smoothSpeed = 5f;    // オブジェクトの追従速度

    private bool isDragging = false;  // ドラッグ状態を保持するフラグ
    private Vector3 targetPosition;   // 目標位置を保持する変数

    void Update()
    {
        // マウスの左ボタンが押されたらドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                isDragging = true;
            }
        }

        // マウスの左ボタンが離されたらドラッグ終了
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // ドラッグ中はオブジェクトをマウスの位置に滑らかに追従させる
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // マウス位置のxとz座標を目標位置として設定し、y座標はオブジェクトの初期高さを維持
                targetPosition = new Vector3(hit.point.x, targetObject.transform.position.y, hit.point.z);

                // 補間を使ってオブジェクトを滑らかに目標位置に移動
                targetObject.transform.position = Vector3.Lerp(
                    targetObject.transform.position,
                    targetPosition,
                    Time.deltaTime * smoothSpeed
                );
            }
        }
    }
}
