using UnityEngine;
using System.Collections;

public class packdot : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") 
			Destroy (gameObject);
	}
}
