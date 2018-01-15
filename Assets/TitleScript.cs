using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	private GUIStyle buttonStyle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		GUILayout.BeginArea (new Rect (10, Screen.height / 2 + 100, Screen.width - 10, 200));

		if(GUILayout.Button("New Game")){
			Application.LoadLevel("GameplayScene");
		}

		if(GUILayout.Button("High Score")){
			Debug.Log ("TODO");
		}

		if(GUILayout.Button("Exit")){
			Application.Quit();
			Debug.Log("Application.Quit() only works in build, not in editor");
		}

		GUILayout.EndArea();
	}
}
