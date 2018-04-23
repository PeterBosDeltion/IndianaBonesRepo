using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : TriggerdObjects {
    [Header("Own variables")]
    public GameObject emptyPos;
    public GameObject arrowPrefab;

    public float arrowSpeed;
    public float repeatinterval = 3;
    public bool repeat;

    private bool shooting;

    public AudioSource source;
    public AudioClip arrowClip;
    private GameManager gm;
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();

        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.volume = 0.1F;

        arrowClip = gm.arrowClip;

        source.clip = arrowClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        if (!shooting && repeat)
        {
            InvokeRepeating("Shoot", 1, repeatinterval);
            shooting = true;
        }
        else
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        source.Play();
        GameObject g = Instantiate(arrowPrefab, emptyPos.transform.position, transform.rotation);

        Rigidbody rb = g.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * arrowSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(g);
            Debug.LogError("Dart arrow prefab does not have rigidbody, Script:DartTrap");
        }
        Destroy(g, 4.0F);
    }
}
