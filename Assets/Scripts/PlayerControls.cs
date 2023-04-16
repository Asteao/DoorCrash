using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : CarControls {
    private void Awake() {
    }

    public void Update() {
        this.SetInputs(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}