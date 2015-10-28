using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

	public Sprite damagedSprite;				//	The reference to our "damaged" sprite
	public float damageImpactSpeed;				//	The speed threshold of colliding objects before the target takes damage

    public Vector3 catapultPosition = new Vector3(-12.72f, -5.57f, 0.0f);
	
	private int currentHitPoints;				//	The current amount of health our target has taken
	private float damageImpactSpeedSqr;			//	The square value of Damage Impact Speed, for efficient calculation
	private SpriteRenderer spriteRenderer;		//	The reference to this GameObject's sprite renderer

    public AudioClip itemSoundClip;
    public float itemSoundVolume = 1f;

    public int points = 0;

	void Start () {
		//	Get the SpriteRenderer component for the GameObject's Rigidbody
		spriteRenderer = GetComponent <SpriteRenderer> ();

		//	Calculate the Damage Impact Speed Squared from the Damage Impact Speed
		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		//	Check the colliding object's tag, and if it is not "Damager", exit this function
		if (collision.collider.tag != "Damager")
			return;
		
		//	Check the colliding object's velocity's Square Magnitude, and if it is less than the threshold, exit this function
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
			return;

        Catched(collision);       
	}

    int GetPuntuation(Vector3 collisionPosition)
    {
        Vector3 distance = collisionPosition - catapultPosition;
        return (int)distance.magnitude;
    }

    void Catched(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);

        points += GetPuntuation(collision.transform.position);

        NotificationCenter.DefaultCenter().PostNotification(this, "MarquezCatch", points);
        NotificationCenter.DefaultCenter().PostNotification(this, "NewRoundBeforeSuccess");        
        
        // Possible solution: kill myself
        // Destroy(this.gameObject.transform.parent.gameObject);

        this.gameObject.layer = 1;
        collision.gameObject.transform.parent.gameObject.tag = "customized";

        // Deactivate animation
        Animator an = this.gameObject.transform.parent.gameObject.GetComponent<Animator>();
        an.speed = 0;

        StartCoroutine(WaitAndDie()); 

        Destroy(collision.gameObject.transform.parent.gameObject);
        return;
    }
	
	void Kill () {
		//	As the particle system is attached to this GameObject, when Killed, switch off all of the visible behaviours...
		spriteRenderer.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().isKinematic = true;

		//	... and Play the particle system
		GetComponent<ParticleSystem>().Play();
	}

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(3.0f);
        //Debug.Log("muero");
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
