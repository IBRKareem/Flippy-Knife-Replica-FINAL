using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour {

	public Rigidbody rb;

	public float force = 5f;
	public float torque = 20f;

	private float timeFlying;

	private Vector2 startSwipe;
	private Vector2 endSwipe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!rb.isKinematic)
			return;
		
		if (Input.GetMouseButtonDown (0)) 
		{
			startSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		}
		if (Input.GetMouseButtonUp (0))
		{
			endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			Swipe ();
		}
	}

	void Swipe ()
	{
		rb.isKinematic = false;

		timeFlying = Time.time;

		Vector2 swipe = endSwipe - startSwipe;

		rb.AddForce (swipe * force, ForceMode.Impulse);
		rb.AddTorque (0f, 0f, -torque, ForceMode.Impulse);
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Block") {
			rb.isKinematic = true;
		} else 
		{
			Restart();
		}
	}

	void OnCollisionEnter ()
	{
		float timeInAir = Time.time - timeFlying;

		if (!rb.isKinematic && timeInAir >= .05f)
		{
			Restart();
		}
		if (rb.isKinematic )
		Score.scoreValue += 1;


	}

	void Restart ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Score.scoreValue = 0;
	}
}
