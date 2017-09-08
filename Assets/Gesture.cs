using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class Gesture : MonoBehaviour {


		LeapProvider provider;
		HandModel hand_model;
		Hand leap_hand;


		private bool deactivate;
		private bool check;
		private int nrHands;
		private bool isPinching;
		private Frame frame;
		private Finger thumb ;
		private Finger indexFinger ;
		private Finger middleFinger;
		private Finger ringFinger;
		private Finger pinkyFinger;
		private bool hasHands;
		private bool pointing;
		private Hand leftHand;
		private Hand rightHand;
		private bool isHandOpen;
		private bool isHandClosed;
		private bool isSwiping;
		private float checkIdleTimer;

		// Use this for initialization
		void Start () {

			provider = FindObjectOfType<LeapProvider>() as LeapProvider;
			checkIdleTimer = 10;
			nrHands = 0;

		}
		/// <summary>
		/// Inicializar dedos, assim como garantir que existem mãos
		/// </summary>
		void initializeFingersHands(){

			try{ 

				frame = provider.CurrentFrame;
				nrHands = frame.Hands.Count;

				thumb = frame.Hands [0].Fingers [(int)Finger.FingerType.TYPE_THUMB];
				indexFinger = frame.Hands [0].Fingers [(int)Finger.FingerType.TYPE_INDEX];
				middleFinger = frame.Hands [0].Fingers [(int)Finger.FingerType.TYPE_MIDDLE];
				ringFinger = frame.Hands [0].Fingers [(int)Finger.FingerType.TYPE_RING];
				pinkyFinger = frame.Hands [0].Fingers [(int)Finger.FingerType.TYPE_PINKY];


				if(nrHands>0){

					hasHands=true;

				}

			}catch (System.Exception){


				nrHands = 0;
				hasHands=false;

			}

		}

	IEnumerator timer(float nr){
	
		deactivate = true;
		yield return new WaitForSeconds (nr);
		deactivate = false;
	
	}
		

	IEnumerator timerSwipe(float nr){

		yield return new WaitForSeconds (nr);

		isSwiping = false;

	}




	public bool openHand(){

		initializeFingersHands ();
	
		foreach (Hand hand in frame.Hands) {
		
			if (hasHands) {
			
				if (!deactivate && !isSwiping && !isPinching && !isHandClosed && hand.GrabStrength < 0.2f) {

					isHandOpen = true;
					StartCoroutine (timer(0.4f));
					return true;
				
				} else {
				
					isHandOpen = false;
				
				}
			
			}  
		}

		return false;
	}

	public bool closeHand(){

		initializeFingersHands ();

		foreach (Hand hand in frame.Hands) {

			if (hasHands) {

				if (!deactivate && !isSwiping && hand.GrabStrength > 0.8f) {

					isHandClosed = true;
					StartCoroutine (timer(0.4f));
					return true;

				} else {
				
					isHandClosed = false;
				
				}

			} 
		}

		return false;
	}



	public bool pinch(){

		initializeFingersHands ();

		foreach (Hand hand in frame.Hands) {

			if (hasHands) {

				if (!deactivate && !isSwiping && hand.PinchStrength > 0.7f) {

					isPinching = true;
					StartCoroutine (timer(0.4f));
					return true;

				} else {
				
					isPinching = false;
				}

			} 
		}

		return false;
	}

	public bool swipeLeft(float sensitivity, float timer){

		initializeFingersHands ();

		foreach (Hand hand in frame.Hands) {

			if (hasHands) {

				if (middleFinger.TipVelocity.x < middleFinger.TipVelocity.y) {

					if (!deactivate && !isSwiping && !isHandClosed && !isPinching && middleFinger.TipVelocity.x < sensitivity && middleFinger.TipVelocity.y < -1 ) {

						isSwiping = true;

						StartCoroutine (timerSwipe(timer));
						return true;

					} 

				}


			} 
		}

		return false;
	
	}

	public bool swipeRight(float sensitivity, float timer){

		initializeFingersHands ();

		foreach (Hand hand in frame.Hands) {

			if (hasHands) {

				if (middleFinger.TipVelocity.x > middleFinger.TipVelocity.y) {

					if (!deactivate && !isHandClosed && !isSwiping && !isPinching && middleFinger.TipVelocity.x > sensitivity && middleFinger.TipVelocity.y < -1 ) {

						isSwiping = true;

						StartCoroutine (timerSwipe(timer));
						return true;

					} 



				}


			} 
		}

		return false;

	}



	public void printVelocity(){

		initializeFingersHands ();

		foreach (Hand hand in frame.Hands) {

			if (hasHands) {

				Debug.Log (middleFinger.TipVelocity.x);


			} 
		}



	}











	////////////////////////////////////
	}

