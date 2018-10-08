using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Master : MonoBehaviour {
	public GameObject Block;
	public GameObject Spike;
	public GameObject Player;

	GameObject Clone;

	public int Score = 0;
	public bool Game_Active = true;

	public UnityEngine.UI.Text Highscore_Text;
	public UnityEngine.UI.Text Score_Text;
	public UnityEngine.UI.Text Time_Text;

	GameObject Last;

	void Start () {
		Clone = Instantiate(Block, new Vector3(0, -4.5f, 0), new Quaternion(0, 0, 0, 0));
		Generate_Spike(10.5f);
	}

	void Update () {
		if (Player.transform.position.y > Clone.transform.position.y - 9.5f) {
			Clone = Instantiate(Block, new Vector3(0, Clone.transform.position.y + 1, 0), new Quaternion(0, 0, 0, 0));
			if (Last.transform.position.y - 10 < Player.transform.position.y) { //Make it not impossible to survive TODO: Smarter generation
				Generate_Spike(Last.transform.position.y + Random.Range(2, 6));
			}
		}

		if (Score > PlayerPrefs.GetInt("Highscore")) {
			PlayerPrefs.SetInt("Highscore", Score);
		}

		if (Mathf.Ceil(60 - Time.timeSinceLevelLoad) <= 0) {
			Game_Active = false;
		}

		Highscore_Text.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
		Score_Text.text = "Score: " + Score;
		if (Mathf.Ceil(60 - Time.timeSinceLevelLoad) > 0) {
			Time_Text.text = "Time: " + Mathf.Ceil(60 - Time.timeSinceLevelLoad);
		}else {
			Time_Text.text = "Time: 0";
		}
	}

	void Generate_Spike (float y) {
		if (Random.Range(0, 2) == 0) {
			GameObject Clone_Spike = Instantiate(Spike, new Vector3(-1, y, 0), new Quaternion(0, 0, 0, 0));
			Clone_Spike.transform.Rotate(new Vector3(0, 0, 90));
			Last = Clone_Spike;
		}else {
			GameObject Clone_Spike = Instantiate(Spike, new Vector3(1, y, 0), new Quaternion(0, 0, 0, 0));
			Clone_Spike.transform.Rotate(new Vector3(0, 0, 270));
			Last = Clone_Spike;
		}
	}
}
