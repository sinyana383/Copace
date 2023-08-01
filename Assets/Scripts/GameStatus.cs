using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	// config params
	[Range(0.1f, 11f)] [SerializeField] float timeOfGame = 1;
	[SerializeField] int scorePointsOfBlock = 17;

	// state variables
	[SerializeField]  int score = 0; 

	[SerializeField]  TextMeshProUGUI textScore;  // не забывай ИНИЦИАЛИЗИРОВАТЬ, УМ, у тебя пустой объект

	// Use this for initialization
	void Awake()
	{
		int count = FindObjectsOfType<GameStatus>().Length;
		if (count > 1)
		{
			gameObject.SetActive(false);    // Исправило Null-Exception, пока не знаю как
			Destroy(gameObject);
		}
		else
			DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		textScore.text = score.ToString();
	}

	// Update is called once per frame
	void Update() {

		Time.timeScale = timeOfGame;    // ускорять и замедлять игру( то есть все объекты)
	}

	public void AddPoints()
	{
		score += scorePointsOfBlock;
		textScore.text = score.ToString();
	}

	public void Destroyscore()
	{
		Destroy(gameObject);	// gameobject объект, к которому приклеплён этот скрипт
	}

	 
}
