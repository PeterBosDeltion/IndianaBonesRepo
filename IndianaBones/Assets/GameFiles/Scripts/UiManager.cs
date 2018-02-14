using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour {

	public Player player;
	public GameObject pauseMenuPannel;
	public TextMeshProUGUI milkCount;
	public TextMeshProUGUI bonesCount;
	public TextMeshProUGUI coinCount;
	public GameObject keyImage;
	//deze list word gevuld met geinstantiate plaatjes die de max lives voorstellen (instantiation proses nog neit geprogameerd momenteel placeholder voor prototype)
	public List<GameObject> lifes = new List<GameObject>();
	public Sprite emptyHeart;
	public Sprite fullHeart;


	void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	void Update()
	{
		if(Input.GetButtonDown("ESC") && !pauseMenuPannel.activeSelf)
		{
			print("ok");
			pauseMenuPannel.SetActive(true);
			GameManager.ToggleTimeScale();
		}
		else if(Input.GetButtonDown("ESC") && pauseMenuPannel.activeSelf)
		{
			print("ok2");
			pauseMenuPannel.SetActive(false);
			GameManager.ToggleTimeScale();
		}
	}

	public void UpdateValues()
	{
		milkCount.text = "Milk : " + player.milk;
		bonesCount.text = "Bones : " + player.bones;
		coinCount.text = "Coins : " + player.coins;
		if(player.currentLives != player.maxLives)
		{
			lifes[player.currentLives].GetComponent<UnityEngine.UI.Image>().sprite = emptyHeart;
		}
		if(player.hasKey == true)
		{
			keyImage.SetActive(true);
		}
		else
		{
			keyImage.SetActive(false);
		}
	}
	public void Resume()
	{
		pauseMenuPannel.SetActive(false);
		GameManager.ToggleTimeScale();
	}
	public void Options()
	{

	}
	public void Quit()
	{
		GameManager.ChangeScene(0);
	}
	

	
}
