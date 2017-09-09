using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour {
	
	public GameObject part1;
	public GameObject part4;

	void Start () {

		StartCoroutine ("timer");


	}


	IEnumerator timer(){

		yield return new WaitForSeconds (10);


		part1.SetActive (true);
		part4.gameObject.SetActive (false);


	}

}
