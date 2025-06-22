using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed = 0f;
    public GameObject car;
    Vector2 startPos;
    Vector2 endPos; //�̷��� �޸𸮰� ��� ������
    Vector2 initPos; // �ڵ��� �ʱ� ��ġ��
    public float swipeLength = 0f; //��������

    //public GameObject car;

    public bool clickFlag = false;
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetMouseButtonDown(0) )// ���콺 Ŭ����
        {

            startPos = Input.mousePosition;
            Debug.Log("Ŭ���� ������ ������ �ȵǰ�");
        } 
        else if ( Input.GetMouseButtonUp(0) )
        {
            if (!clickFlag)
            {
                clickFlag = true;
                //Vector2 endPos = Input.mousePosition; //�̰� �޸� �ڿ� ������ ����Ǵ� ��� ���⼭�� ���� ����
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
               //�ϴ� Ȯ��
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
            
            //������ �𸣰ڴµ� �̰͵� ����
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
