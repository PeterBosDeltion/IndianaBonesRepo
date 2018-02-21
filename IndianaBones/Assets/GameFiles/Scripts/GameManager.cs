using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour {

	public AudioMixer mainMixer;
	public static GameManager gm;
	public int gameQualityIndex;
	public Resolution resolution;
	public bool screenMode = true;

	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
		if (gm == null)
		{
		gm = this;
		}
		else if (gm != null && gm != this)
		{
			Destroy(gameObject);
		}
	}
	public static void ChangeScene(int i)
	{
		SceneManager.LoadScene(i);	
	}
	
	public static void Quit()
	{
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}

	public static void ToggleTimeScale()
	{
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void GameVolume(float volume)
	{
		mainMixer.SetFloat("MasterVolume",volume);
	}

	public void QualityOptionsUpdate()
	{
		Screen.fullScreen = screenMode;
		QualitySettings.SetQualityLevel(gameQualityIndex);
		Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
	}
}
