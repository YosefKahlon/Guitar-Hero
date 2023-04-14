using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawnerRandom : MonoBehaviour
{

    [SerializeField] Mover prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 3f;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [SerializeField] Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position; // set spawn position to position of TimeSpawnerRandom object

        this.StartCoroutine(SpawnRoutine());
        Debug.Log("Start finished");
    }


    private IEnumerator SpawnRoutine()
    {
        while (true)
        {   
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);

            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, spawnPosition, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);

        }
    }

}
