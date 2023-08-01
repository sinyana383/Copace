using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// config param
	[SerializeField] float sreenWidthInUnits = 16f; //* кстати, в инспекторе между большими буквами в названии
	[SerializeField] float min = 1;                  //ставятся пробелы
	[SerializeField] float max = 15;
	
	// state
	void Start () {

		

	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangePosition();

    }

    private void ChangePosition()
    {
        float posXInUnits = Input.mousePosition.x / Screen.width * sreenWidthInUnits;   // значение от 0 до 1 ( * 100 получится в процентах)
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // Vector2 - структура, хронящая x и y
                                                                                     // transform.position.y  или .x - параметры в инспекторе
        paddlePos.x = Mathf.Clamp(posXInUnits, min, max);   // Млжно было и с условиями, но так меньше кода                         
        transform.position = paddlePos;
    }
}
