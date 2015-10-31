using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    void OnMouseDown()
    {
        Debug.Log("fuera");
        GetComponent<AudioSource>().Play();
        Invoke("ExitApp", GetComponent<AudioSource>().clip.length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("ExitApp", GetComponent<AudioSource>().clip.length);
        }
    }

    void ExitApp()
    {
        Application.Quit();
    }
}
