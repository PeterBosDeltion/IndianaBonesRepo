using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour {

	public enum UiState
	{
		Main,
		Pause
	}

	public GameObject lastPannel;
	public UiState uiState;
	public Player player;
	public GameObject mainPannel;
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
		lastPannel = mainPannel;
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		UpdateValues();
	}
	void Update()
	{
		if(Input.GetButtonDown("ESC"))
		{
			ChangeUiState();
		}
	}

	public void ChangeUiState()
	{
		if(uiState != UiState.Main)
		{
			uiState = UiState.Main;
		}
		else if(uiState == UiState.Main)
		{
			uiState = UiState.Pause;
		}
	}

	public void ChangePannel()
	{
		if(uiState == UiState.Main)
		{
			lastPannel.SetActive(false);
			mainPannel.SetActive(true);
			if(lastPannel == pauseMenuPannel)
			{
				GameManager.ToggleTimeScale();
			}
		}
		if(uiState == UiState.Pause)
		{
			lastPannel.SetActive(false);
			pauseMenuPannel.SetActive(true);
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
			print("ll");
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
