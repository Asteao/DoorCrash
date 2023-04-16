using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSign : MonoBehaviour
{
    private Vector3 rotationDirection;
    private float smoothTime = 1;
    private float convertedTime = 200;
    private float smooth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        smooth = Time.deltaTime * smoothTime * convertedTime;
        GetComponent<Rigidbody>().Rotate(rotationDirection * smooth);
    }
}
