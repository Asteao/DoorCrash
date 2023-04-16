using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : CarControls {

    public ThrowFoodController tfc;

    private void Awake() {
    }

    public void Update() {
        this.SetInputs(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Fire1"))
        {
            tfc.ThrowFood(base.transform, base.GetComponent<Rigidbody>().velocity);
        }
    }
}