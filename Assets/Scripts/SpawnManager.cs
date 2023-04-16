using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject PlayerCar;
    public GameObject EnemyCar;

    [SerializeField] GameObject[] PlayerSpawnPoints;
    [SerializeField] GameObject[] EnemySpawnPoints;

    [SerializeField] GameObject[] foodSpawnLocations;
    public GameObject foodOrder;
    public GameObject newOrder;

    private void OnEnable()
    {
        handleOrder.OnAcceptOrder += SpawnOrderFood;
    }

    private void OnDisable()
    {
        handleOrder.OnAcceptOrder += SpawnOrderFood;
    }

    // Start is called before the first frame update
    void Start()
    {
        
            Instantiate(newOrder, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnVehicles(string characterType) {
        
        if (characterType == "player") {
          
            int randomPlayerPoint = Random.Range(0, PlayerSpawnPoints.Length);
            GameObject ActivePlayer = Instantiate(PlayerCar, PlayerSpawnPoints[randomPlayerPoint].transform.position, Quaternion.identity);
            ActivePlayer.name =  "Player";

            return ActivePlayer;
        }

        else  {
          
            int randomEnemyPoint = Random.Range(0, EnemySpawnPoints.Length);
            GameObject EnemyPlayer = Instantiate(EnemyCar, EnemySpawnPoints[randomEnemyPoint].transform.position, Quaternion.identity);
            EnemyPlayer.name =  "enemy";

            return EnemyPlayer;
        }
    }

    public void SpawnOrderFood()
    {
        int randomFoodLocation = Random.Range(0, foodSpawnLocations.Length);
        Instantiate(foodOrder, foodSpawnLocations[randomFoodLocation].transform.position, foodOrder.transform.rotation);
    }
}
