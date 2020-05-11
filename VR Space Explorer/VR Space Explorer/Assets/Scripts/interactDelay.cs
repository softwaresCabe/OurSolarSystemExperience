using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class interactDelay : MonoBehaviour {
	public float DelayTime;
	private Button myButton;
	private EventTrigger myTrigger;

	void Start(){
		myButton = GetComponent<Button>();
		myTrigger = GetComponent<EventTrigger>();

		myButton.interactable = false;
		myTrigger.enabled = false;


	}
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > DelayTime){
			myButton.interactable = true;
			myTrigger.enabled = true;
		}
	}
}
