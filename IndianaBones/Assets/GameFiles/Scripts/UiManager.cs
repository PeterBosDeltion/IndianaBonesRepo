using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour {

	public enum UiState
	{
		Main,
		Pause,
		Options
	}

	public Resolution[] reselutions;
	public TMP_Dropdown resolutionDropdown;
	public GameObject lastPannel;
	public UiState uiState;
	public Player player;
	public GameObject mainPannel;
	public GameObject pauseMenuPannel;
	public GameObject optionsPannel;
	public TextMeshProUGUI milkCount;
	public TextMeshProUGUI bonesCount;
	public TextMeshProUGUI coinCount;
	public GameObject keyImage;
	//deze list word gevuld met geinstantiate plaatjes die de max lives voorstellen (instantiation proses nog neit geprogameerd momenteel placeholder voor prototype)
	public List<GameObject> lifes = new List<GameObject>();
	public Sprite emptyHeart;
	public Sprite fullHeart;
	private GameManager gameManager;


	void Start()
	{
		gameManager = GameObject.FindObjectOfType<GameManager>();
		lastPannel = mainPannel;
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		UpdateValues();

		resolutionDropdown.ClearOptions();
		reselutions = Screen.resolutions;
		List<string> options = new List<string>();
		int currentRes = 0;
		int myRes = 0;
		foreach(Resolution res in reselutions)
		{
			options.Add(res.width + "X" + res.height);
			currentRes += 1;
			if(res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height)
			{
				myRes = currentRes;
			}
		}
		
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = myRes;
		resolutionDropdown.RefreshShownValue();
	}
	void Update()
	{
		if(Input.GetButtonDown("ESC"))
		{
			print("ok");
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
		ChangePannel();
	}

	public void ChangePannel()
	{
		if(uiState == UiState.Main)
		{
			lastPannel.SetActive(false);
			mainPannel.SetActive(true);
			lastPannel = mainPannel;
			GameManager.ToggleTimeScale();
		}
		if(uiState == UiState.Pause)
		{
			lastPannel.SetActive(false);
			pauseMenuPannel.SetActive(true);
			if(lastPannel == mainPannel)
			{
				GameManager.ToggleTimeScale();
			}
			lastPannel = pauseMenuPannel;
		}
		
		if(uiState == UiState.Options)
		{
			lastPannel.SetActive(false);
			optionsPannel.SetActive(true);
			lastPannel = optionsPannel;
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
		uiState = UiState.Main;
		ChangePannel();
	}
	public void Options()
	{
		uiState = UiState.Options;
		ChangePannel();
	}
	public void Quit()
	{
		GameManager.ChangeScene(0);
	}

	// Options menu hieronder
	public void ChangeReselution(int resolutionIndex)
	{
		gameManager.resolution = reselutions[resolutionIndex];
	}
	
	public void ChangeVolume(float volume)
	{
		gameManager.GameVolume(volume);
	}

	public void ChangeQuality(int qualityIndex)
	{
		gameManager.gameQualityIndex = qualityIndex;
	}

	public void ChangeScreenMode(int screenModeIndex)
	{
		print(screenModeIndex);
		if(screenModeIndex == 0)
		{
			gameManager.screenMode = true;
		}
		else if(screenModeIndex == 1)
		{
			gameManager.screenMode = false;
		}
	}

	public void AcceptUIOptions()
	{
		gameManager.QualityOptionsUpdate();
	}

	public void ReturnToOptionsMenu()
	{
		uiState = UiState.Pause;
		ChangePannel();
	}

	
}
