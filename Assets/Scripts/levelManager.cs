using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Vector3 newCirclePosition;
    public Vector3 newChangerPosition;
    public GameObject circle;
    public GameObject changer;

    public float gapBetweenObj;
    public float changerOffset;
    
    public static int SCORE = 0;
    
    public static int NUM_OF_CIRCLE = 0;
    public static int NUM_OF_CHANGER = 0;

    private GameObject _createdCircle;
    private GameObject _createdChanger;
    
    private void Awake()
    {
        SpriteRenderer deadzoneSpriteRenderer = GameObject.FindGameObjectWithTag("deadzone").AddComponent<SpriteRenderer>();  
    }

    private void Start()
    {
        gapBetweenObj = 10f;
        changerOffset = 5f;
        
        //ilk circle'ı üret
        _createdCircle = Instantiate(circle, Vector3.zero, Quaternion.identity);
        NUM_OF_CIRCLE++;

        //ilk changer'ı üret
        _createdChanger = Instantiate(changer, new Vector3(0, changerOffset, 0), Quaternion.identity);
        NUM_OF_CHANGER++;
    }

    void Update()
    {
        CreateNewCircle();
        CreateNewChanger();
        Debug.Log("changer" + NUM_OF_CHANGER);
        Debug.Log("circle" + NUM_OF_CIRCLE);

        UpdateScore();
    }

    public void UpdateScore()
    {
        Text scoreUI;
        scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreUI.text = "Score: " + SCORE;
    }

    void CreateNewCircle()
    {
        //klon circle'ın üretildiği y değerini al
        float posY = _createdCircle.transform.position.y;
 
        //yeni circle klon y pozisyonunu belirle
        newCirclePosition = new Vector3(0, posY + gapBetweenObj,0);

        //yeni circle klonunu üret
        if (NUM_OF_CIRCLE<2)
        {
            _createdCircle = Instantiate(circle, newCirclePosition, Quaternion.identity);
            NUM_OF_CIRCLE++;
        }
    }

    void CreateNewChanger()
    {
        //klon changer'ın üretildiği y değerini al
        float posY = _createdChanger.transform.position.y;

        //yeni changer klon y pozisyonunu belirle
        newChangerPosition = new Vector3(0, posY + gapBetweenObj, 0);

        //yeni changer klonunu üret
        if (NUM_OF_CHANGER <= 1)
        {
            Debug.Log("test");
            _createdChanger = Instantiate(changer, newChangerPosition, Quaternion.identity);
            NUM_OF_CHANGER++;
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
