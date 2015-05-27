using UnityEngine;
using System.Collections;

public class TouchManage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		EasyTouch.On_TouchStart += On_TouchStart; 
	}

	// Unsubscribe 
	void OnDisable()
	{
		EasyTouch.On_TouchStart -= On_TouchStart; 
	}

	// Unsubscribe 
	void OnDestroy()
	{
		EasyTouch.On_TouchStart -= On_TouchStart; 
	}
	
	// Touch start event
	public void On_TouchStart(Gesture gesture)
	{
		Debug.Log( "Touch in " + gesture.position); 
	}

	// Update is called once per frame
	void Update () {
	
	}
}
