using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public GameObject deadPlayer;

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.layer == 8)
		{	
			Destroy(this.gameObject);
			GameObject go = (GameObject)GameObject.FindGameObjectWithTag("GameController");
			go.GetComponent<GameController>().restart();
		}
	}
}
