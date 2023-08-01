using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Config param
	[SerializeField] Paddle paddle1;    //Sprites - скриптабельные объекты. Их тип(название класса и скрипта)
	[SerializeField] float velX = 2f, velY = 12f;  
    [SerializeField] AudioClip[] soundsOfBall;
    [SerializeField] float randomSdvig = 0.3f;

    //States
    Vector2 paddleToBallVector2;
	bool hasStarted = false;
    

    //Cash component references
    AudioSource myAudioiSource;
    Rigidbody2D ballRig;

	// Use this for initialization
	void Start () {

        var blocks = FindObjectsOfType<Block>();    // массив из блоков на сцене
        
		paddleToBallVector2 = transform.position - paddle1.transform.position;  // растояние от ball до paddle
        
        myAudioiSource = GetComponent<AudioSource>();   //GetComponent<T>() - работает ток с запуска, пока не совсем понимаю почему
        ballRig = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            KeepDown();
            PressOnMouse();
        }
    }

    private void PressOnMouse()
    {
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
            hasStarted = true;
        }
    }

    private void KeepDown()
    {
        Vector2 paddle1Pos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddle1Pos + paddleToBallVector2;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        float x = Random.Range(0, randomSdvig);
        float y = Random.Range(0, randomSdvig);
        Vector2 velocityTweak = new Vector2(x, y);
        AudioClip clip = soundsOfBall[Random.Range(0,soundsOfBall.Length)];
        if(hasStarted)  // Звук будет звучать только с начала нажатия клавиши
            myAudioiSource.PlayOneShot(clip);
        ballRig.velocity += velocityTweak;
    }
}
