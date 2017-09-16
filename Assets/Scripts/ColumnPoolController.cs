using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPoolController : MonoBehaviour {

    public int ColumnPoolSize = 5;

    public GameObject ColumnPrefab;
    private Vector2 ObjectPoolPosition = new Vector2(-15f, -25f);

    private GameObject[] Columns;

    public float SpawnRate = 4f;
    private float TimeSinceLastSpawned;

    public float ColumnMin = -1f;
    public float ColumnMax = 3.5f;

    private float SpawnXPos = 15f;

    private int CurrentCol = 0;

    // Use this for initialization
    void Start()
    {
        Columns = new GameObject[ColumnPoolSize];
        for (int i = 0; i < ColumnPoolSize; i++)
        {
            Columns[i] = (GameObject)Instantiate(ColumnPrefab, ObjectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeSinceLastSpawned += Time.deltaTime;

        if(!GameController.Instance.GameOver && TimeSinceLastSpawned >= SpawnRate)
        {
            TimeSinceLastSpawned = 0;

            float spawnYPos = Random.Range(ColumnMin, ColumnMax);

            Columns[CurrentCol].transform.position = new Vector2(SpawnXPos, spawnYPos);
            CurrentCol ++;

            if (CurrentCol >= ColumnPoolSize) { CurrentCol = 0; }

        }
	}
}
