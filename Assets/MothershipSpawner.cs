using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipSpawner : MonoBehaviour
{
    public float minShowTime = 10f;
    public float maxShowTime = 20f;

    public GameObject mothershipPrefab;
    public List<Transform> mothershipSpawnLocations = new(); // create a list of transforms that can be used for mothership spawning

    private float showTimePassed = 0f;
    private float timeBetweenShow;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShow = Random.Range(minShowTime, maxShowTime); // could put this into it's own function since we call it twice
    }

    // Update is called once per frame
    void Update()
    {
        // add time since last frame to counter
        showTimePassed += Time.deltaTime;

        // if counter is longer than interval, spawn ship
        if (showTimePassed >= timeBetweenShow)
        {
            // spawn mothership
            SpawnMothership();
            // reset time that has passed
            showTimePassed = 0f;
            // set new random spawning interval
            timeBetweenShow = Random.Range(minShowTime, maxShowTime); 
        }
    }

    private void SpawnMothership()
    {
        // spawn mothership, choosing a spawn position randomly
        int spawnIndex = Random.Range(0, mothershipSpawnLocations.Count); // choose random number between zero and length of spawn position list, zero indexed
        Vector3 spawnLocation = mothershipSpawnLocations[spawnIndex].position; // get the position from the list of transforms, index we chose

        Instantiate(mothershipPrefab, spawnLocation, Quaternion.identity); // instantiate at the position chosen with zero rotation (will rotate sprite in prefab instead)
    }
}
