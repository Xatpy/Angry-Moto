using UnityEngine;
using System.Collections;

public class ActivateGameOver : MonoBehaviour {

    public GameObject camaraGameOver;
    public AudioClip gameOverClip;

    public GameObject sceneGame;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "GameOver");	
	}

    void GameOver(Notification notificacion)
    {
        /*GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = gameOverClip;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();*/
        camaraGameOver.SetActive(true);

        if (sceneGame)
        {
            sceneGame.SetActive(false);
        }
    }

    void Update()
    {

    }
}
