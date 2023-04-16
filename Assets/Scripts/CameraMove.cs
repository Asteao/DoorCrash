using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
//    public GameObject player;
    public Camera myCamera;

    public Transform target;
    public float smoothSpeed = 0.3f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    // Start is called before the first frame update
    void Start()
    {
         locationOffset = new Vector3(0, 1.5f, -4);
         target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredRotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        transform.rotation = smoothedRotation;
    }

}