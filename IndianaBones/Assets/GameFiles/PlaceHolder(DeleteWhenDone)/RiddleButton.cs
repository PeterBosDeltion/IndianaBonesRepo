using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleButton : MonoBehaviour {
    public TriggerdObjects obj;
    private GameObject p;
    private bool cool;
    // Use this for initialization
    void Start () {
          p = GetComponentInParent<ObjectDescriptor>().gameObject;

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("E") && !cool)
        {
          obj.GetComponent<PrototypeRiddle>().orderPressed.Add(gameObject);
            StartCoroutine(Pressed());
        }
    }

    IEnumerator Pressed()
    {
        cool = true;
        p.GetComponent<Renderer>().material.color = Color.gray;
        yield return new WaitForSeconds(2);
        p.GetComponent<Renderer>().material.color = Color.red;
        cool = false;
    }
}
