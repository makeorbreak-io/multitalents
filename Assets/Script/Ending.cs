using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {

    public GameObject part1;
    public Game game;
    public Text score;
	public Text scoreTXT;
	private bool once;

	// Use this for initialization
	void Update () { 
		
		if (!once && !part1.activeInHierarchy) {
			once = true;
			StartCoroutine("timer");

		}

        

	}


    IEnumerator timer() {

        score.text = "You scored " + game.getScore() + " points!";

        yield return new WaitForSeconds(5);
        

        game.setScore(0);
        part1.SetActive(true);
		once = false;
		scoreTXT.text = "SCORE: 0";
        this.gameObject.SetActive(false);
    }


}
