using UnityEngine;
using System.Collections;

public class SideBob : MonoBehaviour {
	
	public float 		BobbingSpeed 		= 0.1f;
	public float 		BobbingAmount		= 0.6f;
	
	private float timer = 0.0f;
	public void Update()
	{	
		var viewBobTimer = 0.0f;
		var waveslice = 0.0; 
	    var horizontal = OVRGamepadController.GPC_GetAxis((int)OVRGamepadController.Axis.LeftYAxis); 
	    var vertical = OVRGamepadController.GPC_GetAxis((int)OVRGamepadController.Axis.LeftXAxis); 
		var position = transform.localPosition;
	    if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 
	       timer = 0.0f; 
	    } 
	    else { 
	       waveslice = Mathf.Sin(timer); 
	       timer = timer + BobbingSpeed; 
	       if (timer > Mathf.PI * 2) { 
	          timer = timer - (Mathf.PI * 2); 
	       } 
	    } 
	    if (waveslice != 0) { 
			var translateChange = (float)waveslice * BobbingAmount; 
			var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f); 
			translateChange = totalAxes * translateChange; 
			position.x = (float)translateChange;
	    } 
	    else { 
	       	position.x = 0.0f;
			
	    } 
		
		transform.localPosition = position;
	}
}
