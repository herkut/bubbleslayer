using UnityEngine;
using System.Collections;

public class BounceEffect : MonoBehaviour {

	Rigidbody rb;
	public float coefficient;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Wall")
		{

			rb.GetComponent<BubbleMovement>().velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0.0f);
		}
	}
}
