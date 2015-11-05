using UnityEngine;
using System.Collections;

public class AchievePoints : MonoBehaviour {

    public TextMesh points;
    public TextMesh level;


	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "MarquezCatch");	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    int UpdateLevel()
    {
        int currentLevel = int.Parse(level.text.ToString());
        currentLevel++;
        level.text = currentLevel.ToString();
        return currentLevel;
    }

    void MarquezCatch(Notification notArgs)
    {       
        //Update scoreboards        
        int level = UpdateLevel();
        int pointsReceived = (int)notArgs.data;
        int totalPoints = level * pointsReceived;

        points.text = totalPoints.ToString();        
    }
}
