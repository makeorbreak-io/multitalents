using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {



	private Gesture gesture;
	public float delaySwipeLeft;
	public float delaySwipeRight;
	public float sensitivitySwipeLeft;
	public float sensitivitySwipeRight;

	// Use this for initialization
	void Start () {

		gesture = GameObject.FindObjectOfType<Gesture> ();

	}
	
	// Update is called once per frame
	void Update () {

		/*if (gesture.openHand()) {
		
		
			Debug.Log ("OPEN");
		
		}*/

		if (gesture.closeHand()) {


			Debug.Log ("Close");

		}

		/*if (gesture.pinch()) {


			Debug.Log ("pinch");

		}*/


		//gesture.printVelocity ();

		if (gesture.swipeLeft(sensitivitySwipeLeft, delaySwipeLeft)) {


			Debug.Log ("Swipe Left");

		}

		if (gesture.swipeRight(sensitivitySwipeRight, delaySwipeRight)) {


			Debug.Log ("Swipe Right");

		}

	}
}
