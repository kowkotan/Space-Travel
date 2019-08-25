using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    private GameObject playerObj;
    Vector3 velocity;

    private void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        transform.position = Vector3.Slerp(transform.position, 
        new Vector3(Camera.main.transform.position.x + 3f, playerObj.transform.position.y + 6f, transform.position.z), 1f);
    }

}
