using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Rotation Variables")]
    public bool isRotation;
    public int rotationSpeed;

    [Header("Moving Variables")]
    public bool isMoving;
    public int moovingSpeed;

    [Header("Pendulum Variables")]
    public bool isPendulum;
    public float velocityThreshold;

    private void Start() {
        if(isPendulum) {
            Pendulum();
        }
    }

    void FixedUpdate()
    {
        if(isRotation) {
            Rotation();
        } else if(isMoving) {
            Moving();
        }
    }

    void Rotation() {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }

    void Moving() {

    }

    void Pendulum() {
        Rigidbody2D obj = this.GetComponent<Rigidbody2D>();
        obj.angularVelocity = velocityThreshold;
    }
}
