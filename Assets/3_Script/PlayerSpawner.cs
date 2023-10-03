using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] PlayerPrefabs;
    public Transform spawnPos;

    public GameObject SpawnPlayer(int index)
    {

        var newPlayer = Instantiate(PlayerPrefabs[index], spawnPos.position + new Vector3(-26, 0, 0),
                         Quaternion.identity, transform);

        return newPlayer;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

    }



}
