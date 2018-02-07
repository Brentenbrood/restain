using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15f;
	public float airModifier = 5f;
	[HideInInspector]
	public bool grounded = true;
	private Vector3 moveDirection;
    private Vector3 moveRotation;

	void Start(){
        
    }

	void Update() {
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        //moveRotation = Vector3.RotateTowards(transform.forward, moveDirection, (10 * Time.deltaTime), 0.0F);
    }
	
	void OnCollisionEnter(Collision collision){
        grounded = true;
    }

	void FixedUpdate() {
        //transform.position = GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * (grounded ? moveSpeed : (moveSpeed / airModifier)) * Time.deltaTime;
        //transform.rotation = Quaternion.LookRotation(moveRotation);
        //transform.up = GetComponent<Rigidbody>().velocity;
        //transform.GetChild(0).forward = transform.GetChild(0).position + moveDirection;

        //transform.position = transform.position + moveDirection;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * (grounded ? moveSpeed : (moveSpeed / airModifier)) * Time.deltaTime);
        
    }
}
