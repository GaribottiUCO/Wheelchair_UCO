using UnityEngine;
using System.Collections;

public class PracticeMode : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}
}