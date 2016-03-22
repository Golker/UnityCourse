using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int BreakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;

	private int timesHit, maxHits;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
		Brick.BreakableCount++;
	}

	// Update is called once per frame
	void Update () {		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		this.timesHit++;
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (this.tag == "Breakable") {
			if (this.timesHit >= this.maxHits) {
				AudioSource.PlayClipAtPoint(crack, this.transform.position);
				Brick.BreakableCount--;
				PaintSmoke();
				levelManager.BrickDestroyed();
				Destroy(gameObject);
			} else {
				this.GetComponent<SpriteRenderer>().sprite = hitSprites[this.timesHit - 1];
			}
		}
	}

	void PaintSmoke() {
		// Paint the smoke the same color as the originating brick
		GameObject smokeObject = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		Color brickColor = this.GetComponent<SpriteRenderer>().color;
		smokeObject.GetComponent<ParticleSystem>().startColor = brickColor;
	}
}
