using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    public Transform target;
    //边界
    public float MinX;
    public float MaxX;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = transform.position;

        //更新相机的位置
        v.x = target.position.x;
        //边界判断
        if (v.x > MaxX)
        {
            v.x = MaxX;
        }
        else if (v.x < MinX)
        {
            v.x = MinX;
        }
        //赋值回来
        transform.position = v;

    }
}
