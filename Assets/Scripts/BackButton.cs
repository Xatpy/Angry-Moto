using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

    public string level = "Main";
    void OnMouseDown()
    {
        Debug.Log("vamos");
        //Camera.main.GetComponent<AudioSource>().Stop();
        //GetComponent<AudioSource>().Play();    void OnMouseDown()
        {
            //Camera.main.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);                
            //Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
            //Invoke("LoadMain", 0.5f);
        }
    }

    void LoadMain()
    {
        Application.LoadLevel(level);
    }
}
