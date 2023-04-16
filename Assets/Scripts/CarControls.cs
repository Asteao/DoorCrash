using UnityEngine;
using System.Collections;
public class CarControls : MonoBehaviour
{
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;

    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;

    public Vector3 eulertest;
    [SerializeField]
    float maxFwdSpeed = -8000;
    [SerializeField]
    float maxBwdSpeed = 5000f;
    float gravity = 9.8f;
    private bool braked = false;
    [SerializeField]
    private float maxBrakeTorque = 5000;
    private Rigidbody rb;
    public Transform centreofmass;
    [SerializeField]
    //        private float speedMax = 3000;

    #region Fields
    private float speed;
    private float speedMax = 3000f;
    private float speedMin = -2000f;
    private float acceleration = 30f;
    private float brakeSpeed = 100f;
    private float reverseSpeed = 30f;
    private float idleSlowdown = 10f;

    private float turnSpeed;
    private float turnSpeedMax = 300f;
    private float turnSpeedAcceleration = 300f;
    private float turnIdleSlowdown = 500f;

    private float forwardAmount;
    private float turnAmount;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        if (!braked)
        {
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
        }
        //speed of car, Car will move as you will provide the input to it.

        WheelRR.motorTorque = speedMax * forwardAmount;
        WheelRL.motorTorque = speedMax * forwardAmount;

        //changing car direction
        //Here we are changing the steer angle of the front tyres of the car so that we can change the car direction.
        WheelFL.steerAngle = 30 * turnAmount;
        WheelFR.steerAngle = 30 * turnAmount;
    }
    protected void Update()
    {
        //for tyre rotate
        // WheelFLtrans.Rotate(WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        // WheelFRtrans.Rotate(WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        // WheelRLtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        // WheelRRtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        // //changing tyre direction
        // Vector3 temp = WheelFLtrans.localEulerAngles;
        // Vector3 temp1 = WheelFRtrans.localEulerAngles;
        // temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z);
        // WheelFLtrans.localEulerAngles = temp;
        // temp1.y = WheelFR.steerAngle - WheelFRtrans.localEulerAngles.z;
        // WheelFRtrans.localEulerAngles = temp1;
        // eulertest = WheelFLtrans.localEulerAngles;
    }

    public void SetInputs(float forwardAmount, float turnAmount)
    {
        this.forwardAmount = forwardAmount;
        this.turnAmount = turnAmount;
    }

    //        public void ClearTurnSpeed() {
    //            turnSpeed = 0f;
    //        }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeedMax(float speedMax)
    {
        this.speedMax = speedMax;
    }

    //        public void SetTurnSpeedAcceleration(float turnSpeedAcceleration) {
    //            this.turnSpeedAcceleration = turnSpeedAcceleration;
    //        }

    public void StopCompletely()
    {
        speed = 0f;
        turnSpeed = 0f;
    }
}