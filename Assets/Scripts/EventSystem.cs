using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public SpawnManager spawnManager;
   

    // Start is called before the first frame update
    void Start()
    {
    spawnManager.SpawnVehicles("enemy");
    spawnManager.SpawnVehicles("player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
