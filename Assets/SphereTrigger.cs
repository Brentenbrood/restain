using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour {

    public float highestDistance;
	// Use this for initialization
	void Start () {
        highestDistance = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
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
        

        float centerDiff = (col.transform.position - transform.position).magnitude;
        if (centerDiff > highestDistance)
        {
            highestDistance = centerDiff;
        }
        Debug.Log(centerDiff);

        Vector3 dir = col.transform.position - transform.position;
        dir.Normalize();
        float dis = Vector3.Distance(col.transform.position, transform.position);
        col.transform.Translate(dir * (highestDistance-dis));
        Debug.Log(dir);
        //col.transform.position =  highestDistance - transform.GetComponent<SphereCollider>().radius;
        if (transform.GetComponent<SphereCollider>().radius < highestDistance)
            transform.GetComponent<SphereCollider>().radius = highestDistance;

        col.transform.parent = transform;
        


        Destroy(col.gameObject.GetComponent<Collider>());
        Destroy(col.gameObject.GetComponent<Rigidbody>());
    }
}
