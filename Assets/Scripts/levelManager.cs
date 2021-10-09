using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Vector3 newCirclePosition;
   
    
    public GameObject circle;

    
    public static int score = 0;
    private GameObject player;
    private GameObject createdCircle;
   
  

    private void Awake()
    {
       SpriteRenderer deadzoneSpriteRenderer = GameObject.FindGameObjectWithTag("deadzone").AddComponent<SpriteRenderer>();  
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        createdCircle = Instantiate(circle, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        createNewCircle();
    }

    void createNewCircle()
    {
        float posY = createdCircle.transform.position.y;
        
        if(createdCircle.transform.position.y - player.transform.position.y < 3f && createdCircle.transform.position.y - player.transform.position.y > 0)
        {
            Debug.Log("BBBBB");
            newCirclePosition = new Vector3(0, posY+10,0);
            createdCircle = Instantiate(circle, newCirclePosition, Quaternion.identity);
        }
    }

   

}
