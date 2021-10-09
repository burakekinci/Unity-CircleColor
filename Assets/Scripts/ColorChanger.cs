using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    GameObject player;
    
    void Start()
    {
        LevelManager lm;
        SpriteRenderer sr;
        
        //levelManager'a bağlan
        GameObject lvlMng = GameObject.FindGameObjectWithTag("levelManager");
        lm = (LevelManager)lvlMng.GetComponent(typeof(LevelManager));
        
        //spriteRenderer'a ulaş ve rengi ayarla
        sr = GetComponent<SpriteRenderer>();
        lm.SetRandomColor(sr);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        DeleteChanger();   
    }

    void DeleteChanger()
    {
        
        //klon objesi player'dan yeteri kadar aşağıda kalmışsa yok et
        if (player.transform.position.y - gameObject.transform.position.y > 8f)
        {
            LevelManager.NUM_OF_CHANGER--;
            Destroy(gameObject);
        }
    }
}
