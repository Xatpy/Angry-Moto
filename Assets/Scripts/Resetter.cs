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


	void Start ()
	{
		//	Calculate the Resset Speed Squared from the Reset Speed
		resetSpeedSqr = resetSpeed * resetSpeed;

		//	Get the SpringJoint2D component through our reference to the GameObject's Rigidbody
		spring = projectile.GetComponent <SpringJoint2D>();

		//Debug.Log ("start");
	}
	
	void Update () {
		//	If we hold down the "R" key...
		if (Input.GetKeyDown (KeyCode.R)) {
			//	... call the Reset() function
			Reset ();
		}

		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (spring == null && projectile != null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
			//	... call the Reset() function
			//Reset ();
			ResetNewProjectile();
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Damager")
		{
            Debug.Log("posteando");
            NotificationCenter.DefaultCenter().PostNotification(this, "NewRoundBeforeFail");
            Destroy(other.gameObject.transform.parent.gameObject);
		}
	}

	void LogicLifes()
	{
		//Debug.Log ("LOGIc LIFES: " + lifes);
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
		Instantiate (projectileGameObject, new Vector3 (-12.72f, -5.57f, 0.0f), Quaternion.identity);
	}
	
	void Reset () {
		Application.LoadLevel (Application.loadedLevel);
	}
}
