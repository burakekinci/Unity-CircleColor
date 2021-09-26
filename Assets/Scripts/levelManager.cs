﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public GameObject circlePosition;
    public GameObject player;
    GameObject circleLeftDown;
    GameObject circleRightDown;
    GameObject circleLeftUp;
    GameObject circleRightUp;
    GameObject[] circleNodes;




    public GameObject circleArmPrefab;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            circleRightDown = Instantiate(circleArmPrefab, circlePosition.transform.position,Quaternion.Euler(0,0,0),     circlePosition.transform);
            circleRightUp = Instantiate(circleArmPrefab, circlePosition.transform.position,Quaternion.Euler(0,0,90),    circlePosition.transform);
            circleLeftUp = Instantiate(circleArmPrefab, circlePosition.transform.position,Quaternion.Euler(0,0,180),   circlePosition.transform);
            circleLeftDown = Instantiate(circleArmPrefab, circlePosition.transform.position,Quaternion.Euler(0,0,270),   circlePosition.transform);
            Debug.Log("nodelar uretildi");
            circleNodes = new GameObject[4] { circleRightDown, circleRightUp, circleLeftDown, circleLeftUp };

            //siyah,mavi,kırmızı,yeşil
            RandomColor();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach(GameObject circleNode in circleNodes)
            {
                Destroy(circleNode);
            }
        }
    }

    void RandomColor() 
    {
        Debug.Log("randomColor fonk calisti");
        Color[] circleColors = new Color[4];
        circleColors[0] = Color.black;
        circleColors[1] = Color.blue;
        circleColors[2] = Color.red;
        circleColors[3] = Color.green;

        int randomInt;
        int randomNodeMatchesPlayerColor = Random.Range(0,3);
        Debug.Log(randomNodeMatchesPlayerColor);
        for(int i=0;i<4;i++)
        {
            if (i == randomNodeMatchesPlayerColor)
            {
                circleNodes[i].GetComponent<SpriteRenderer>().color = Color.yellow;
                Debug.Log("sari geldi");
                continue;
            }
            randomInt = Random.Range(0, circleColors.Length);
            circleNodes[i].GetComponent<SpriteRenderer>().color = circleColors[randomInt];
            Debug.Log(i + ". node renklendi");
        }
    }
    
}
