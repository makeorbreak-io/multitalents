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
	

	private bool alternateHand;

	public GameObject part1;
	public GameObject part3;
	public GameObject ending;
	public GameObject GameGO;
	public GameObject GameCanvas;
	public GameObject trollCanvas;

	public Image circle;
	public Text stageText;
	public Text taskD;
	public Text times;
    public Text ScoreTXT;

	public Image trollCircle;
	public Text trollStageText;
	public Text trollTask;
	public Text trollTime;

	public Image Kim1;
	public Image Kim2;

	public Image Trump1;
	public Image Trump2;

	private int score;
	private int trollCount;
	private float trollTimer;

	private bool showingFace;


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

		gameTime = 90;

		generateTask ();

		stageNumber = 1;
        ScoreTXT.text = "SCORE:" +0;
    }


	public int getScore(){

		return score;
	}

	public void setScore(int value){

		score = value;
	}

	private void generateTask(){

	task = Mathf.RoundToInt(Random.value*7);

		if (task == 1 || task==4 || task==5) {

			targetTask = Mathf.RoundToInt (Random.value * 3 + 3);

			while (targetTask!=2 && targetTask!=4 && targetTask!=6) {

				targetTask = Mathf.RoundToInt (Random.value * 3 + 3);
			}


		} else {
		
			targetTask=Mathf.RoundToInt(Random.value*2+1);
		
		}

		counterTask = targetTask;
	
		times.text=counterTask+"x";
		circle.fillAmount = 1;

		if (task == 6 || task == 7) {
		

			trollCircle.fillAmount = 1;

			if (task == 6) {
				trollTimer = 5;
				Trump1.gameObject.SetActive (true);
			
			} else {
				trollTimer = 5;
				Kim1.gameObject.SetActive (true);
			
			}


		
		}
	}

	private void gameTimeHandler(){

		if (gameTime > 0) {
	
			gameTime -= Time.deltaTime;
			temporizador.fillAmount = remap.remap (gameTime, 0, 90, 0, 1);
		
		} else {
		
			this.gameObject.SetActive (false);
		
		}

	}


	private void taskToDo(){

	
		if (task == 0 && !moving) {
		
			////////////////////CONTEÚDO Gráfico//////////////////

			stageText.text = "STAGE " + (stageNumber).ToString () + " -";
			taskD.text = "PINCH!";


			if (counterTask > 0) {

				if (gesture.pinch ()) {

					counterTask--;

					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}
					
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);
				}


			} else {

				GameCanvas.gameObject.SetActive (false);
				movingTime = 0;
				moving = true;
				circle.fillAmount = 1;
				stageNumber++;
				score += 10;
				ScoreTXT.text = "SCORE: " + score;
			}
			 
		}

		if (task == 1 && !moving) {

			////////////////////CONTEÚDO Gráfico//////////////////
		

			stageText.text = "STAGE " + (stageNumber).ToString () + " -";
			taskD.text = "CLOSE AND OPEN \nYOUR HAND";


			if (counterTask > 0) {

				if (gesture.closeHand () && !alternateHand) {
						
					alternateHand = true;
				
					counterTask--;

					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}

					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);
				}


				if (gesture.openHand () && alternateHand) {
					
					alternateHand = false;
				
					counterTask--;

					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);


				}
			

			} else {

				alternateHand = false;
				GameCanvas.gameObject.SetActive (false);
				movingTime = 0;
				moving = true;
				circle.fillAmount = 1;
				stageNumber++;
				score += 10;
				ScoreTXT.text = "SCORE: " + score;
			}

		}

		if (task == 2 && !moving) {

			stageText.text = "STAGE " + (stageNumber).ToString () + " -";
			taskD.text = "SWIPE LEFT";


			if (counterTask > 0) {

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft)) {

					counterTask--;

					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);
				}



			} else {

				GameCanvas.gameObject.SetActive (false);
				movingTime = 0;
				moving = true;
				circle.fillAmount = 1;
				stageNumber++;
				score += 10;
				ScoreTXT.text = "SCORE: " + score;
			}

		}

		if (task == 3 && !moving) {

			stageText.text = "STAGE " + (stageNumber).ToString () + " -";
			taskD.text = "SWIPE RIGHT";


			if (counterTask > 0) {

				if (gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight)) {

					Debug.Log ("Entra");
					counterTask--;

					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);
				}



			} else {
				
				GameCanvas.gameObject.SetActive (false);
				movingTime = 0;
				moving = true;
				circle.fillAmount = 1;
				stageNumber++;
				score += 10;
				ScoreTXT.text = "SCORE: " + score;
			}

		}
	
		if (task == 4 && !moving) {

			stageText.text = "STAGE " + (stageNumber).ToString () + " -";
			taskD.text = "HORNS THEN \nOPEN YOUR HAND!";


			if (counterTask > 0) {

				if (gesture.horns () && !alternateHand) {

					alternateHand = true;

					counterTask--;

					
					if (counterTask >= 1) {
						
						times.text = counterTask + "x";	

					}

					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);
				}


				if (gesture.openHand () && alternateHand) {

					alternateHand = false;
		
					counterTask--;

					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);

				}


			} else {
				
				GameCanvas.gameObject.SetActive (false);
				alternateHand = false;
				movingTime = 0;
				moving = true;
				circle.fillAmount = 1;
				stageNumber++;
				score += 10;
				ScoreTXT.text = "SCORE: " + score;
			}

		}

		if (task == 5 && !moving) {

			stageText.text = "STAGE " + (stageNumber).ToString () + " -";
			taskD.text = "SWIPE LEFT, THEN \nSWIPE RIGHT";


			if (counterTask > 0) {

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft) && !alternateHand) {

					alternateHand = true;

					counterTask--;

					if (counterTask >= 1) {
						
						times.text = counterTask + "x";	
					}
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);
				}


				if (gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight) && alternateHand) {

					alternateHand = false;
				
					counterTask--;


					if (counterTask >= 1) {
						times.text = counterTask + "x";	
					}
					circle.fillAmount = remap.remap (counterTask, 0, targetTask, 0, 1);

				}


			} else {
				
				GameCanvas.gameObject.SetActive (false);
				alternateHand = false;
				movingTime = 0;
				moving = true;
				circle.fillAmount = 1;
				stageNumber++;
				score += 10;
				ScoreTXT.text = "SCORE: " + score;
			}

		}

		if (task == 6 && !moving) {

			trollStageText.text = "A WILD TRUMP APPEARD!";
			trollTask.text = "SLAP HIM FOR \n5 SECONDS!";


			if (trollTimer > 0) {


				trollTimer -= Time.deltaTime;
				trollCircle.fillAmount = remap.remap (trollTimer, 0, 5, 0, 1);

				if (gesture.swipeLeft (sensitivitySwipeLeft, delaySwipeLeft) || gesture.swipeRight (sensitivitySwipeRight, delaySwipeRight)) {

					Debug.Log ("ENTRA ");

					score += 3;

					if (!showingFace) {

						StartCoroutine ("trumpTimer");

					}
					trollCount++;
					trollTime.text = "" + trollCount;
					ScoreTXT.text = "SCORE: " + score;



				}




			} else {

				Kim1.gameObject.SetActive (false);
				Trump1.gameObject.SetActive (false);
				GameCanvas.gameObject.SetActive (false);
				trollCanvas.gameObject.SetActive (false);
				movingTime = 0;
				trollCount = 0;
				trollTime.text = "" + 0;
				moving = true;
				trollCircle.fillAmount = 1;
				stageNumber++;

			}

		}

		if (task == 7 && !moving) {

			////////////////////CONTEÚDO Gráfico//////////////////

			trollStageText.text = "A WILD KIM APPEARD!";
			trollTask.text = "PINCH HIM FOR \n5 SECONDS!";


			if (trollTimer > 0) {


				trollTimer -= Time.deltaTime;
				trollCircle.fillAmount = remap.remap (trollTimer, 0, 5, 0, 1);

				if (gesture.pinch ()) {


					score += 6;

					if (!showingFace) {
					
						StartCoroutine ("kimTimer");
					
					}

					trollCount++;
					trollTime.text = "" + trollCount;
					ScoreTXT.text = "SCORE: " + score;



				}




			} else {

				Kim1.gameObject.SetActive (false);
				Trump1.gameObject.SetActive (false);
				GameCanvas.gameObject.SetActive (false);
				trollCanvas.gameObject.SetActive (false);
				movingTime = 0;
				trollCount = 0;
				trollTime.text = "" + 0;
				moving = true;
				trollCircle.fillAmount = 1;
				stageNumber++;

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
				currentStage = newStage;

				newStage = Mathf.RoundToInt(Random.value * 9);

				while(newStage == currentStage) {

					newStage = Mathf.RoundToInt(Random.value * 9);

				}
				movingTime = 0;
				generateTask ();
				moving = false;

			}

		} else {

			if (task == 6 || task == 7) {

				trollCanvas.gameObject.SetActive (true);
				GameCanvas.gameObject.SetActive (false);

			} else {
				trollCanvas.gameObject.SetActive (false);
				GameCanvas.gameObject.SetActive (true);
			}
		}
	
	}
		

	IEnumerator trumpTimer(){
	
		showingFace = true;

		Trump2.gameObject.SetActive (true);
		Trump1.gameObject.SetActive (false);
		yield return new WaitForSeconds (delaySwipeLeft);
		Trump2.gameObject.SetActive (false);
			
		if (moving || task != 6) {

			Trump1.gameObject.SetActive (false);

		}else{

			Trump1.gameObject.SetActive (true);

		}

		showingFace = false;
	}

	IEnumerator kimTimer(){
		showingFace = true;
		Kim2.gameObject.SetActive (true);
		Kim1.gameObject.SetActive (false);
		yield return new WaitForSeconds (delaySwipeLeft);
		Kim2.gameObject.SetActive (false);

		if (moving || task != 7) {

			Kim1.gameObject.SetActive (false);

		}else{

			Kim1.gameObject.SetActive (true);

		}
		showingFace = false;
	}

	// Update is called once per frame
	void Update () {

		if (gameTime > 0) {
		
			taskToDo ();
			nextStage ();
	
			Debug.Log(trollTimer);
			gameTimeHandler ();

		} else {
			temporizador.fillAmount = 1;

			circle.fillAmount = 1;
			stageNumber = 1;
			GameCanvas.gameObject.SetActive (false);
			trollCanvas.gameObject.SetActive (false);
			gameTime = 90;
			generateTask ();
			ending.SetActive (true);
			this.gameObject.SetActive (false);
		}



	}
}
