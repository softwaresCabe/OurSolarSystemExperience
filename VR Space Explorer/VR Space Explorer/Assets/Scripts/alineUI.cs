using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alineUI : MonoBehaviour {
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		iTween.LookTo( this.gameObject, new Vector3(0,0,0), .001f );
	}
}
