using UnityEngine;
using System.Collections;

public class BubbleMovement : MonoBehaviour {

	public Vector3 velocity;
	Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = this.GetComponent<Rigidbody>();
	}

	void FixedUpdate () 
	{
		Vector3 v = new Vector3(velocity.x, rb.velocity.y, 0.0f);
		this.GetComponent<Rigidbody>().velocity = v;
	}

	public void setForce(Vector3 velocity)
	{
		this.velocity = velocity;
	}
}
