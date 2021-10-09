using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    SpriteRenderer sr;
    LevelManager lm;
    void Start()
    {
        gameObject.AddComponent<CircleCollider2D>();
        GameObject lvlMng = GameObject.FindGameObjectWithTag("levelManager");
        lm = (LevelManager)lvlMng.GetComponent(typeof(LevelManager));
        sr = GetComponent<SpriteRenderer>();
        lm.SetRandomColor(sr);
    }

    
}
