using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();		
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			MoveAutomatically();
		} else {
			MoveWithMouse();
		}
	}

	void MoveAutomatically() {		
		float ballPos = ball.transform.position.x;
		Vector3 paddlePos = new Vector3(Mathf.Clamp(ballPos, 0.5f, 15.5f), this.transform.position.y);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse() {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;		
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y);
		this.transform.position = paddlePos;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (ball.LaunchedBall) {
			if(collision.gameObject.name == "Ball") {
				foreach(ContactPoint2D contact in collision.contacts) 
				{
					print("Paddle says: " + contact.point.ToString());
				}
			}
		}
	}

//	void OnCollisionExit2D(Collision2D collision) {
//		collision.collider.
//
//		foreach(ContactPoint2D ballHit in collision.contacts)
//		{
//			Vector2 hitPoint = ballHit.point;
//			print(hitPoint);
//
//			Instantiate(explosion,new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
//		}
//		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
//	}
}
