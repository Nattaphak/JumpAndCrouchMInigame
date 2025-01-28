using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Generator : MonoBehaviour
{
    public GameObject obstacle;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = minSpeed;
        generateObstacle();
    }

    public void generateObstacle()
    {
        GameObject ObstacleIn = Instantiate(obstacle, transform.position, transform.rotation);
        ObstacleIn.GetComponent<Obstacle>().obstacleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
