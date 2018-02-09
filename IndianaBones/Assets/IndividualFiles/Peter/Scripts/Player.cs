using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int currentLives;
    public int maxLives;
    public int coins;
    public int milk;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Death()
    {
        if(currentLives <= 0)
        {
            Debug.Log("Git gud u fucking casul scrub");
        }
        else if(currentLives > 0)
        {
            currentLives -= 1;
            //Go reset to the bathroom or something
        }
    }

    public void DrinkMilk()
    {
        if(currentLives < maxLives)
        {
            currentLives += 1;
        }
    }

    public void ConsumeBone()
    {
        maxLives += 1;
    }
}
