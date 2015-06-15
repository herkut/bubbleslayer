using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Animator anim;
	public float speed;
	public GameObject bullet;

	int fireHash = Animator.StringToHash("shot");

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement ;
		float moveHorizontal;

		#if UNITY_WEBPLAYER
		moveHorizontal = Input.GetAxis("Horizontal");
		walkAnimation (moveHorizontal);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			shot();
		}
		movement = new Vector3(moveHorizontal * speed / 20, 0.0f, 0.0f);
		#endif
		#if UNITY_STANDALONE
		moveHorizontal = Input.GetAxis("Horizontal");
		walkAnimation (moveHorizontal);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			shot ();

		}
		movement = new Vector3(moveHorizontal * speed / 20, 0.0f, 0.0f);
		#endif
		#if UNITY_IOS
		moveHorizontal = Input.acceleration.x;
		walkAnimation (moveHorizontal);
		if(Input.touchCount > 0)
		{
			shot():
		}
		movement = new Vector3(moveHorizontal * speed / 5, 0.0f, 0.0f);
		#endif
		#if UNITY_ANDROID
		moveHorizontal = Input.acceleration.x;
		walkAnimation (moveHorizontal);
		if(Input.touchCount > 0)
		{
			shot();
		}
		movement = new Vector3(moveHorizontal * speed / 5, 0.0f, 0.0f);
		#endif
		
		transform.Translate(movement);
	}

	void shot ()
	{
		anim.SetTrigger (fireHash);
		Instantiate (bullet, transform.localPosition, Quaternion.identity);
	}
	
	void walkAnimation (float moveHorizontal)
	{
		if (moveHorizontal > 0) {
			anim.SetFloat ("direction", 1f);
		}
		else if (moveHorizontal < 0) {
			anim.SetFloat ("direction", 0f);
		}
		else {
			anim.SetFloat ("direction", 0.5f);
		}
	}
}
