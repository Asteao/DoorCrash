using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject PlayerCar;
    public GameObject PlayerSpawnPoint;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnVehicles(string characterType) {
        
        if (characterType == "player") {
          
            GameObject ActivePlayer = Instantiate(PlayerCar, PlayerSpawnPoint.transform.position, Quaternion.identity);
            ActivePlayer.name =  "Player";

            return ActivePlayer;
        }

        else  {
          
            GameObject EnemyPlayer = Instantiate(PlayerCar, PlayerSpawnPoint.transform.position, Quaternion.identity);
            EnemyPlayer.name =  "enemy";

            return EnemyPlayer;
        }
        }
    }
