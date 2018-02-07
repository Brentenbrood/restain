using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float ballSpeed;
    public float highestDistance;
    public GameObject triggerCollider;
    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
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
