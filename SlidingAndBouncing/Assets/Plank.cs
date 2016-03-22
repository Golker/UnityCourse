using UnityEngine;
using System.Collections;

public class Plank : MonoBehaviour {

	int angle = 0;
	bool right = true;
	Vector3 originalPosition;
	// Use this for initialization
	void Start () {
		originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2(originalPosition.x + Mathf.Sin(Time.time) * 3f, this.transform.position.y);
	}
}
