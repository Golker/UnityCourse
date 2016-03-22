using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	bool launchedBall = false;

	bool launchedOnce = false;

	public bool LaunchedBall {
		get {
			return launchedBall;
		}
	}

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!launchedBall) {

			if(!launchedOnce)
			{
				Vector3 paddlePos = paddle.transform.position;
				this.transform.position = new Vector3(paddlePos.x, this.transform.position.y);			
				launchedOnce = true;
			}

			if(Input.GetMouseButtonUp(0)) {
				launchedBall = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
 		if (launchedBall) {
			GetComponent<AudioSource>().Play();

			if(collision.gameObject.name == "Paddle") {
				this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				launchedBall = false;
				foreach(ContactPoint2D contact in collision.contacts) 
				{
					print("Ball says: " + contact.point.ToString());
				}
			}
		}
	}
}
