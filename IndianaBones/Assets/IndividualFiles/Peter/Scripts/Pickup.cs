using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public enum Type
    {
        Coin,
        Bone,
        Milk
    }

    public Type type;
    public AudioSource source;
    public AudioClip coinFall;
    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();

        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        coinFall = gm.coinFall;
        source.clip = coinFall;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player p = other.GetComponent<Player>();
            if(type == Type.Coin)
            {
                source.Play();

                p.coins += 1;
                SaveTrigger.coinsSave += 1;
            }
            else if (type == Type.Bone)
            {
                p.bones += 1;
                SaveTrigger.bonesSave += 1;
            }
            else if (type == Type.Milk)
            {
                p.milk += 1;
                SaveTrigger.milkSave += 1;
            }
            FindObjectOfType<UiManager>().UpdateValues();
            Destroy(gameObject);
        }
    }
}
