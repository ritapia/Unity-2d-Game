using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public GameObject playerPrefab;

    private void Start()
    {
        SpawnItems();
    }
    // Update is called once per frame
    void Update () {
        if (GameObject.FindWithTag("Game Over") == null)
            SpawnItems();
    }
    
    void SpawnItems()
    {
        if(playerPrefab.tag == "Player")
        {
            int nPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

            if(nPlayers < 1)
            {
                Instantiate(playerPrefab, transform.position, transform.rotation);
            }
        }
    }
}
