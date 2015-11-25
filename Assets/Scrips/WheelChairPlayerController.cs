using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class WheelChairPlayerController : MonoBehaviour {

    public Text bonusCountText;
    public GameObject imageObject; // Need to change a better name
    //public  GameObject canve;

    private float rotateSpeed = 6;
	private float forwardSpeed = 3;
    private int bonusCount;

    private Bonus bonus = new Bonus();

    // Use this for initialization
    void Start () {
		player = GameObject.Find("WheelChairPlayer");
		//rabbitplayer = GameObject.Find ("rabbit");
		rigidBody = player.GetComponent<Rigidbody>();
        //canve = GameObject.Find("Canvas");

        imageObject.SetActive(false);
        //image.;
        bonusCount = 0;
        displayBonus();
        bonus.setUp();
        bonus.SetActiveFalse();
        bonus.setCandyToTure();


    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float verticalInput = Input.GetAxis ("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");
		if (verticalInput < 0) {
			horizontalInput *= -1;
		}
		Vector3 vAcceleration = Vector3.forward * force * verticalInput;
		Vector3 hAcceleration = new Vector3(0, force *.50f * horizontalInput, 0);

		
		if ((verticalInput > 0 || verticalInput < 0)) {
			rigidBody.AddRelativeForce(vAcceleration * forwardSpeed, ForceMode.Acceleration);
			
		}
		if((horizontalInput > 0 || horizontalInput < 0)){
			rigidBody.AddTorque(hAcceleration * rotateSpeed, ForceMode.Acceleration);

		}
		
	}

    public void OnTriggerEnter(Collider other)
    {
        //bonus.OnTriggerEnterBonus( other, bonusCountText, bonusCount);
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            bonusCount += 1;
            displayBonus();
        }

       else if(other.gameObject.CompareTag("Final Line"))
        {
            other.gameObject.SetActive(false);
            bonusCount += 1;
            displayBonus();
            imageObject.SetActive(true);
        }
    }

    public void displayBonus()
    {
        bonus.setBonusCountText(bonusCountText, bonusCount);
    }

 
    private GameObject player;
	private Rigidbody rigidBody;
	private float force = 7;
	private float turnForce;
	private Vector3 lastVelocity;
}