using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Vector3 newCirclePosition;
    public GameObject circle;
    public int test = 2;
    public float gapBetweenCircles;
    public static int score = 0;
    public static bool isCircleCreated;
    public static bool isChangerGot;

    public static int numOfCircle = 0;
    public static int numOfChanger = 0;

    private GameObject player;
    private GameObject createdCircle;
    
    private void Awake()
    {
        //player objesini bul
        player = GameObject.FindGameObjectWithTag("Player");
        SpriteRenderer deadzoneSpriteRenderer = GameObject.FindGameObjectWithTag("deadzone").AddComponent<SpriteRenderer>();  
    }

    private void Start()
    {
        //ilk circle'ı üret
        createdCircle = Instantiate(circle, Vector3.zero, Quaternion.identity);
        ++numOfCircle;
        gapBetweenCircles = 10f;
    }

    void Update()
    {
       
        CreateNewCircle();
       
    }

    void CreateNewCircle()
    {
        //klon circle'ın üretildiği y değerini al
        float posY = createdCircle.transform.position.y;
 
        //yeni circle klon y pozisyonunu belirle
        newCirclePosition = new Vector3(0, posY + gapBetweenCircles,0);

        //yeni circle klonunu üret
        if (numOfCircle<2)
        {
            createdCircle = Instantiate(circle, newCirclePosition, Quaternion.identity);
            ++numOfCircle;
            isCircleCreated = true;
        }
    }

    public void SetRandomColor(SpriteRenderer m_sr)
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                m_sr.color = Color.blue;
                break;
            case 1:
                m_sr.color = Color.green;
                break;
            case 2:
                m_sr.color = Color.black;
                break;
            case 3:
                m_sr.color = Color.red;
                break;
            default:
                break;
        }
    }

}
