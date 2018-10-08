using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controls : MonoBehaviour {
	public GameObject Camera;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (Camera.GetComponent<Game_Master>().Game_Active == true) {
				if (Input.mousePosition.x < Screen.width / 2f) {
					this.transform.position = new Vector3(-1, this.transform.position.y + 1, 0);
				}else {
					this.transform.position = new Vector3(1, this.transform.position.y + 1, 0);
				}
				Camera.transform.position = new Vector3(0, this.transform.position.y + 4.5f, -10);
				Camera.GetComponent<Game_Master>().Score++;
			}else {
				SceneManager.LoadScene("Game");
			}
		}
	}
	void OnCollisionEnter2D (Collision2D Collider) {
		Debug.Log("Colliding");
		if (Collider.collider.tag == "Spike") {
			Camera.GetComponent<Game_Master>().Game_Active = false;
		}
	}
}
