using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private GameObject playerObj;
    public int distToNext;

    private void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyObstacle());
    }

    IEnumerator DestroyObstacle() {
        while(true) {
            if(playerObj.transform.position.y - transform.position.y > 20) {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
