using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoader : MonoBehaviour 
{

	public void NextScence()
	{
		Scene CurrentScene = SceneManager.GetActiveScene();         // <GetActiveScene()> returns scene and 
		SceneManager.LoadScene(CurrentScene.buildIndex + 1);        // <buildIndex> returns index of scene.

	}

	public void LoadStart() 
	{
		FindObjectOfType<GameStatus>().Destroyscore();
		SceneManager.LoadScene("Start");
	}
	public void Quit()
	{
		Application.Quit();
		
	}


}
