using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {
    
    public void ChangeToScene (string sceneToChangeTo){
  
		Application.LoadLevel(sceneToChangeTo);
	}
}