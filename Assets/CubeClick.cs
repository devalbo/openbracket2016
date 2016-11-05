using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using GvrController;

public class Germ {

	public Vector3 Position;
	public Vector3 Rotation;

	public float Speed;
	public GameObject GameObject;

	public Germ(GameObject gameObject) {
		GameObject = gameObject;
	}
}

public class CubeClick : MonoBehaviour {

	public Vector3 startPosition = new Vector3(0, 0, 75);

	public GameObject Germ1;
	private float startTimer;
	public float delayTimer;

	public List<Germ> germs;

	public float speed;
	public float tilt;
//	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	Vector3 ZeroPosition = new Vector3(0, 0, 0);

	private System.Random random = new System.Random();

	// Use this for initialization
	void Start () {
		germs = new List<Germ>();
		transform.position = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
//			nextFire = Time.time + fireRate;
			//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

//		}

		//if (Input.GetKeyDown (KeyCode.A)) {

		//if (Cardboard.SDK.CardboardTriggered) {

/*
 * 		if (GvrController.ClickButton) {
			foreach (var germ in germs) {
				Destroy (germ.GameObject);
				germ.GameObject = null;
			}
			germs.Clear ();
		}
	*/


		startTimer += Time.deltaTime;
		if (startTimer >= delayTimer) {
			startTimer = 0;
			var startPosition = GetRandomStartPosition ();
			GameObject tempItem = (GameObject)Instantiate (Germ1, startPosition, transform.rotation);
			var newGerm = new Germ (tempItem);
			germs.Add (newGerm);
		}


    }

    void FixedUpdate()
    {
		//transform.position += Vector3.forward * Time.deltaTime * 5;
		foreach (var germ in germs) {
			//germ.GameObject.transform.position -= Vector3.forward * Time.deltaTime * 5;
			germ.GameObject.transform.position = Vector3.Lerp(germ.GameObject.transform.position, transform.position, Time.deltaTime * 1);
			if (germ.GameObject.transform.position == ZeroPosition) {
				Destroy (germ.GameObject);
				germ.GameObject = null;
			}
		}

		germs = germs.Where(g => g.GameObject != null).ToList();
    }

	Vector3 GetRandomStartPosition() {
		var x = (float)random.Next (50, 100);
		var y = (float)random.Next (50, 100);
		var z = (float)random.Next (50, 100);
		return new Vector3 (x, y, z);
	}
}
