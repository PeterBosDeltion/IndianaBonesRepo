using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

	public bool move;
	public Slider sliderMain;
	public Slider sliderMusic;
	public Slider sliderEffects;
	public AudioClip loop;
	public AudioSource audioSource;
	public Resolution[] reselutions;
	public TMP_Dropdown resolutionDropdown;
	public float audioValue;
	public Animator cameraAnimator;
	public Animator cascetAnimator;
	public GameObject fadeOut;

	public Resolution currentRes;
	public int currentResIndex;
	public int currentQualityIndex;
	public bool currentScreenMode;

	void Start()
	{
		audioSource.Play();
		GameManager.gm = GameObject.FindObjectOfType<GameManager>();
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
		if(audioSource.isPlaying == false && audioSource.clip.name == "IndianaBonesStart")
		{
			audioSource.clip = loop;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void UIButton(int i)
	{
		if(i == 0)
		{
			cameraAnimator.SetTrigger("Play");
			cascetAnimator.SetTrigger("Open");
			StartCoroutine(Play());
		}
		if(i == 1)
		{
			cameraAnimator.SetTrigger("Options");
		move = true;
		}
		if(i == 2)
		{
			cameraAnimator.SetTrigger("Exit");
		}
		
	}
	public void PlayGame()
	{
		GameManager.gm.LoadGameState();
	}

	public void Quit()
	{
		GameManager.Quit();
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
		currentQualityIndex = qualityIndex;
	}

	public void ChangeReselution(int resolutionInd)
	{
		currentRes = reselutions[resolutionInd];
		currentResIndex = resolutionInd;
	}
	public void AcceptUIOptions()
	{
		GameManager.gm.screenMode = currentScreenMode;
		GameManager.gm.gameQualityIndex = currentQualityIndex;
		GameManager.gm.resolution = currentRes;
		GameManager.gm.reselutionIndex = currentResIndex;
		GameManager.gm.QualityOptionsUpdate();
	}

	public void ChangeScreenMode(int screenModeIndex)
	{
		if(screenModeIndex == 0)
		{
			currentScreenMode = true;
		}
		else if(screenModeIndex == 1)
		{
			currentScreenMode = false;
		}
	}

	public void BackToMenu()
	{
		cameraAnimator.SetTrigger("Back");
	}
	public IEnumerator Play()
	{
		fadeOut.SetActive(true);
		fadeOut.GetComponent<Animator>().SetTrigger("Fade");
		yield return new WaitUntil(()=>fadeOut.GetComponent<Image>().color.a==1);
		PlayGame();
	}
}
