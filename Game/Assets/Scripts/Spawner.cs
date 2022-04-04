using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Duck Duck;
    public BoxCollider2D verticalBox;
    public BoxCollider2D horizontalBox;
    Bounds verticalBounds;
    Bounds horizontalBounds;
    Vector3 verticalCenter;
    Vector3 horizontalCenter;
    float[] verticalRanges = new float[4];
    float[] horizontalRanges = new float[4];
    int counter = 0;

    bool isSpawning = false;
    public float spawnRate = GlobalVariables.currentSpawnRate;
    public float staticSpawnRate = GlobalVariables.currentSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        verticalBox = verticalBox.GetComponent<BoxCollider2D>();
        horizontalBox = horizontalBox.GetComponent<BoxCollider2D>();
        verticalBounds = verticalBox.bounds;
        horizontalBounds = horizontalBox.bounds;
        verticalCenter = verticalBounds.center;
        horizontalCenter = horizontalBounds.center;

        verticalRanges[0] = verticalCenter.x - verticalBounds.extents.x;
        verticalRanges[1] = verticalCenter.x + verticalBounds.extents.x;
        verticalRanges[2] = verticalCenter.y - verticalBounds.extents.y;
        verticalRanges[3] = verticalCenter.y + verticalBounds.extents.y;

        horizontalRanges[0] = horizontalCenter.x - horizontalBounds.extents.x;
        horizontalRanges[1] = horizontalCenter.x + horizontalBounds.extents.x;
        horizontalRanges[2] = horizontalCenter.y - horizontalBounds.extents.y;
        horizontalRanges[3] = horizontalCenter.y + horizontalBounds.extents.y;  
    }

    // Update is called once per frame
    void Update()
    {
        staticSpawnRate = GlobalVariables.currentSpawnRate;
        Spawn();
        if (GlobalVariables.upgrades.Count > 4) {
            Spawn();
            isSpawning = false;
            Spawn();
            isSpawning = false;
            Spawn();
            isSpawning = false;
            Spawn();
            isSpawning = false;
            Spawn();
            isSpawning = false;
        }
        GlobalVariables.Timer(ref isSpawning, ref spawnRate);
    }

    public void Spawn() {
        if (isSpawning) {
            return;
        }
        int whichBox = Random.Range(0, 2);
        Debug.Log(whichBox);
        float randomX;
        float randomY;
        if (whichBox == 0) {
            randomX = Random.Range(verticalRanges[0], verticalRanges[1]);
            randomY = Random.Range(verticalRanges[2], verticalRanges[3]);
        } 
        else {
            randomX = Random.Range(horizontalRanges[0], horizontalRanges[1]);
            randomY = Random.Range(horizontalRanges[2], horizontalRanges[3]);
        }
        

        Vector2 randomPos = new Vector2(randomX, randomY);
        Instantiate(Duck, randomPos, Quaternion.identity);
        GlobalVariables.population++;
        isSpawning = true;
        spawnRate = GlobalVariables.currentSpawnRate;
    }
}
