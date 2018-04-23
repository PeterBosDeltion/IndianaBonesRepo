using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : TriggerdObjects {

	public GameObject fadeToWhite;
	public GameObject fadeToWhiteText;
	public PlayerMovement playerMovement;

	void Start()
	{
		playerMovement = FindObjectOfType<PlayerMovement>();
	}
	void OnTriggerEnter(Collider other)
	{
		TriggerFunctionality();
	}
	public override void TriggerFunctionality()
	{
		playerMovement.enabled = false;
		fadeToWhite.SetActive(true);
		fadeToWhite.GetComponent<Animator>().SetTrigger("Fade");
		StartCoroutine(TheEnd());
	}
	public IEnumerator TheEnd()
	{
		yield return new WaitForSeconds(3);
		print("fade tet");
		fadeToWhiteText.GetComponent<Animator>().SetTrigger("Fade");
		yield return new WaitForSeconds(5);
		GameManager.gm.DeleteSave();
		GameManager.gm.ChangeScene(0);
	}
}
