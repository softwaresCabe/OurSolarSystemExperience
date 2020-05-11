using UnityEngine;
using System.Collections;

public class SimpleCamFollow : MonoBehaviour {

	// Use this for initialization

	public float distance=5;
	public Transform REF;


	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position=Vector3.Lerp(transform.position,REF.position,0.01f);
	}



	public void MoveREF( Transform tf)
	{
		REF.position=tf.position-transform.forward*distance;


	}

}
