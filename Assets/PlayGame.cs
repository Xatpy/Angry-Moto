using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

    public GameObject cameraPlay;
    public GameObject playGO;

    public GameObject cameraGameOver;
    public GameObject gameOverGO;

    public string nameScene = "Game";

    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("vamos");
        //Camera.main.GetComponent<AudioSource>().Stop();
        //GetComponent<AudioSource>().Play();
        //Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
        Invoke("CargarNivelJuego", 0.5f);
    }

    void CargarNivelJuego()
    {
        Application.LoadLevel(nameScene);       
    }
}
