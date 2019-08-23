using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject playerObj;
    float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;
    int yOfsset = 11;

    void Update()
    {
        PlayerFollow();    
    }

    void PlayerFollow() {
        Vector3 targetPos = playerObj.transform.TransformPoint(new Vector3(0, yOfsset, -10));
        targetPos = new Vector3(0, targetPos.y, targetPos.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
