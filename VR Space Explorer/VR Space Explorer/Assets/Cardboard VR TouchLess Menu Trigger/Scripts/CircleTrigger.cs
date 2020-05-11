using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CircleTrigger : MonoBehaviour
{
    
	public Color start;
    public Color end;
    public Color current;
	float speed;



    //Scrollbar scrollbar { get { return GetComponent<Scrollbar>(); } }
	public Image CircleImage,CircleImage2;
	public float initialValue;
	public float endValue;
	public float value;
	public float elapsed;

	public GameObject selectedGameObject;
	public PointerEventData pointer;

	public PointerEventData lookData;
	private bool _guiRaycastHit;

	public float FinalTime, lasTimeTrigger;
	private bool wasTriggered, notDoubleClick;


	//public UnityEngine.UI.Button lastButonSelec;
	//public UnityE
	

    void Start()
    {
    	
        CircleImage.type = Image.Type.Filled;
        CircleImage.fillMethod = Image.FillMethod.Radial360;
        CircleImage.fillOrigin = 0;
        
		CircleImage2.type = Image.Type.Filled;
		CircleImage2.fillMethod = Image.FillMethod.Radial360;
		CircleImage2.fillOrigin = 0;
		
		speed=1/FinalTime;
		wasTriggered=false;
		
		lasTimeTrigger=-100;
		value=10000;
		notDoubleClick=true;
		
		
    }

    void FixedUpdate()
    {
		pointer = new PointerEventData(EventSystem.current);
		elapsed+=Time.fixedDeltaTime;


		if(elapsed*speed < endValue+0.2f )
		{
			value=elapsed*speed;
			
    	}
		else if( elapsed> endValue+0.2f && elapsed < 50000  && wasTriggered==false   &&  notDoubleClick ==true  )
		{
			
			ExecuteEvents.Execute(selectedGameObject, pointer, ExecuteEvents.pointerClickHandler);
			wasTriggered=true;

			undoClick();

    	}
    	
		current = Color.Lerp(start, end, value+0.001f);


		CircleImage.fillAmount = Mathf.Max( value,0.001f);


		CircleImage2.fillAmount = Mathf.Max( value,0.001f);




	
		
    }
    

    
    public void prepareToClick(GameObject go)
    {
		elapsed=0;
		CircleImage.enabled=true;
		CircleImage2.enabled=true;

		selectedGameObject=go;
		wasTriggered=false;
		
		if(Time.time-lasTimeTrigger>0.2f)
		{
			notDoubleClick=true;
			
			//Debug.Log ("notDoubhle");
		}
		else
		{
			notDoubleClick=false;
			//Debug.Log ("double");
		}

		lasTimeTrigger=Time.time;



							
    }

	
	
    
	public void undoClick()
	{
		elapsed=20000000;
		CircleImage.enabled=false;
		CircleImage2.enabled=false;
		
	}

    
     
}
