using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Generator : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefeb;
        [Range(0f,1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    } 

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach(SpawnableObject obj in objects)
        {
            if(spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefeb);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }



    // public GameObject obstacle;

    // public float minSpeed;
    // public float maxSpeed;
    // public float currentSpeed;

    // // Start is called before the first frame update
    // void Awake()
    // {
    //     currentSpeed = minSpeed;
    //     generateObstacle();
    // }

    // public void generateObstacle()
    // {
    //     GameObject ObstacleIn = Instantiate(obstacle, transform.position, transform.rotation);
    //     ObstacleIn.GetComponent<Obstacle>().obstacleGenerator = this;
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
