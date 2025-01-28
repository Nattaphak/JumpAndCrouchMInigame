using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Obstacle_Generator obstacleGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * obstacleGenerator.currentSpeed *  Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObstacleCheckpoint"))
        {
            obstacleGenerator.generateObstacle();
        }

        if (collision.gameObject.CompareTag("OutOfScreen"))
        {
            Destroy(this.gameObject);
        }
    }
}
