using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 5;
    private float timeSinceLastSpawned;
    private float spawnRate = 4f;
    private float columnMin = -1f;
    private float columnMax = 3.5f;
    private int currentColumn;
    private float spawnXPosition = 10f;

    public GameObject       columnPrefab;
    private GameObject[]    columns;
    // Instantiate offscreen.
    private Vector2         objectPoolPosition =  new Vector2(-15f, -25f);


    // Use this for initialization
    void Start ()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab,
                objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set a timer.
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            // Generate a random position along the y axis.
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

    }
}

