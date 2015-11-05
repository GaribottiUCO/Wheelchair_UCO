using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WheelChairPlayerController : MonoBehaviour {
	private float rotateSpeed = 6;
	private float forwardSpeed = 3;
    private int count;

    public Text countText;

  //  Bonus bonus = new Bonus();

	// Use this for initialization
	void Start () {

		player = GameObject.Find("WheelChairPlayer");
		rigidBody = player.GetComponent<Rigidbody>();
        //       bonus.setCount(0);
        //       bonus.setCountText();
        count = 0;
        setCountText();

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }

    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    private GameObject player;
	private Rigidbody rigidBody;
	private float force = 6;
	private float turnForce;
	private Vector3 lastVelocity;
}