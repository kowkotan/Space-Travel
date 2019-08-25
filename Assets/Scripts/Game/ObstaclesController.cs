using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{

    public GameObject playerObj;
    public GameObject[] Obstacles;
    public Obstacle obs;

    int playerDistanceIndex = -1;
    int obstacleCount;
    int obstacleIndex = 0;
    int distanceToNext = 20;

    void Start()
    {
        obstacleCount = Obstacles.Length;
        InstaniateObstacle();
    }

    private void Update() {
        int PlayerDistance = (int)(playerObj.transform.position.y / (distanceToNext));

        if(playerDistanceIndex != PlayerDistance) {
            InstaniateObstacle();
            playerDistanceIndex = PlayerDistance;
        }
    }

    void InstaniateObstacle() {
        int RandomObstacle = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(Obstacles[RandomObstacle], new Vector3(0, obstacleIndex * distanceToNext), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
    }
}
