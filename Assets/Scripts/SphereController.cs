using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float ballSpeed;
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
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Pickupable")
            return;

        bool hitMainCollider = false;

        foreach(ContactPoint contact in col.contacts)
        {
            hitMainCollider = true;
            break;
        }
        
        if (hitMainCollider)
        {
            //Destroy(col.gameObject.GetComponent<Collider>());
            //Destroy(col.gameObject.GetComponent<Rigidbody>());

            Vector3 minSize = col.gameObject.GetComponent<Collider>().bounds.min;
            Debug.Log(minSize);
            Vector3 maxSize = col.gameObject.GetComponent<Collider>().bounds.max;
            Debug.Log(maxSize);
            col.transform.parent = transform;
        }
    }
}
