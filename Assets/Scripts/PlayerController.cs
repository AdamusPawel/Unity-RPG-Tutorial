using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;

	// Use this for initialization
	void Start ()
	{
		cam = Camera.main;
	    motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetMouseButton(0))
	    {
	        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;

	        if (Physics.Raycast(ray, out hit, 100, movementMask))
	        {
                //Debug.Log("We hit" + hit.collider.name + " " + hit.point);

	            // move player to hit
                motor.MoveToPoint(hit.point);

                // stop focusing any object
	            RemoveFocus();
	        }
	    }

	    if (Input.GetMouseButton(1))
	    {
	        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;

	        if (Physics.Raycast(ray, out hit, 100))
	        {
	            // check if we hit interactable
	            Interactable interactable = hit.collider.GetComponent<Interactable>();
	            // if we did, set it as our focus
	            if (interactable != null)
	            {
	                SetFocus(interactable);
	            }
	        }
	    }

    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus()
    {
        focus = null;
    }
}
