using UnityEngine;
using System.Collections;

public class myPath : MonoBehaviour{
	public Transform[] path;
	public  GameObject player;
	public float LoopTime;

	void Start(){
		tween();
	}

	void tween(){
		iTween.MoveTo(player, iTween.Hash("path",path,
		"time",LoopTime,
		"easeType","Linear",
		"LoopType","pingPong"));	
	}

}
