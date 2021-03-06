﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float damage = 100f;
	LevelManager levelManager;
	ScoreKeeper scoreKeeper;
	public AudioClip enemyDeathSound;

	// Use this for initialization
	void Start () {		
		this.levelManager = GameObject.FindObjectOfType<LevelManager>();
		this.scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider) {		
		if (collider.transform.name == "ProjectileDestroyer") {			
			Destroy(this.gameObject);

		} else if (collider.transform.tag == "Enemy" && this.transform.tag == "PlayerProjectile") {
			Enemy enemy = collider.gameObject.GetComponent<Enemy>();
			if (enemy.Health <= this.damage) {				
				this.scoreKeeper.ChangeScore(enemy.ValuePoints);
				AudioSource.PlayClipAtPoint(enemyDeathSound, collider.gameObject.transform.position);
				Destroy(collider.gameObject);
			} else {
				enemy.Health -= this.damage;
			}
			Destroy(this.gameObject);

		} else if (collider.transform.tag == "Player" && this.transform.tag == "EnemyProjectile") {
			PlayerController player = collider.gameObject.GetComponent<PlayerController>();
			if (player.Health <= this.damage) {
				Destroy(collider.gameObject);
				this.levelManager.PlayerKilled();
			} else {
				player.Health -= this.damage;
			}
			Destroy(this.gameObject);
		}
	}
}
