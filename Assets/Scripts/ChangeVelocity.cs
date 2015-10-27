using UnityEngine;
using System.Collections;

public class ChangeVelocity : MonoBehaviour {

    public Animation anim;
    public AnimationClip st;
    public RuntimeAnimatorController animclasss;
    public Animator animador;
    public int abcde;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //st.speed += 0.1f;      
        animador.speed += 0.5f;
	}
}
