using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour {

	public enum UiState
	{
		Main,
		Pause,
		Options
	}

	public Slider sliderMain;
	public Slider sliderMusic;
	public Slider sliderEffects;
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
	//deze list word gevuld met geinstantiate plaatjes die de max lives voorstellen (instantiation proses nog niet geprogameerd momenteel placeholder voor prototype)
	public List<GameObject> lifes = new List<GameObject>();
	public Sprite emptyHeart;
	public GameObject fullHeart;
	public GameObject healthPannel;
	public float audioValue;


	void Start()
	{
		if(mainPannel.activeSelf)
		{
			lastPannel = mainPannel;
		}
		else if(pauseMenuPannel.activeSelf)
		{
			lastPannel = pauseMenuPannel;
		}
		else if(optionsPannel.activeSelf)
		{
			lastPannel = optionsPannel;
		}
		else if(lastPannel == null)
		{
			lastPannel = pauseMenuPannel;
		}
		uiState = UiState.Main;
		ChangePannel();
		GameManager.ToggleTimeScale();
		lastPannel = mainPannel;
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		UpdateValues();
		while(lifes.Count != player.maxLives)
		{
			AddLive();
		}
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

		GameManager.gm.mainMixer.GetFloat("Master",out audioValue);
		sliderMain.value = audioValue;
		GameManager.gm.mainMixer.GetFloat("Music",out audioValue);
		sliderMusic.value = audioValue;
		GameManager.gm.mainMixer.GetFloat("SoundEffects",out audioValue);
		sliderEffects.value = audioValue;
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
        if(milkCount != null)
        {
            milkCount.text = "Milk : " + player.milk;
        }
        if(bonesCount != null)
        {
            bonesCount.text = "Bones : " + player.bones;
        }
        if(coinCount != null)
        {
            coinCount.text = "Coins : " + player.coins;
        }
        if (player.currentLives != player.maxLives)
		{
			print("ll");
            if(lifes.Count > 0)
            {
                lifes[player.currentLives].GetComponent<UnityEngine.UI.Image>().sprite = emptyHeart;
            }
        }
		if(player.hasKey == true)
		{
            if(keyImage != null)
            {
                keyImage.SetActive(true);
            }
        }
		else
		{
            if(keyImage != null)
            {
                keyImage.SetActive(false);
            }
        }
	}

	public void AddLive()
	{
		lifes.Add(Instantiate(fullHeart,healthPannel.transform.position,Quaternion.identity));
		lifes[lifes.Count-1].transform.SetParent(healthPannel.transform);
	}

	//Pause Menu
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
		GameManager.gm.ChangeScene(0);
	}

	
	// Options Menu
	public void ChangeReselution(int resolutionIndex)
	{
		GameManager.gm.resolution = reselutions[resolutionIndex];
	}
	
	public void ChangeVolume(float volume)
	{
		GameManager.gm.GameVolume(volume);
	}

	public void ChangeVolumeMusic(float volume)
	{
		GameManager.gm.GameVolumeMusic(volume);
	}

	public void ChangeVolumeEffects(float volume)
	{
		GameManager.gm.GameVolumeEffects(volume);
	}

	public void ChangeQuality(int qualityIndex)
	{
		GameManager.gm.gameQualityIndex = qualityIndex;
	}

	public void ChangeScreenMode(int screenModeIndex)
	{
		print(screenModeIndex);
		if(screenModeIndex == 0)
		{
			GameManager.gm.screenMode = true;
		}
		else if(screenModeIndex == 1)
		{
			GameManager.gm.screenMode = false;
		}
	}

	public void AcceptUIOptions()
	{
		GameManager.gm.QualityOptionsUpdate();
	}

	public void ReturnToOptionsMenu()
	{
		uiState = UiState.Pause;
		ChangePannel();
	}

	
}
