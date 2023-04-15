using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    
    public int playerHealth;
    public Camera myCamera;
    private Vector3 cubePosition;

    [SerializeField]
    private int enemyHealth;

    // Start is called before the first frame update
    void Start()

    {
            cubePosition = this.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        myCamera.transform.position = cubePosition;
    }
}
