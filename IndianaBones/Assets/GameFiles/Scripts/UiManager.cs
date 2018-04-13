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
            if(lastPannel != null && mainPannel != null)
            {
                lastPannel.SetActive(false);
                mainPannel.SetActive(true);
                lastPannel = mainPannel;
                GameManager.ToggleTimeScale();
            }
            else
            {
                Debug.LogError("Variable lastPannel or mainPannel is null, Script: UiManager");
            }
			
		}
		if(uiState == UiState.Pause)
		{
            if(lastPannel != null && pauseMenuPannel != null && mainPannel != null)
            {
                lastPannel.SetActive(false);
                pauseMenuPannel.SetActive(true);
                if (lastPannel == mainPannel)
                {
                    GameManager.ToggleTimeScale();
                }
                lastPannel = pauseMenuPannel;
            }
            else
            {
                Debug.LogError("Variable pauseMenuPannel, lastPannel or mainPannel is null, Script: UiManager");
            }

        }
		
		if(uiState == UiState.Options)
		{
            if(lastPannel != null && optionsPannel != null)
            {
                lastPannel.SetActive(false);
                optionsPannel.SetActive(true);
                lastPannel = optionsPannel;
            }
            else
            {
                Debug.LogError("Variable lastPannel or optionsPannel is null, Script: UiManager");
            }

        }
	}

	public void UpdateValues()
	{
        if(milkCount != null)
        {
            milkCount.text = "Milk : " + player.milk;
        }
        else
        {
            Debug.LogError("Variable milkCount is null, Script: UiManager");
        }
        if(bonesCount != null)
        {
            bonesCount.text = "Bones : " + player.bones;
        }
        else
        {
            Debug.LogError("Variable bonesCount is null, Script: UiManager");
        }
        if (coinCount != null)
        {
            coinCount.text = "Coins : " + player.coins;
        }
        else
        {
            Debug.LogError("Variable coinCount is null, Script: UiManager");
        }
        if (player.currentLives != player.maxLives)
		{
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
		GameManager.ToggleTimeScale();
		GameManager.gm.ChangeScene(0);
	}

	
	// Options Menu
	public void ChangeReselution(int resolutionIndex)
	{
        if(GameManager.gm != null)
        {
            GameManager.gm.resolution = reselutions[resolutionIndex];
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
        }
    }
	
	public void ChangeVolume(float volume)
	{
        if(GameManager.gm != null)
        {
            GameManager.gm.GameVolume(volume);
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
        }
	}

	public void ChangeVolumeMusic(float volume)
	{
        if(GameManager.gm != null)
        {
		    GameManager.gm.GameVolumeMusic(volume);
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
        }
    }

	public void ChangeVolumeEffects(float volume)
	{
        if(GameManager.gm != null)
        {
            GameManager.gm.GameVolumeEffects(volume);
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
        }
	}

	public void ChangeQuality(int qualityIndex)
	{
        if(GameManager.gm != null)
        {
            GameManager.gm.gameQualityIndex = qualityIndex;
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
        }
	}

	public void ChangeScreenMode(int screenModeIndex)
	{
		print(screenModeIndex);
		if(screenModeIndex == 0)
		{
            if(GameManager.gm != null)
            {
                GameManager.gm.screenMode = true;
            }
            else
            {
                Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
            }
		}
		else if(screenModeIndex == 1)
		{
            if(GameManager.gm != null)
            {
                GameManager.gm.screenMode = false;
            }
            else
            {
                Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
            }
		}
	}

	public void AcceptUIOptions()
	{
        if(GameManager.gm != null)
        {
            GameManager.gm.QualityOptionsUpdate();
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try starting from menu, Script: UiManager");
        }
	}

	public void ReturnToOptionsMenu()
	{
		uiState = UiState.Pause;
		ChangePannel();
	}

	
}
