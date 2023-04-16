using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleOrder : MonoBehaviour
{
    public static event Action OnAcceptOrder;
    
    public GameObject smallOrder;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
       canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(smallOrder, canvas.transform);
            Destroy(this.gameObject);
            OnAcceptOrder?.Invoke();
        }

         if (Input.GetKeyDown(KeyCode.N))
        {
            Destroy(this.gameObject);
        }
    }
}
