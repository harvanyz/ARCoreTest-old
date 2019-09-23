using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PutScript : MonoBehaviour
{
    public GameObject obj; // CGを扱う変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // タッチしていない場合終了
        if (Input.touchCount < 1) { return; }
        Touch touch = Input.GetTouch(0);

        // 画面をなぞってない場合return
        if (touch.phase != TouchPhase.Moved) { return; }

        // タップした座標に移動
        TrackableHit hit;
        TrackableHitFlags filter = TrackableHitFlags.PlaneWithinPolygon;
        if (Frame.Raycast(touch.position.x, touch.position.y, filter, out hit) )
        {
            // 平面にヒットしたらオブジェクトを置く
            if (hit.Trackable is DetectedPlane)
            {
                // objectの位置・姿勢を指定
                obj.transform.position = hit.Pose.position;
                obj.transform.rotation = hit.Pose.rotation;
                obj.transform.Rotate(0, 180, 0, Space.Self);

                // Anchorを設定
                var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                obj.transform.parent = anchor.transform;
            }
        }
        
    }
}
