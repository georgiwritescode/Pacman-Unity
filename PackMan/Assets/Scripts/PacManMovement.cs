using UnityEngine;
using System.Collections;

public class PacManMovement : MonoBehaviour {
	public float speed = 0.4f;

	Vector2 destPoint = Vector2.zero;

	void Start () {
		destPoint = transform.position;
	}
	void FixedUpdate(){
		//moving toward the destination
		Vector2 p = Vector2.MoveTowards (transform.position, destPoint, speed);
		rigidbody2D.MovePosition(p);

		//input from keyboard
		//uses the arrow keys
		if (Input.GetKey (KeyCode.UpArrow) && valid (Vector2.up))
			destPoint = (Vector2)transform.position + Vector2.up;
		if (Input.GetKey (KeyCode.RightArrow) && valid (Vector2.right))
			destPoint = (Vector2)transform.position + Vector2.right;
		if (Input.GetKey (KeyCode.DownArrow) && valid (-Vector2.up))
			destPoint = (Vector2)transform.position - Vector2.up;
		if (Input.GetKey (KeyCode.LeftArrow) && valid (-Vector2.right))
			destPoint = (Vector2)transform.position - Vector2.right;


		//Set the animation rotation when moving the packman
		Vector2 dir = destPoint - (Vector2)transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);

	}

	bool valid (Vector2 dir){
		//checks whether there's an object or empty space, so the packman could move towards the given direction
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast (pos + dir, pos);
		return(hit.collider == collider2D);
	}



}
