using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    public Text distance_Text;
    void Start()
    {
        
    }

    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        distance_Text.text = "목표 지점까지 : " + length.ToString("F2") + "m";
        if(length < 0)
        {
            distance_Text.text = "YOU DIE";
        }

        if (Input.GetKeyDown(KeyCode.R) && car.GetComponent<CarController>().carSpeed <= 0f)
        {
            /* 직접지정
            car.gameObject.GetComponent<CarController>().clickFlag = false;
            car.gameObject.GetComponent<CarController>().carSpeed = 0f;
            car.gameObject.transform.position = new Vector3(-7f, -3.7f, 0);
            */
            car.gameObject.GetComponent<CarController>().Reset();
        }
    }
}
