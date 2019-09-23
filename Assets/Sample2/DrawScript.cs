using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    public GameObject obj;
    GameObject drawObj;
    List<GameObject> lines = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            // カメラ手前10cmの位置を取得
            Vector3 p = Camera.main.transform.TransformPoint(0, 0, 0.1f);
            // タッチスタート
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //drawObj = GameObject.Instantiate(obj, p, Quaternion.identity);
                GameObject tmp = GameObject.Instantiate(obj, p, Quaternion.identity);
                lines.Add(tmp);
                drawObj = tmp;
            }
            // 押下中
            else if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                drawObj.transform.position = p;
            }
        }
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                for(int i = 0; i < lines.Count; i++)
                {
                    Destroy(lines[i]);
                    lines[i] = null;
                }
                lines.Clear();
            }
        }
        
    }
}
