using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 3.5f;
	public float jumpingForce = 100f;
	public float rotatingSpeed = 40f;

	private bool canJump = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame 
	void Update () {
		if ( Input.GetKey ("right"))	{
			transform.RotateAround (transform.position, Vector3.up, rotatingSpeed * Time.deltaTime); 
		}	/*(Time.deltaTime)	= use for real time update so player with difference processor 
					can feel the same UX*/

		if ( Input.GetKey ("left"))	{
			transform.RotateAround (transform.position, Vector3.up, -rotatingSpeed * Time.deltaTime); 
		}

		if ( Input.GetKey ("up"))	{
			transform.position += transform.forward * speed * Time.deltaTime; 
		}

		if ( Input.GetKeyDown ("space") && canJump)	{
			canJump = false; 
			GetComponent<Rigidbody> ().AddForce (0, jumpingForce, 0);
		}
	}

	void OnCollisionEnter (Collision collision)	{
		if (collision.transform.name == "Floor")
		{
			canJump = true;
		}
	}

}
