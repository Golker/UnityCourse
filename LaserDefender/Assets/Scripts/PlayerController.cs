using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1f;
	public float firingRate = 0.35f;

	public AudioClip laserSound;
	public GameObject projectile;


	float xmin, xmax;
	float health = 250f;

	public float Health {
		get {
			return health;
		}
		set {
			health = value;
		}
	}

	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;

		this.GetComponent<Rigidbody2D>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {						
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {						
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);

		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.0000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	}

	void Fire() {
		GameObject shotFired = Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y + 1f), Quaternion.identity) as GameObject;
		shotFired.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
		AudioSource.PlayClipAtPoint(laserSound, this.transform.position);
	}
}
