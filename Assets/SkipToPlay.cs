using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipToPlay : MonoBehaviour {

	public Gesture gesture;
	public float sensitivityRight;
	public float sensitivityLeft;
	public float delayLeft;
	public float delayRight;

	public GameObject part2;
	public GameObject part3;


	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if (gesture.swipeLeft (sensitivityLeft, delayLeft) || gesture.swipeRight (sensitivityRight, delayRight)) {

			part3.SetActive (true);
			part2.SetActive (false);

		}



	}
}
