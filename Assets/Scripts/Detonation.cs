using UnityEngine;
using System.Collections;

public class Detonation : MonoBehaviour {

	public GameObject bubble4x;
	public GameObject bubble2x;
	public GameObject bubble1x;

	public Rigidbody rb;
	GameObject gameController;

	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}

	public void detonate()
	{
		GameObject temp;
		Vector3 parentPosition = rb.position;
		Vector3 parentVelocity = rb.velocity;
		if(rb.mass == 4)
		{
			Destroy(this.gameObject);

			temp = (GameObject)Instantiate(bubble2x, parentPosition, Quaternion.identity);
			temp.GetComponent<BubbleMovement>().velocity = parentVelocity;
			
			temp = (GameObject)Instantiate(bubble2x, parentPosition, Quaternion.identity);
			Vector3 newVelocity = new Vector3(-parentVelocity.x,parentVelocity.y,0.0f);
			temp.GetComponent<BubbleMovement>().velocity = newVelocity;

			gameController.GetComponent<GameController>().updateScore(4);
		}
		else if(rb.mass == 2)
		{
			Destroy(this.gameObject);
			
			temp = (GameObject)Instantiate(bubble1x, parentPosition, Quaternion.identity);
			temp.GetComponent<BubbleMovement>().velocity = parentVelocity;
			
			temp = (GameObject)Instantiate(bubble1x, parentPosition, Quaternion.identity);
			Vector3 newVelocity = new Vector3(-parentVelocity.x,parentVelocity.y,0.0f);
			temp.GetComponent<BubbleMovement>().velocity = newVelocity;

			gameController.GetComponent<GameController>().updateScore(4);
		}
		else if(rb.mass == 1)
		{
			Destroy (this.gameObject);
			gameController.GetComponent<GameController>().updateScore(4);
		}
	}
}
