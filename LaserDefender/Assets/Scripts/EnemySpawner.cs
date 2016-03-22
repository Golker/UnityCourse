using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 17f;
	public float height = 8f;

	bool movingRight = true;
	float speed = 5f;
	float xmax, xmin;
	float spawnDelay = 0.05f;

	// Use this for initialization
	void Start () {
		float distanceToCamera = this.transform.position.z - Camera.main.transform.position.z;

		Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

		xmax = rightEdge.x;
		xmin = leftEdge.x;

		SpawnUntilFull();
		spawnDelay = 0.5f;
	}

	void SpawnEnemies() {
		foreach (Transform child in this.transform) {
			foreach (Transform positionObject in child) {
				GameObject enemy = Instantiate(enemyPrefab, positionObject.position, Quaternion.identity) as GameObject;
				enemy.transform.parent = positionObject;
			}
		}
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition();

		if (freePosition != null) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}

		if (NextFreePosition()) {
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);

		if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		} else if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		}

		float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);

		if (AllEnemiesDead()) {
			SpawnUntilFull();
		}
	}

	Transform NextFreePosition() {
		foreach (Transform child in this.transform) {
			foreach (Transform positionObject in child) {
				if (positionObject.childCount == 0) {
					return positionObject;
				}
			}
		}
		return null;
	}

	bool AllEnemiesDead() {
		foreach (Transform child in this.transform) {
			foreach (Transform positionObject in child) {
				if (positionObject.childCount > 0) {
					return false;
				}
			}
		}
		return true;
	}
}
