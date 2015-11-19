using UnityEngine;
using System.Collections;

public class RabbitController : MonoBehaviour {
	private Animator anim;
	private Transform point, pointOne, pointTwo, pointThree, pointFour, pointFive, pointSix;
	private bool isMoving;
	private float walk, idle;
	public float speed, speedTimesDeltaTime;


	void Start () {
		anim = GetComponent<Animator>();

		pointOne = GameObject.Find ("pointOne").transform;
		pointTwo = GameObject.Find ("pointTwo").transform;
		pointThree = GameObject.Find ("pointThree").transform;
		pointFour = GameObject.Find ("pointFour").transform;
		pointFive = GameObject.Find ("pointFive").transform;
		pointSix = GameObject.Find ("pointSix").transform;

		point = pointOne;
		isMoving = true;
		walk = 1f;
		idle = 0f;
		speed = 2f;
		speedTimesDeltaTime = 0f;
		anim.SetFloat ("TransitionFloat", walk);
	}

	void Update(){
		speedTimesDeltaTime = speed * Time.deltaTime;

		if (transform.position == pointOne.position) {
			point = pointTwo;
		} else if (transform.position == pointTwo.position) {
			point = pointThree;
		} else if (transform.position == pointThree.position) {
			point = pointFour;
		} else if (transform.position == pointFour.position) {
			point = pointFive;
		} else if (transform.position == pointFive.position) {
			point = pointSix;
		} else if (transform.position == pointSix.position) {
			anim.SetFloat ("TransitionFloat", idle);
			isMoving = false;
		}

		if (isMoving) {
			anim.SetFloat ("TransitionFloat", walk);
			transform.LookAt(point);
			transform.position = Vector3.MoveTowards (transform.position, point.position, speedTimesDeltaTime);
		}
	}
}