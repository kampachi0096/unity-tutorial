using UnityEngine;

public class GridMovement : MonoBehaviour
{
    // 移動範囲の制限（テトリスの壁の役割）
    private float minX = -4f;
    private float maxX = 4f;
    private float minY = -4f;
    private float maxY = 4f;

    void Update()
    {
        // 右矢印キーが「押された瞬間」だけ反応（押しっぱなし移動ではない）
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMove(new Vector3(1, 0, 0));
        }
        // 左矢印キー
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMove(new Vector3(-1, 0, 0));
        }
        // 上矢印キー
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryMove(new Vector3(0, 1, 0));
        }
        // 下矢印キー
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryMove(new Vector3(0, -1, 0));
        }
    }

    // 移動を試みるメソッド
    void TryMove(Vector3 direction)
    {
        // 仮想的に移動後のポジションを計算してみる
        Vector3 targetPosition = transform.position + direction;

        // その場所が有効範囲内かチェック（境界値判定）
        if (IsValidPosition(targetPosition))
        {
            // OKなら実際に移動を反映
            transform.position = targetPosition;
            Debug.Log($"Moved to: {transform.position}");
        }
        else
        {
            Debug.Log("Wall! Cannot move.");
        }
    }

    // 座標が範囲内にあるか判定するメソッド（boolを返す）
    bool IsValidPosition(Vector3 pos)
    {
        // 単純な矩形範囲チェック
        // 本番のテトリスでは、ここに「他のブロックがあるか？」の判定も追加される
        if (pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY)
        {
            return false;
        }
        return true;
    }
}
