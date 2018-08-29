using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFunctions : MonoBehaviour {
    private string MainScene = "MainScene";
    private string StartScene = "LoadScene";
    private string GGScene = "GGScene";

    public GameObject EventListener;
	// Use this for initialization
	void Start () {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GGScene"));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchtoMainScene()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void SwitchtoGGScene()
    {
        SceneManager.LoadScene(GGScene);
    }
}
