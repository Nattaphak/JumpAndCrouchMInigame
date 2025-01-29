using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;


    }


    // public Obstacle_Generator obstacleGenerator;

    // void Start()
    // {
        
    // }

    
    // void Update()
    // {
    //     transform.Translate(Vector2.left * obstacleGenerator.currentSpeed *  Time.deltaTime);

    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfScreen"))
        {
            Destroy(this.gameObject);
        }
    }
}
