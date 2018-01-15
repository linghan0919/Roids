using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Vector3 forceVector;
	public float rotationSpeed;
	public float rotation;

	// Use this for initialization
	void Start () {
		forceVector.x = 1.0f;
		rotationSpeed = 2.0f;
	}

	// Add forced changes to rigid body physics parameters
	void FixedUpdate() {
		// force thrust
		if (Input.GetAxisRaw ("Vertical") > 0) {
			GetComponent<Rigidbody>().AddRelativeForce(forceVector);
		}

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			rotation += rotationSpeed;
			Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
			GetComponent<Rigidbody>().MoveRotation(rot);
		}
		else if (Input.GetAxisRaw ("Horizontal") < 0) {
			rotation -= rotationSpeed;
			Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
			GetComponent<Rigidbody>().MoveRotation(rot);
		}
	}

	public GameObject bullet;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log("Fire! " + rotation);

			Vector3 spawnPos = gameObject.transform.position;
			spawnPos.x += 1.5f * Mathf.Cos (rotation*Mathf.PI/180);
			spawnPos.z -= 1.5f * Mathf.Sin (rotation*Mathf.PI/180);

			GameObject obj = Instantiate (bullet, spawnPos, Quaternion.identity) as GameObject;

			Bullet b = obj.GetComponent<Bullet>();
			Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
			b.heading = rot;
		}
	}
}
