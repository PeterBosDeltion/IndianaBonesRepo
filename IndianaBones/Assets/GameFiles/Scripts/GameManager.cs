using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameManager : MonoBehaviour {

	public string filePath;
	public AudioMixer mainMixer;
	public static GameManager gm;
	public int gameQualityIndex;
	public int reselutionIndex;
	public Resolution resolution;
	public bool screenMode = true;
	public ToSave currentData;
    public GameObject fadeOut;

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
		reselutionIndex = Screen.resolutions.Length;
	}
	public void ChangeScene(int i)
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
		mainMixer.SetFloat("Master",volume);
	}

	public void GameVolumeMusic(float volume)
	{
		mainMixer.SetFloat("Music",volume);
	}
	public void GameVolumeEffects(float volume)
	{
		mainMixer.SetFloat("SoundEffects",volume);
	}
	public void QualityOptionsUpdate()
	{
		Screen.fullScreen = screenMode;
		QualitySettings.SetQualityLevel(gameQualityIndex);
		Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen = screenMode);
	}

	public void SaveGameState(ToSave template)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file;
		file = File.Create(Application.dataPath + filePath);
		ToSave savefile = template;
		print(template.coins);
		bf.Serialize(file,savefile);
		file.Close();
	}

	public void LoadGameState()
	{
		if(File.Exists(Application.dataPath + filePath))
		{
			print("load");
			ChangeScene(1);
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.dataPath + filePath, FileMode.Open);
			ToSave savefile = (ToSave)bf.Deserialize(file);
			currentData = savefile;
			file.Close();
		}
		else
		{
			ChangeScene(1);
		}
	}
	void OnApplicationQuit()
	{
#if UNITY_EDITOR
        File.Delete(Application.dataPath + filePath);
#else

#endif
	}
}

	

[System.Serializable]
public class ToSave
{
	public bool hasKey;
    public int currentLives = 3;
    public int maxLives = 3;
    public int coins;
    public int milk;
    public int bones;
	public bool[] finishedPath;
}
