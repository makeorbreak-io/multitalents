using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCycle : MonoBehaviour {


    public Gesture gesture;
	public Remap remap;
    public Image loading;
    public GameObject part2;

    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gesture.checkHands()) {

			loading.gameObject.SetActive(true);

			if (timer < 1.5f){
            
                timer += Time.deltaTime;
				loading.fillAmount = remap.remap (timer, 0, 1.5f, 0,1);

            }else {

                timer = 0;
				loading.fillAmount = 0;
				part2.SetActive (true);
				this.gameObject.SetActive (false);

            }

        }
        else{
			
			loading.gameObject.SetActive(false);
			timer = 0;
			loading.fillAmount = 0;

        }

		
	}
}
