using UnityEngine;
using System.Collections;
public class CarControls : MonoBehaviour
{
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;

    // public Transform WheelFLtrans;
    // public Transform WheelFRtrans;
    // public Transform WheelRLtrans;
    // public Transform WheelRRtrans;

    // public Vector3 eulertest;
    // [SerializeField]
    // float maxFwdSpeed = -8000;
    // [SerializeField]
    // float maxBwdSpeed = 5000f;
    // float gravity = 9.8f;
    // private bool braked = false;
    // [SerializeField]
    // private float maxBrakeTorque = 5000;
    private Rigidbody rb;
    public Transform centreofmass;
    // [SerializeField]
    // //        private float speedMax = 3000;

    #region Fields
    private float speed;
    private float speedMax = 3000f;
    private float speedMin = -2000f;
    private float acceleration = 5000f;
    private float brakeSpeed = 10000f;
    private float reverseSpeed = 3000f;
    private float idleSlowdown = 100f;

    private float turnSpeed;
    private float minturnAmount = 15f;
    private float turnSpeedMax = 45f;
    private float turnSpeedAcceleration = 30f;
    private float turnIdleSlowdown = 200f;

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
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     tfc.ThrowFood(transform, rb.velocity);
        // }

        CalculateMotorTorque();
        WheelRR.motorTorque = speed;
        WheelRL.motorTorque = speed;
        Debug.Log("Speed " + speed);

        if(motorTorque > 0)

        //changing car direction
        //Here we are changing the steer angle of the front tyres of the car so that we can change the car direction.
        CalculateTurnSpeed();
        WheelFL.steerAngle = turnSpeed;
        WheelFR.steerAngle = turnSpeed;
        // Debug.Log("Turn speed " + turnSpeed);

    }
    protected void Update()
    {
    
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     tfc.ThrowFood(transform, rb.velocity);
        // }

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

    private void CalculateMotorTorque() {
        if (forwardAmount > 0) {
            // Accelerating
            speed += forwardAmount * acceleration * Time.deltaTime;
        }
        if (forwardAmount < 0) {
            if (speed > 0) {
                // Braking
                speed += forwardAmount * brakeSpeed * Time.deltaTime;
            } else {
                // Reversing
                speed += forwardAmount * reverseSpeed * Time.deltaTime;
            }
        }

        if (forwardAmount == 0) {
            // Not accelerating or braking
            if (speed > 0) {
                speed -= idleSlowdown * Time.deltaTime;
            }
            if (speed < 0) {
                speed += idleSlowdown * Time.deltaTime;
            }
        }

        speed = Mathf.Clamp(speed, speedMin, speedMax);

        // carRigidbody.velocity = transform.forward * speed;

        if (speed < 0) {
            // Going backwards, invert wheels
            turnAmount = turnAmount * -1f;
        }
    }

    private void CalculateTurnSpeed() {
        if (turnAmount > 0 || turnAmount < 0) {
            // Turning
            if ((turnSpeed > 0 && turnAmount < 0) || (turnSpeed < 0 && turnAmount > 0)) {
                // Changing turn direction
                
                turnSpeed = turnAmount * minturnAmount;
            }
            turnSpeed += turnAmount * turnSpeedAcceleration * Time.deltaTime;
        } else {
            // Not turning
            if (turnSpeed > 0) {
                turnSpeed = Mathf.Max(0, turnSpeed - turnIdleSlowdown * Time.deltaTime);
            }
            if (turnSpeed < 0) {
                turnSpeed = Mathf.Min(0, turnSpeed + turnIdleSlowdown * Time.deltaTime);
            }
            if (turnSpeed > -1f && turnSpeed < +1f) {
                // Stop rotating
                turnSpeed = 0f;
            }
        }
        turnSpeed = Mathf.Max(-turnSpeedMax, Mathf.Min(turnSpeedMax, turnSpeed));
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