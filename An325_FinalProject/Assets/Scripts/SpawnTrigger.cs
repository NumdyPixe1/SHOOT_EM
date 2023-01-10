using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    void Start()
    {

    }

    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

}
