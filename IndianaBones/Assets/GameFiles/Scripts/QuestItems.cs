using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItems : MonoBehaviour {

    // 0 = Hat
    // 1 = Whip
    public int QuestItem;
	public SaveTrigger mySave;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("triggerquest");
            mySave.finishedPathSave[QuestItem] = true;
            Destroy(gameObject);
        }
    }
}
