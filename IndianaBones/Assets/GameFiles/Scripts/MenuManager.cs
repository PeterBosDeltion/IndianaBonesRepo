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
		if(move == true)
		{
			Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,new Vector3(490, 210, 700),800 * Time.deltaTime);
		}
		else
		{
			Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,new Vector3(490, 210, -300),800 * Time.deltaTime);
		}
	}
	public void PlayGame()
	{
		GameManager.ChangeScene(1);
	}

	public void Options()
	{
		move = true;
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
		GameManager.gm.gameQualityIndex = qualityIndex;
	}

	public void ChangeReselution(int resolutionIndex)
	{
		GameManager.gm.resolution = reselutions[resolutionIndex];
	}
	public void AcceptUIOptions()
	{
		GameManager.gm.QualityOptionsUpdate();
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

	public void BackToMenu()
	{
		move = false;
	}
}
