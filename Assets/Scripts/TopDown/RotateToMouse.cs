using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class RotateToMouse : MonoBehaviour
    {
        Plane plane = new Plane();
        float distance = 0;

        private void Update()
        {
            // カメラとマウスの位置を元にRayを準備
            var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

            // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
            plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
            if (plane.Raycast(ray, out distance))
            {
                // 距離を元に交点を算出して、交点の方を向く
                var lookPoint = ray.GetPoint(distance);
                transform.LookAt(lookPoint);
            }
        }
    }

}
