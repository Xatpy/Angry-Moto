using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;			//	The rigidbody of the projectile
	public float resetSpeed = 0.025f;		//	The angular velocity threshold of the projectile, below which our game will reset
	
	private float resetSpeedSqr;			//	The square value of Reset Speed, for efficient calculation
	private SpringJoint2D spring;			//	The SpringJoint2D component which is destroyed when the projectile is launched

	public GameObject projectileGameObject;

	public int lifes = 3;
	
	public List<GameObject> lifesArrayGO;

	public Rigidbody2D rigidCatapult;

	void Start ()
	{
		//	Calculate the Resset Speed Squared from the Reset Speed
		resetSpeedSqr = resetSpeed * resetSpeed;

		//	Get the SpringJoint2D component through our reference to the GameObject's Rigidbody
		spring = projectile.GetComponent <SpringJoint2D>();

		Debug.Log ("start");
	}
	
	void Update () {
		//	If we hold down the "R" key...
		if (Input.GetKeyDown (KeyCode.R)) {
			//	... call the Reset() function
			Reset ();
		}

		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
			//	... call the Reset() function
			//Reset ();
			ResetNewProjectile();
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		//	If the projectile leaves the Collider2D boundary...
		//if (other.GetComponent<Rigidbody2D> () == projectile) {
		if (other.tag == "Damager")
		{
			//	... call the Reset() function
			//Reset ();
			Debug.Log("entró");
			Debug.Log (other.tag);
			Debug.Log (other.GetComponent<Rigidbody2D>());
			
			lifes--;
			LogicLifes ();
			if (lifes > 0) {
				ResetNewProjectile ();
			} else {
				Debug.Log ("Game over");
			}
		} else {
			Debug.Log ("algo entro");
			Debug.Log (other.tag);
			Debug.Log (other.GetComponent<Rigidbody2D>());
		}
	}

	void LogicLifes()
	{
		Debug.Log ("LOGIF LIFES: " + lifes);
		switch (lifes)
		{
			case 0:
				lifesArrayGO[0].SetActive(false);
				lifesArrayGO[1].SetActive(false);
				lifesArrayGO[2].SetActive(false);
			break;
			case 1:
				lifesArrayGO[0].SetActive(true);
				lifesArrayGO[1].SetActive(false);
				lifesArrayGO[2].SetActive(false);
			break;
			case 2:
				lifesArrayGO[0].SetActive(true);
				lifesArrayGO[1].SetActive(true);
				lifesArrayGO[2].SetActive(false);
			break;
			case 3:
				lifesArrayGO[0].SetActive(true);
				lifesArrayGO[1].SetActive(true);
				lifesArrayGO[2].SetActive(true);
			break;
		}
	}

	void ResetNewProjectile()
	{
		//projectileGameObject.transform.position = new Vector3 (-12.72f, -5.57f, 0.0f);
		//projectile.isKinematic = true;
		Debug.Log ("Reset new projectile");
		GameObject a = (GameObject)Instantiate (projectileGameObject, new Vector3 (-12.72f, -5.57f, 0.0f), Quaternion.identity);
		/*Debug.Log ("b");
		a.AddComponent<SpringJoint2D> ();
		SpringJoint2D spring = a.GetComponent <SpringJoint2D>();
		Debug.Log ("jaime " + a.name);
		Debug.Log ("c");
		//a.GetComponent <SpringJoint2D>();
		spring.connectedBody = rigidCatapult;
		Debug.Log ("vamos");*/
	}
	
	void Reset () {
		//	The reset function will Reset the game by reloading the same level
		Debug.Log ("empezamos");
		Application.LoadLevel (Application.loadedLevel);
	}
}
