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
            GetComponent<AudioSource>().Play();
            Invoke("LoadMain", GetComponent<AudioSource>().clip.length);                
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("LoadMain", GetComponent<AudioSource>().clip.length);                
        }
    }

    void LoadMain()
    {
        Application.LoadLevel(level);
    }
}
