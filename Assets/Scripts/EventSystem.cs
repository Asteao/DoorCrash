using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = Instantiate(playerCar) as GameObject;
        Player.name = "Player";
        Instantiate(playerCamera);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
