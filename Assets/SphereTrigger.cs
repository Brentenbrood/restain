using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{

    public float highestDistance;

    private SphereCollider sphereCollider;

    // Use this for initialization
    void Start()
    {
        highestDistance = 0.5f;
        sphereCollider = GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Pickupable")
            return;

        //col.transform.Translate(col.transform.position - transform.position);
        /*
        Vector3 fwd = transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(col.transform.position, transform.GetChild(0).position, out hit))
        {
            Debug.Log(hit.point);
            col.transform.position = hit.point;
            
        }
        // */

        col.transform.SetParent(transform, true);


        float centerDiff = (col.transform.position - transform.position).magnitude;
        if (centerDiff > highestDistance)
        {
            highestDistance = centerDiff;
        }

        Vector3 dir = col.transform.position - transform.position;
        Debug.DrawLine(transform.position, transform.position + dir, Color.gray, 117.5f);
        Debug.DrawLine(transform.position + dir, transform.position + dir + Vector3.up * 0.1f, Color.black, 117.5f); //Show an "arrow" tip
        dir.Normalize();
        //dir = transform.TransformDirection(dir);
        dir *= sphereCollider.radius;
        Debug.DrawLine(transform.position, transform.position + dir, Color.red, 117.5f);
        Debug.DrawLine(transform.position + dir, transform.position + dir + Vector3.up * 0.1f, Color.magenta, 117.5f); //Show an "arrow" tip
        col.transform.position = transform.position + dir;

        if (sphereCollider.radius < highestDistance)
            sphereCollider.radius = highestDistance;

        Destroy(col.gameObject.GetComponent<Collider>());
        Destroy(col.gameObject.GetComponent<Rigidbody>());
    }
}
