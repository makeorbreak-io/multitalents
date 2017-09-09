using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beginning : MonoBehaviour {


	public Text cinco;
	public Text quatro;
	public Text tres;
	public Text dois;
	public Text um;
	private float timer;
	public GameObject game;

	void Start () {
		
	}

	private void timeHandler(){
	
		timer += Time.deltaTime;

		if(timer>5){

			timer = 0;
			game.gameObject.SetActive (true);
			this.gameObject.SetActive (false);
			cinco.gameObject.SetActive (true);
			um.gameObject.SetActive (false);

		}


		if (timer > 1 && timer < 2) {

			cinco.gameObject.SetActive (false);
			quatro.gameObject.SetActive (true);

		}

		if (timer > 2 && timer < 3) {

			quatro.gameObject.SetActive (false);
			tres.gameObject.SetActive (true);

		}

		if (timer > 3 && timer < 4) {

			tres.gameObject.SetActive (false);
			dois.gameObject.SetActive (true);
		}

		if (timer > 4) {
			
			dois.gameObject.SetActive (false);
			um.gameObject.SetActive (true);

		}
	
	
	
	}


	
	// Update is called once per frame
	void Update () {

		timeHandler ();

	}
}
