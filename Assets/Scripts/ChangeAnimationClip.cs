using UnityEngine;
using System.Collections;

public class ChangeAnimationClip : MonoBehaviour {

    public Animator animator;
    int cont;
	// Use this for initialization
	void Start () {
        cont = 0;
	}
	
	// Update is called once per frame
	void Update () {
        cont++;
        if (cont > 100)
            animator.Play("MediumCircuitAnimation");
	}
}
