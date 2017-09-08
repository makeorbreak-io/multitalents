using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {



	private Gesture gesture;
	public float delaySwipeLeft;
	public float delaySwipeRight;
	public float sensitivitySwipeLeft;
	public float sensitivitySwipeRight;
	private List<GameObject> stages;
	private List<Vector3> initialPosition;

	private bool moving;
	private float movingTime;
	public float targetMovingTime;

	private int newStage;
	private int currentStage;

	// Use this for initialization
	void Start () {

		gesture = GameObject.FindObjectOfType<Gesture> ();

		stages= new List<GameObject>(); 
		initialPosition= new List<Vector3>(); 

		foreach (Transform t in transform) {

			stages.Add (t.gameObject);
			initialPosition.Add (t.gameObject.transform.position);
		}

		//////////////



		while(newStage == currentStage) {

			newStage = Mathf.RoundToInt(Random.value * 9);

		}

		moving = true;


		movingTime = 0;


		/////////////////////7




	}


	private void gestureHandler(){
	
		/*if (gesture.openHand()) {
		
		
			Debug.Log ("OPEN");
		
		}*/

		if (gesture.closeHand()) {


			Debug.Log ("Close");

		}

		/*if (gesture.pinch()) {


			Debug.Log ("pinch");

		}*/

		if (gesture.horns()) {


			Debug.Log ("horns");

		}


		//gesture.printVelocity ();

		if (gesture.swipeLeft(sensitivitySwipeLeft, delaySwipeLeft)) {


			Debug.Log ("Swipe Left");

		}

		if (gesture.swipeRight(sensitivitySwipeRight, delaySwipeRight)) {


			Debug.Log ("Swipe Right");

		}
	
	
	}

	private void nextStage(){
	


		if (moving) {

			if (movingTime < targetMovingTime) {
				
				Debug.Log ("Entra");
				Debug.Log ("CurrentStage" + currentStage);
				Debug.Log ("newStage" + newStage);
				Debug.Log (stages [newStage].transform.position);
				stages [currentStage].SetActive (true);
				stages [newStage].SetActive (true);

				movingTime += Time.deltaTime;

				stages [currentStage].transform.position = Vector3.Lerp (initialPosition [currentStage], new Vector3 (initialPosition [currentStage].x, initialPosition [currentStage].y + 656, initialPosition [currentStage].z), movingTime * (movingTime / targetMovingTime));
				stages [newStage].transform.position = Vector3.Lerp (new Vector3 (initialPosition [newStage].x, initialPosition [newStage].y - 656, initialPosition [newStage].z), initialPosition [newStage], movingTime * (movingTime / targetMovingTime));

			} else {


				stages [currentStage].SetActive (false);
				movingTime = 0;
				newStage = currentStage;
				moving = false;

			}

		}
	
	}


	// Update is called once per frame
	void Update () {



		
			nextStage ();




	}
}
