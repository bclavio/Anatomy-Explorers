using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RadialSlider: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	bool isPointerDown=false;
    bool confirm = false;
<<<<<<< HEAD
    float temp = 0;
    // Called when the pointer enters our GUI component.
    // Start tracking the mouse
    public void OnPointerEnter( PointerEventData eventData )
=======
	// Called when the pointer enters our GUI component.
	// Start tracking the mouse
	public void OnPointerEnter( PointerEventData eventData )
>>>>>>> Bianca
	{
		StartCoroutine( "TrackPointer" );            
	}
	
	// Called when the pointer exits our GUI component.
	// Stop tracking the mouse
	public void OnPointerExit( PointerEventData eventData )
	{
		StopCoroutine( "TrackPointer" );
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		isPointerDown= true;
		//Debug.Log("mousedown");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isPointerDown= false;
        if (GetComponent<Image>().fillAmount <= 0.99f)
        {
            GetComponent<Image>().fillAmount = 0;
            temp = 0;
        }
            //Debug.Log("mousedown");
    }

	// mainloop
	IEnumerator TrackPointer()
	{
		var ray = GetComponentInParent<GraphicRaycaster>();
		var input = FindObjectOfType<StandaloneInputModule>();
<<<<<<< HEAD
        
        var text = GetComponentInChildren<Text>();
=======

		var text = GetComponentInChildren<Text>();
>>>>>>> Bianca
                		
		if( ray != null && input != null )
		{
			while( Application.isPlaying )
			{

                // TODO: if mousebutton down
               
                if (isPointerDown && confirm == false)
				{
                    

					Vector2 localPos; // Mouse position  
					RectTransformUtility.ScreenPointToLocalPointInRectangle( transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos );
<<<<<<< HEAD


                    	
					// local pos is the mouse position.
					float angle = (Mathf.Atan2(-localPos.y, localPos.x)*180f/Mathf.PI+180f)/360f;
                    if (angle <= temp + 0.1f )
                    {
                        GetComponent<Image>().fillAmount = angle;

                        GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, angle);
                        temp = angle;
                    }
					 //text.text = ((int)(angle*360f)).ToString();

                    if (GetComponent<Image>().fillAmount >= .99f)   
                    {
                        text.text = "Confirm";
                        confirm = true;
                        Debug.Log("true");
                    }
                    

=======
						
					// local pos is the mouse position.
					float angle = (Mathf.Atan2(-localPos.y, localPos.x)*180f/Mathf.PI+180f)/360f;

					GetComponent<Image>().fillAmount = angle;

					GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, angle);

					 //text.text = ((int)(angle*360f)).ToString();

                    if (GetComponent<Image>().fillAmount >= .95f)   
                    {
                        text.text = "Confirm";
                        confirm = true;
                        Debug.Log("true");
                    }

>>>>>>> Bianca
                    //Debug.Log(localPos+" : "+angle);	
                }

				yield return 0;
			}        
		}
		else
			UnityEngine.Debug.LogWarning( "Could not find GraphicRaycaster and/or StandaloneInputModule" );        
	}





}
