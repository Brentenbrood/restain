using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float ballSpeed;
    public float highestDistance;
    public GameObject triggerCollider;
    private Rigidbody rb;

    public bool enableTilt;
    void OnGUI()
    {
        if (Input.gyro.enabled)
            GUILayout.Toggle(enableTilt, "Enable tilt control");

        
    }
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(SystemInfo.supportsGyroscope);
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            rb.AddForce(Vector3.forward * ballSpeed);

        if (Input.GetKey("a"))
            rb.AddForce(Vector3.left * ballSpeed);

        if (Input.GetKey("s"))
            rb.AddForce(Vector3.back * ballSpeed);

        if (Input.GetKey("d"))
            rb.AddForce(Vector3.right * ballSpeed);

        Input.gyro.enabled = false;
        float initialOrientationX = Input.gyro.rotationRateUnbiased.x;
        float initialOrientationY = Input.gyro.rotationRateUnbiased.y;
        rb.AddForce (initialOrientationY * ballSpeed * 2.0f, 0.0f , -initialOrientationX * ballSpeed * 2.0f);
        Debug.Log(initialOrientationX + ", " + initialOrientationY);

        transform.GetComponent<SphereCollider>().radius = triggerCollider.GetComponent<SphereTrigger>().highestDistance;
    }

    void OnCollisionEnter(Collision col)
    {
        //Destroy(col.gameObject.GetComponent<Collider>());
        /*
                    float centerDiff = (col.transform.position - transform.position).magnitude;
                    if(centerDiff > highestDistance)
                    {
                        highestDistance = centerDiff;
                    }
                    Debug.Log(centerDiff);
                    transform.GetComponent<SphereCollider>().radius = highestDistance;*/
    }

}
