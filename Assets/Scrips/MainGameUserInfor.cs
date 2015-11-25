using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGameUserInfor : MonoBehaviour {

    public InputField firstNameInputfile;
    public Text txtTest;
    public Button subButton;
    
    private string firstName;

    // Use this for initialization
    void Start () {
        firstName = "";

        

    }
	
	// Update is called once per frame
	public void getFirstName()
    {
        firstName = firstNameInputfile.text;

       
      
    }

    public void setTxtTest()
    {
        txtTest.text = "Test" + firstName.ToString();
    }

   
}
