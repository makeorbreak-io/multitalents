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
	private int targetTask;
	private int counterTask;
	private float counterCircle;

	private bool alternateHand;

	public GameObject part1;
	public GameObject part3;
	public GameObject ending;
	public GameObject GameGO;
	public GameObject GameCanvas;

	public Image circle;
	public Text stageText;
	public Text taskD;
	public Text times;



	// Use this for initialization
	void Start () {


		stages= new List<GameObject>(); 
		initialPosition= new List<Vector3>(); 

		foreach (Transform t in transform) {

			stages.Add (t.gameObject);
			initialPosition.Add (t.gameObject.transform.position);
		}

		//////////////


		newStage = Mathf.RoundToInt(Random.value * 9);

		while(newStage == currentStage) {

			newStage = Mathf.RoundToInt(Random.value * 9);

		}

		gameTime = 180;

		generateTask ();

		stageNumber = 1;

	}




	private void generateTask(){

		//task = Mathf.RoundToInt(Random.value*5);
		task=0;

		if (task == 1 || task==4 || task==5) {

			targetTask = Mathf.RoundToInt (Random.value * 3 + 3);

			while (targetTask!=2 && targetTask!=4 && targetTask!=6) {

				targetTask = Mathf.RoundToInt (Random.value * 3 + 3);
			}


		} else {
		
			targetTask=Mathf.RoundToInt(Random.value*2+1);
		
		}
		counterTask = targetTask;
		counterCircle = targetTask;
		times.text=counterTask+"x";
		circle.fillAmount = 1;
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

			stageText.text= "STAGE "+ (stageNumber).ToString()+" -";
			taskD.text = "Pinch";


			if (counterTask > 0) {

				if (gesture.pinch ()) {

					counterTask--;
					times.text = counterTask + "x";
					counterCircle -= 1 / targetTask;
					circle.fillAmount = counterCircle;
				}


			} else {
			

				movingTime = 0;
				moving = true;

				generateTask ();
				stageNumber++;
			}
			 
		}

		if (task == 1 && !moving) {

			////////////////////CONTEÚDO Gráfico//////////////////
		

			stageText.text= "STAGE "+ (stageNumber).ToString()+" -";
			taskD.text = "CLOSE AND OPEN \nYour HAND";


			if (counterTask > 0) {

					if (gesture.closeHand () && !alternateHand) {
						
						alternateHand = true;
					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;
					}


					if (gesture.openHand () && alternateHand) {
					
						alternateHand = false;
					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;

					
					}
			

			} else {

				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
				circle.fillAmount = 1;
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


			if (counterTask > 0) {

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft) ) {

					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;
				}



			} else {


				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
				circle.fillAmount = 1;
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


			if (counterTask > 0) {

				if (gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight) ) {

					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;
				}



			} else {

				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
				circle.fillAmount = 1;
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


			if (counterTask > 0) {

				if (gesture.horns () && !alternateHand) {

					alternateHand = true;

					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;
				}


				if (gesture.openHand () && alternateHand) {

					alternateHand = false;
		
					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;

				}


			} else {

				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
				circle.fillAmount = 1;
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


			if (counterTask > 0) {

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft) && !alternateHand) {

					alternateHand = true;
					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;
				}


				if (gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight) && alternateHand) {

					alternateHand = false;
					counterTask--;
					times.text = counterTask + "x";
					circle.fillAmount -= 1 / targetTask;

				}


			} else {



				movingTime = 0;
				moving = true;
				generateTask ();
				alternateHand = false;
				circle.fillAmount = 1;
			}

		}


	}


	private void nextStage(){
	


		if (moving) {

			GameCanvas.gameObject.SetActive (false);

			if (movingTime < targetMovingTime) {
				
			
				stages [currentStage].SetActive (true);
				stages [newStage].SetActive (true);

				movingTime += Time.deltaTime;

				stages [currentStage].transform.position = Vector3.Lerp (initialPosition [currentStage], new Vector3 (initialPosition [currentStage].x, initialPosition [currentStage].y + 525, initialPosition [currentStage].z), movingTime * (movingTime / targetMovingTime));
				stages [newStage].transform.position = Vector3.Lerp (new Vector3 (initialPosition [newStage].x, initialPosition [newStage].y - 525, initialPosition [newStage].z), initialPosition [newStage], movingTime * (movingTime / targetMovingTime));

			} else {


				stages [currentStage].SetActive (false);
				movingTime = 0;
				currentStage = newStage;

				moving = false;

			}

		} else {
		
			GameCanvas.gameObject.SetActive (true);

		}
	
	}


	IEnumerator timerEnding(){

		yield return new WaitForSeconds (10);

		stageNumber = 1;
		part1.SetActive (true);
		ending.gameObject.SetActive (false);


	}

	// Update is called once per frame
	void Update () {

		if (gameTime > 0) {
		
			taskToDo ();
			nextStage ();
			Debug.Log ("newStage"+ newStage);
			Debug.Log ("currentStage"+ currentStage);
		//	Debug.Log ("counterCircle"+ counterCircle);
			//Debug.Log ("counterTask"+ counterTask);
			gameTimeHandler ();

		} else {
			temporizador.fillAmount = 1;
			ending.SetActive (true);
			GameGO.gameObject.SetActive (false);
			circle.fillAmount = 1;

			GameCanvas.gameObject.SetActive (false);
			gameTime = 180;
			generateTask ();

		
		}



	}
}
