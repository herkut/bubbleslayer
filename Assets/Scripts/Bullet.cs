using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Vector3.up*speed, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 8)
		{
			Destroy(this.gameObject);
			other.GetComponent<Detonation>().detonate();
		}

	}
}
