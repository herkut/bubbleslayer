using UnityEngine;
using System.Collections;

public class DestroyEscapingGameObject : MonoBehaviour 
{

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}

}
