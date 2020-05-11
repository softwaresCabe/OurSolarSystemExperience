using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CircleTrigger_text : MonoBehaviour
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

	public UnityEngine.UI.Button selectedButton;
	public UnityEngine.UI.Slider selectedSlider;
	public PointerEventData pointer;

	public bool isButton;
	public PointerEventData lookData;
	private bool _guiRaycastHit;

	public float FinalTime, lasTimeTrigger;
	private bool wasTriggered, notDoubleClick;
	public bool fixedColor;

	//public UnityEngine.UI.Button lastButonSelec;
	//public UnityE
	
	// text display functions
	public Animator textAnimator;
	public UnityEngine.UI.Text butText;

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
			if(isButton==true) //case button
			{
				ExecuteEvents.Execute(selectedButton.gameObject, pointer, ExecuteEvents.submitHandler);
				wasTriggered=true;


				textAnimator.ResetTrigger("AnimeText");
				textAnimator.SetTrigger("AnimeText");
				
				//lastButonSelec=selectedButton;
			}
			else //case slider
			{
				//ExecuteEvents.Execute(selectedSlider.gameObject, pointer, ExecuteEvents.dragHandler);
				//ExecuteEvents.Execute(selectedSlider.gameObject, pointer, ExecuteEvents.beginDragHandler);
				
				//ExecuteEvents.Execute(selectedSlider.gameObject, pointer, ExecuteEvents.dragHandler);
				
				//ExecuteEvents.Execute(selectedSlider.gameObject, pointer, ExecuteEvents.dragHandler);
				
				//selectedSlider.value=pointer.position;
							
				//pointer.pressPosition=new Vector2(-10,0);
				
				
				//selectedSlider.OnPointerDown(pointerVisionScript.GetLookPointerEventData());
									
				
			}
			
			undoClick();

    	}
    	
		current = Color.Lerp(start, end, value+0.001f);


		CircleImage.fillAmount = Mathf.Max( value,0.001f);


		CircleImage2.fillAmount = Mathf.Max( value,0.001f);


		if(fixedColor==false)
		{
			CircleImage.color = (Color) current;
			CircleImage2.color =(Color) current;
		}

	
		
    }
    

    
    public void prepareToClick(UnityEngine.UI.Button button)
    {
		elapsed=0;
		CircleImage.enabled=true;
		CircleImage2.enabled=true;
		isButton=true;
		selectedButton=button;
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

    public void ChangeText(float a)
    {
		butText.text="selected " + a;
		textAnimator.ResetTrigger("AnimeText");
		textAnimator.SetTrigger("AnimeText");
    }


	public void prepareToClickSlider(UnityEngine.UI.Slider slider)
	{
		elapsed=0;
		CircleImage.enabled=true;
		CircleImage2.enabled=true;
		isButton=false;
		
		selectedSlider=slider;
		
	}
	
	
    
	public void undoClick()
	{
		elapsed=20000000;
		CircleImage.enabled=false;
		CircleImage2.enabled=false;
		
	}

    
    
	public void setFocusTime(UnityEngine.UI.Slider slider)
	{
		speed = 1.1f + (slider.value-0.5f);
	}



	
     
}
