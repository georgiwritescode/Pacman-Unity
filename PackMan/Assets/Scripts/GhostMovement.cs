using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public Transform[] waypoints;
	int current=0;
	public float ghostSpeed = 0.3f;// slighty less than the speed of pacman=0.4

	void FixedUpdate(){
		//move closer towards target, if possible
		if (transform.position != waypoints [current].position) {
			//calculate a point , which is closer to the waypoint
			Vector2 p = Vector2.MoveTowards (transform.position,waypoints [current].position,ghostSpeed);

			rigidbody2D.MovePosition(p);
		}
		// when the waypoint is reached, select next position
		else current = (current + 1) % waypoints.Length;
		
		//Setting animations
		Vector2 direction = waypoints [current].position - transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", direction.x);
		GetComponent<Animator> ().SetFloat ("DirY", direction.y);
	}
		//When colliding with pacman, destroy
		void OnTriggerEnter2D(Collider2D co){
			if (co.name =="pacman") {
				Destroy(co.gameObject);
				Time.timeScale=0;
		}	
	}
}
