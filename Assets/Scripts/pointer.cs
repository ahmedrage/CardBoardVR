using UnityEngine;
using System.Collections;

public class pointer : MonoBehaviour {

	public Transform startPos; // starting postiion of sight
	public Transform endPos; // End position of sight
	public Transform pointRotate; // The transform of the point
	public float timeToAnswer; // The time that must elapse until a question is considered to be answered.
	public float timeReset;
	public bool questionAnswered; // Becomes true if a question is answered.

	public bool yes;
	public bool no;
	public bool answered;
	// Use this for initialization
	void Start ()
	{
		timeReset = timeToAnswer;
		pointRotate = transform.FindChild ("point"); // Gets the transform of the point.
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
		Interaction ();
	}

	void Raycasting () // Controls the raycasts
	{
		yes = Physics.Linecast (startPos.position, endPos.position, 1 << LayerMask.NameToLayer ("Yes"));
		no = Physics.Linecast (startPos.position, endPos.position, 1 << LayerMask.NameToLayer ("No"));
		Debug.DrawLine (startPos.position, endPos.position, Color.green); // Draws a line in the scene to see how far the players view point is
	}

	void Interaction () // Controls what happens when the player interacts
	{
		if (yes == true || no == true) // If the user is looking at an interactable object the point will rotate giving the player a visual that they are interacting with something. 
		{ 					
			pointRotate.Rotate (0, 0, 10); // rotates the point on the z axis.
			timeToAnswer -= Time.deltaTime;
		} 

		else // If the player looks away the value will revert back to the original time. 
		{ 
			timeToAnswer = timeReset;
			questionAnswered = false;
		}

		if (timeToAnswer <= 0.0f) { // if the player looks at a question for the set duration it will be considered as there intentional answer. 
			questionAnswered = true;
			timeToAnswer = timeReset;
			print ("Responded");
		} else {
			questionAnswered = false;
		}
	}
		
}
