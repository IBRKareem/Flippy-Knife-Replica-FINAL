using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public Rigidbody rb;

	private Vector2 startSwipe;
	private Vector2 endSwipe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			startSwipe = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0))
		{
			endSwipe = Input.mousePosition;
			Swipe ();
		}
	}

	void Swipe ()
	{
		Vector2 swipe = endSwipe - startSwipe;

		rb.AddForce (swipe, ForceMode.Impulse);

	}
}
