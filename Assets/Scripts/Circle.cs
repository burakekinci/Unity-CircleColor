using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    //circle objesinin kendi poziyonu
    private Transform _circleTransform;
    
    public GameObject player;
    public GameObject circleArmPrefab;

    [HideInInspector]
    private  GameObject circleLeftDown;
    private  GameObject circleRightDown;
    private  GameObject circleLeftUp;
    private  GameObject circleRightUp;
    private  GameObject[] circleNodes;


    // Update is called once per frame
    void Start()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        _circleTransform = this.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        
        //node'ları instantiate et
        Debug.Log("Circle objesi olusturuldu...");
        circleRightDown = Instantiate(circleArmPrefab, _circleTransform.position, Quaternion.Euler(0, 0, 0), _circleTransform);
        circleRightUp = Instantiate(circleArmPrefab, _circleTransform.position, Quaternion.Euler(0, 0, 90), _circleTransform);
        circleLeftUp = Instantiate(circleArmPrefab, _circleTransform.position, Quaternion.Euler(0, 0, 180), _circleTransform);
        circleLeftDown = Instantiate(circleArmPrefab, _circleTransform.position, Quaternion.Euler(0, 0, 270), _circleTransform);
        Debug.Log("nodelar uretildi");
        circleNodes = new GameObject[4] { circleRightDown, circleRightUp, circleLeftDown, circleLeftUp };
        //siyah,mavi,kırmızı,yeşil
        RandomColor();
        
    }
   
    void Update()
    {
        deleteCircle();
    }

    void deleteCircle()
    {
        if(player.transform.position.y - gameObject.transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
    
    protected void RandomColor()
    {
        Debug.Log("randomColor fonk calisti");
        
        //renkler dizisi
        Color[] circleColors = new Color[4];
        circleColors[0] = Color.black;
        circleColors[1] = Color.blue;
        circleColors[2] = Color.red;
        circleColors[3] = Color.green;

        int randomInt;
        int randomNodeMatchesPlayerColor = Random.Range(0, 4);
        Debug.Log(randomNodeMatchesPlayerColor + ". node oyuncu ile aynı renk olması lazım");
        
        //circleNoda'ları rastgele renklendir
        for (int i = 0; i < 4; i++)
        {
            if (i == randomNodeMatchesPlayerColor)
            {
                //oyuncu ile aynı renk olması gereken node'u renklendir
                circleNodes[i].GetComponent<SpriteRenderer>().color = player.GetComponent<SpriteRenderer>().color;
                Debug.Log(i + ". node oyuncu ile aynı renk oldu");
                continue;
            }
            randomInt = Random.Range(0, circleColors.Length);
            circleNodes[i].GetComponent<SpriteRenderer>().color = circleColors[randomInt];
            Debug.Log(i + ". node renklendi");
        }
    }

   

}
