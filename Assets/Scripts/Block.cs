using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {

	//config param
	[SerializeField] AudioClip blockBreaksSound;
	[SerializeField] GameObject sparklVFX;
	[SerializeField] Sprite[] stateOfBlock;

	// cashed referances
	Level level;		// Инициализируй с помощью FindObjectOfType<T>
	GameStatus score;   // и тебе 

	// state variables
	int timesHit = 0;
	
	void Start() 
	{

		if (tag == "Breakable")
		{
			level = FindObjectOfType<Level>();  // кол-во блоков == кол-во вызываемых скриптов
			level.CountBreakableBlocks();
			score = FindObjectOfType<GameStatus>();
		}
	}
	
	
	private void OnCollisionEnter2D(Collision2D collis)
    {
		if (tag == "Breakable")
        {
            HitIt();
        }


    }

    private void HitIt()
    {
        timesHit++;
		int maxHit = stateOfBlock.Length + 1;
        AudioSource.PlayClipAtPoint(blockBreaksSound, Camera.main.transform.position);
        if (timesHit >= maxHit) //!!! Всегда на всякий случай ставь > or <
            DestroyBloock();
		else
		ChangeSprite();
	}

    private void ChangeSprite()
    {
		int currentSpriteIndex = timesHit - 1;
		if (stateOfBlock[currentSpriteIndex] != null)
			GetComponent<SpriteRenderer>().sprite = stateOfBlock[currentSpriteIndex++];
		else 
		{
			Debug.LogError("Block sprite is missing from array");
			Debug.LogError(gameObject);
		}
			
    }

    private void DestroyBloock()
    {
        
        level.BlockWasBroken();
		score.AddPoints();
        Destroy(gameObject);
		EffectTriger();

	}

	private void EffectTriger() 
	{
		GameObject sparkles = GameObject.Instantiate(sparklVFX,transform.position,transform.rotation);
		Destroy(sparkles, 1f);
	}
}
// Баги
