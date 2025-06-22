using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed = 0f;
    public GameObject car;
    Vector2 startPos;
    Vector2 endPos; //이러면 메모리가 계속 차지함
    Vector2 initPos; // 자동차 초기 위치값
    public float swipeLength = 0f; //마찬가지

    //public GameObject car;

    public bool clickFlag = false;
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetMouseButtonDown(0) )// 마우스 클릭시
        {

            startPos = Input.mousePosition;
            Debug.Log("클릭은 되지만 동작은 안되게");
        } 
        else if ( Input.GetMouseButtonUp(0) )
        {
            if (!clickFlag)
            {
                clickFlag = true;
                //Vector2 endPos = Input.mousePosition; //이게 메모리 자원 관리상 권장되는 방법 여기서만 쓰고 날라감
                endPos = Input.mousePosition;
                //float swipeLength  = endPos.x - startPos.x > 300f ? 300f : endPos.x - startPos.x;
                swipeLength = endPos.x - startPos.x > 1000f ? 1000f : endPos.x - startPos.x;
                carSpeed = swipeLength / 2000.0f;

                GetComponent<AudioSource>().Play();


                Debug.Log("carSpeed : " + carSpeed);
                Debug.Log("swipeLength : " + swipeLength);
            }
            else
            {
               //일단 확인
            }
            
        }
        
        transform.Translate(carSpeed, 0, 0);
        if (carSpeed < 0.01f) //0.0104f
        {
            carSpeed = 0f;
        }
        else
        {
            carSpeed *= 0.98f;
        }
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            //car.gameObject.GetComponent<CarController>().clickFlag = false;
            
            //왜인지 모르겠는데 이것도 됐음
            //clickFlag = false;
            //transform.position = initPos;
            
        }
        */
        
        

    }

    public void Reset()
    {
        clickFlag = false;
        carSpeed = 0f;
        transform.position = new Vector3(-7f, -3.7f, 0);
    }
}
