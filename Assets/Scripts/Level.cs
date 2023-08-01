using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	//config param
	[SerializeField] int brokenBlocks;

	//cached referances
	ScenceLoader scence;	// он пустой и не будет работать!!! пока ты его не инициализируешь
	
	void Start() 
	{
		scence = FindObjectOfType<ScenceLoader>();
	}

	public void CountBreakableBlocks()
	{
		brokenBlocks++;
	}

	public void BlockWasBroken()
	{
		brokenBlocks--;
		if (brokenBlocks <= 0)	// для подстраховки "<"
			scence.NextScence();
	}

}
