using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public PuzzleManager puzzleManager;
	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();
    public bool pressurePlate;
	public GameObject shadedObject;
	//refrence naar type in player script
	public int interactionType;

	public bool triggersPuzzlePart;

	public new ParticleSystem particleSystem;
	public static bool interacting;
	private GameObject collisionOther;
    private bool colliding;
	private bool cantAnimate;

    public bool hasFocus;

    private bool partPlaying;

	public bool klickParticalOn;
	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
	    foreach (ParticleSystem p in FindObjectOfType<Player>().GetComponentsInChildren<ParticleSystem>())
		{
			if(p.name == "ClickTextEffect")
			{
				particleSystem = p;
			}
		}
	}

    
	public void Trigger()
	{	
		foreach(TriggerdObjects trigger in toTrigger)
		{
            if(trigger != null)
            {
                trigger.TriggerFunctionality();
				cantAnimate = trigger.triggerd;
            }
        }
	}

    void Update()
    {
		if(interacting == false && colliding)
		{
			if (collisionOther.GetComponent<Animator>().GetBool("Idle") == true)
			{
				if (Input.GetButtonDown("E"))
				{
					interacting = true;
					if(!cantAnimate)
					{
						if (interactionType == 1)
						{
							if(klickParticalOn == true)
							{
								particleSystem.Clear();
                            	particleSystem.Play();
							}
						}
						Player.Interact(interactionType);
					}
                    if (triggersPuzzlePart)
					{
						puzzleManager.triggers = toTrigger.Count;
					}
                    if (!hasFocus)
                    {
                        StartCoroutine(FindObjectOfType<Player>().RestartMovement());
                    }
                    else
                    {
                        interacting = false;
                    }
					Trigger();
                }
            }
		}
    }

    public void OnTriggerEnter(Collider other)
    {
		print("collisison check");
        if (pressurePlate && other.transform.tag == "Player")
        {
			collisionOther = other.transform.gameObject;
			colliding = true;
            Trigger();
        }
	    if(other.transform.gameObject.tag == "Player")
		{
			collisionOther = other.transform.gameObject;
			colliding = true;
			if(shadedObject != null)
			{
				if(shadedObject.GetComponent<TriggerdObjects>().outlineMat != null)
				{
					shadedObject.GetComponent<TriggerdObjects>().OutlineShaderToggle();
				}
			}
		}
	}
	public void OnTriggerExit(Collider other)
	{
		if(other.transform.gameObject.tag == "Player")
		{
            colliding = false;
			if(shadedObject != null && shadedObject.GetComponent<TriggerdObjects>().outlineMat != null)
			{
				shadedObject.GetComponent<TriggerdObjects>().OutlineShaderToggle();
			}
		}	
	}

}
