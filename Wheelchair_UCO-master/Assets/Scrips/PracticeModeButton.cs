using UnityEngine;
using System.Collections;

public class PracticeModeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI()
	{
		GUI.TextField(new Rect(15, 15, 100, 50),"Practice Mode");
	}
}
