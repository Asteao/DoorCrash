using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFoodController : MonoBehaviour
{

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ThrowFood(Transform trans, Vector3 velocity)
    {
        Vector3 topOfCar = new Vector3(trans.position.x, trans.position.y + 1, trans.position.z);
        GameObject ball = Instantiate(projectile, topOfCar, trans.rotation);
        ball.GetComponent<Rigidbody>().velocity = velocity;
        ball.GetComponent<Rigidbody>().AddRelativeForce(ball.transform.forward * 20, ForceMode.Impulse);
    }
}
