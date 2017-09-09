using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {



	public Gesture gesture;
	public float delaySwipeLeft;
	public float delaySwipeRight;
	public float sensitivitySwipeLeft;
	public float sensitivitySwipeRight;
	private List<GameObject> stages;
	private List<Vector3> initialPosition;

	private int task;

	private bool moving;
	private float movingTime;
	public float targetMovingTime;

	private int newStage;
	private int currentStage;
	private int taskCounter;
	private int targetTask;

	private bool alternateHand;

	// Use this for initialization
	void Start () {


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

	

		generateTask ();



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

	private void generateTask(){

		//task = Mathf.RoundToInt(Random.value*9);
		task=1;
		targetTask=Mathf.RoundToInt(Random.value*2+1);

	}

	private void taskToDo(){

	
		if (task == 0) {
		
			////////////////////CONTEÚDO Gráfico//////////////////
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// ////////////////////////////////////////////////////


			if (taskCounter != targetTask) {

				if (gesture.pinch ()) {

					taskCounter++;

				}


			} else {
			
				taskCounter = 0;
				movingTime = 0;
				moving = true;
				generateTask ();

			}
			 
		}

		if (task == 1) {

			////////////////////CONTEÚDO Gráfico//////////////////
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// ////////////////////////////////////////////////////


			if (taskCounter != targetTask) {

				if (!alternateHand) {

					if (gesture.closeHand ()) {
						
						alternateHand = true;
						Debug.Log ("Entra1");
					}

				} 


				if(alternateHand) {
				
					if (gesture.openHand ()) {
						Debug.Log ("Entra2");
						taskCounter++;
					
					}
				
				}




			} else {

				taskCounter = 0;
				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
			}

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




		taskToDo ();
		nextStage ();
		Debug.Log (taskCounter+"/"+ targetTask);
		//Debug.Log("AlternateHand:" + alternateHand);

	}
}
