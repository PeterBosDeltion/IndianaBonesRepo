using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public string filePath;
	public AudioMixer mainMixer;
	public static GameManager gm;
	public int gameQualityIndex;
	public int reselutionIndex;
	public Resolution resolution;
	public bool screenMode = true;
	public ToSave currentData;

    public GameObject controlsImage;
    public GameObject fadeOut;
	AsyncOperation async;
	public float loadingProgress;
	public bool loading;

    public AudioClip buttonClick;

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

    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            controlsImage.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            controlsImage.SetActive(false);
        }
    }

	public void ChangeScene(int i)
	{
		async = SceneManager.LoadSceneAsync(i);	
		async.allowSceneActivation = false;
		StartCoroutine(LoadingScreen());
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

	public IEnumerator LoadingScreen()
	{
		loading = true;
		while (async.isDone == false)
		{
			loadingProgress = async.progress;
			if(async.progress == 0.9f)
			{
				loadingProgress = 1;
				loading = false;
				async.allowSceneActivation = true;
			}
			yield return null;
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
