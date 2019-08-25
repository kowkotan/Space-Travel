using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject playerObj;
    float smoothTime = 1f;
    int cameraOfsset = 11;

    void FixedUpdate()
    {
        PlayerFollow();    
    }

    void PlayerFollow() {
        Vector3 targetPos = playerObj.transform.TransformPoint(new Vector3(0, cameraOfsset, -10));
        targetPos = new Vector3(0, targetPos.y, targetPos.z);

        transform.position = Vector3.Slerp(transform.position, targetPos, smoothTime);
    }
}
