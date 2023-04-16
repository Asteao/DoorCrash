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
        Instantiate(playerCar);
        Instantiate(playerCamera);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
