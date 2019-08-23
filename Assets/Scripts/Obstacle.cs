using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int rotationSpeed;

    void FixedUpdate()
    {
        if(rotationSpeed != 0) {
            Rotation();
        }
    }

    void Rotation() {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
