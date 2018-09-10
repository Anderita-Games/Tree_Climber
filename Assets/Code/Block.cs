using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	GameObject Player;

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().color = new Color32((byte)Random.Range(0,251), (byte)Random.Range(0,251), (byte)Random.Range(0,251), (byte)250);
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.y - 1 > this.transform.position.y) {
			Destroy(this.gameObject);
		}
	}
}
