using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameFlow : MonoBehaviour {

    public int lifes = 3;
    public List<GameObject> lifesArrayGO;
    public GameObject catapultPrefab;
    public GameObject targetPrefab;
    public GameObject circuit;

    public TextMesh levelText;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "NewRoundBeforeSuccess");
        NotificationCenter.DefaultCenter().AddObserver(this, "NewRoundBeforeFail");				
	}

    void NewRoundBeforeSuccess()
    {
        //Debug.Log("NewRoundBeforeSuccess");
        ResetNewTarget();
        ResetNewCatapult();
    }

    void NewRoundBeforeFail()
    {
        //Debug.Log("NewRoundBeforeFail");
        lifes--;
        LogicLifes();
        if (lifes > 0)
        {
            ResetNewCatapult();
        }
        else
        {
            //Debug.Log("Game over");
            NotificationCenter.DefaultCenter().PostNotification(this, "GameOver");
        }    
    }

    void LogicLifes()
    {       
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

    void ResetNewTarget()
    {
        GameObject target = (GameObject)Instantiate(targetPrefab, new Vector3(5.8f, 4.5f, 0.0f), Quaternion.identity);
        target.transform.parent = circuit.transform;
        SetSpeed(target);
    }

    void SetSpeed(GameObject go)
    {
        int level = int.Parse(levelText.text);
        float speed = go.GetComponent<Animator>().speed;
        speed += (1.5f * level);
        go.GetComponent<Animator>().speed = speed;
    }

    void ResetNewCatapult()
    {
        Instantiate(catapultPrefab, new Vector3(-12.72f, -5.57f, 0.0f), Quaternion.identity);
    }
}
