using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DeployEnemy : MonoBehaviour
{
    // retrieves the enemy objects to copy
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    private GameObject enemyClone;

    // retrieves the game difficulty
    [SerializeField] Difficulty difText;

    // sets the respawn time and the list index of which spawn point
    [SerializeField] float respawnTime = 1f;
    [SerializeField] int spawnIndex;
    
    // references to the 10 spawn points
    [SerializeField] Transform spawn0; // left top
    [SerializeField] Transform spawn1; // left middle
    [SerializeField] Transform spawn2; // left bottom
    [SerializeField] Transform spawn3; // bottom left
    [SerializeField] Transform spawn4; // bottom right
    [SerializeField] Transform spawn5; // right bottom
    [SerializeField] Transform spawn6; // right middle
    [SerializeField] Transform spawn7; // right top
    [SerializeField] Transform spawn8; // top right
    [SerializeField] Transform spawn9; // top left

    private List<Transform> spawnArray;

    void Start()
    {
        // creates a list of the spawn points
        spawnArray = new List<Transform>(){
            spawn0,
            spawn1,
            spawn2,
            spawn3,
            spawn4,
            spawn5,
            spawn6,
            spawn7,
            spawn8,
            spawn9
        };

        // starts the flow of enemies toward the player
        StartCoroutine(EnemySpawner());
    }

    private void SpawnEnemy(GameObject clone)
    {
        Debug.Log(clone);
        // creates a new instance of the monster
        GameObject x = Instantiate(clone) as GameObject;
        // GameObject x = PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromSource(enemy2Prefab)) as GameObject;

        // sets position to the spawn point at the current index of the list

        x.transform.position = new Vector2(spawnArray[spawnIndex].position.x, spawnArray[spawnIndex].position.y);

        // changes the new spawn point to a random one
        spawnIndex = Random.Range(0,9);
    }

    IEnumerator EnemySpawner()
    {
        // runs indefinitely
        while (true)
        {
            if (difText.difficulty == 1)
            {
                enemyClone = enemy1;
            }
            else if (difText.difficulty == 2)
            {
                enemyClone = enemy2;
            }
            else if (difText.difficulty == 3)
            {
                enemyClone = enemy3;
            };

            // waits before spawning a new enemy
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy(enemyClone);
        }
    }

}
