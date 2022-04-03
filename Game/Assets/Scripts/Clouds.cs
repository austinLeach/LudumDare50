using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject cloud;
    public BoxCollider2D spawnBox;
    float[] verticalRanges = new float[4];
    Bounds spawnBounds;
    Vector3 spawnCenter;

    bool isSpawning = false;
    public float spawnRate = GlobalVariables.currentSpawnRate;


    // Start is called before the first frame update
    void Start()
    {
        spawnBox = spawnBox.GetComponent<BoxCollider2D>();
        spawnBounds = spawnBox.bounds;
        spawnCenter = spawnBounds.center;

        verticalRanges[0] = spawnCenter.x - spawnBounds.extents.x;
        verticalRanges[1] = spawnCenter.x + spawnBounds.extents.x;
        verticalRanges[2] = spawnCenter.y - spawnBounds.extents.y;
        verticalRanges[3] = spawnCenter.y + spawnBounds.extents.y;


    }

    // Update is called once per frame
    void Update()
    {
        createCloud();
        GlobalVariables.Timer(ref isSpawning, ref spawnRate);
    }
    public void createCloud()
    {
        if (isSpawning)
        {
            return;
        }

        float randomX;
        float randomY;

        randomX = Random.Range(verticalRanges[0], verticalRanges[1]);
        randomY = Random.Range(verticalRanges[2], verticalRanges[3]);

        Vector2 randomPos = new Vector2(randomX, randomY);
        Instantiate(cloud,randomPos, Quaternion.identity);
        isSpawning = true;
        spawnRate = Random.Range(1f, 4f);

    }

    


}

