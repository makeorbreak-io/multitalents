using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {


	public Remap remap;
	public Gesture gesture;
	public float delaySwipeLeft;
	public float delaySwipeRight;
	public float sensitivitySwipeLeft;
	public float sensitivitySwipeRight;
	private List<GameObject> stages;
	private List<Vector3> initialPosition;

	public Image temporizador;

	private int task;

	private float gameTime;

	private bool moving;
	private float movingTime;
	public float targetMovingTime;

	private int stageNumber;
	private int newStage;
	private int currentStage;
	private int taskCounter;
	private int targetTask;

	private bool alternateHand;

	public GameObject part3;
	public GameObject part4;

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

		gameTime = 180;

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
		task=5;

		if (task == 1 || task==4 || task==5) {

			targetTask = Mathf.RoundToInt (Random.value * 3 + 3);

			while (targetTask!=2 && targetTask!=4 && targetTask!=6) {

				targetTask = Mathf.RoundToInt (Random.value * 3 + 3);
			}


		} else {
		
			targetTask=Mathf.RoundToInt(Random.value*2+1);
		
		}


	}

	private void gameTimeHandler(){

		if (gameTime > 0) {
	
			gameTime -= Time.deltaTime;
			temporizador.fillAmount = remap.remap (gameTime, 0, 180, 0, 1);
		
		} else {
		
			this.gameObject.SetActive (false);
		
		}

	}


	private void taskToDo(){

	
		if (task == 0 && !moving) {
		
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

		if (task == 1 && !moving) {

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

					if (gesture.closeHand () && !alternateHand) {
						
						alternateHand = true;
						Debug.Log ("Entra1");
						taskCounter++;
					}


					if (gesture.openHand () && alternateHand) {
					
						alternateHand = false;
						Debug.Log ("Entra2");
						taskCounter++;
					
					}
			

			} else {

				taskCounter = 0;
				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
			}

		}

		if (task == 2 && !moving) {

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

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft) ) {

					taskCounter++;
				}



			} else {

				taskCounter = 0;
				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
			}

		}

		if (task == 3 && !moving) {

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

				if (gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight) ) {

					taskCounter++;
				}



			} else {

				taskCounter = 0;
				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
			}

		}
	
		if (task == 4 && !moving) {

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

				if (gesture.horns () && !alternateHand) {

					alternateHand = true;

					taskCounter++;
				}


				if (gesture.openHand () && alternateHand) {

					alternateHand = false;
		
					taskCounter++;

				}


			} else {

				taskCounter = 0;
				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
			}

		}

		if (task == 5 && !moving) {

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

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft) && !alternateHand) {

					alternateHand = true;

					taskCounter++;
				}


				if (gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight) && alternateHand) {

					alternateHand = false;

					taskCounter++;

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

		if (gameTime > 0) {
		
			taskToDo ();
			nextStage ();
			Debug.Log (taskCounter + "/" + targetTask);
			Debug.Log (gameTime);
			gameTimeHandler ();

		} else {
			temporizador.fillAmount = 1;
			part4.SetActive (true);
			part3.gameObject.SetActive (false);
			gameTime = 180;
			generateTask ();

		
		}



	}
}
