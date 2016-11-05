using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public Vector3 startPosition = new Vector3(0, 0, 25);

	public GameObject Germ1;
	private float startTimer;
	public float delayTimer;

	public List<Germ> germs;

	// Use this for initialization
	void Start () {
		germs = new List<Germ>();
		transform.position = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Destroy (Germ1);
		}

		startTimer += Time.deltaTime;
		if (startTimer >= delayTimer) {
			startTimer = 0;
			GameObject tempItem = (GameObject)Instantiate (Germ1, startPosition, transform.rotation);
			var newGerm = new Germ (tempItem);
			germs.Add (newGerm);
		}


    }

    void FixedUpdate()
    {
		//transform.position += Vector3.forward * Time.deltaTime * 5;
		foreach (var germ in germs) {
			germ.GameObject.transform.position += Vector3.forward * Time.deltaTime * 5;
		}
    }
}
