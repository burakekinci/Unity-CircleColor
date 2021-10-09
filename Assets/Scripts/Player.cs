using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    private Rigidbody2D rb;

    LevelManager lm;
    //oyun başında rigidbody kinematicten etkilenmesin ve komponentleri ayarla
    private void Awake()
    {
        GameObject lvlMng = GameObject.FindGameObjectWithTag("levelManager");
        lm = (LevelManager) lvlMng.GetComponent(typeof(LevelManager));
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //siyah,mavi,kırmızı,yeşil olmak üzere rastgele renk seç
        lm.SetRandomColor(sr);
    }

    void Update()
    {
        //zıplama
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            circle.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //renk değiştirme bölgesine girerse renk değiştir ve score'u arttır
        //CompareTag() , tag1 == tag2 karşılaştırmasına göre daha verimli
        if (collision.CompareTag("colorChanger"))
        {
            Destroy(collision.gameObject);
            sr.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            Debug.Log("renk değişti");

            LevelManager.score += 1;
            Debug.Log(LevelManager.score);
            return;
        }

        //yanlış renk ile temas ederse veya  kamera alanından çıkarsa bölümü resetle
        else if (collision.GetComponent<SpriteRenderer>().color != sr.color || collision.CompareTag("deadzone"))
        {
            Debug.Log("You died");
            StartCoroutine(ResetLevel()); 
        }   
    }

    //bölüm resetleyici
    IEnumerator ResetLevel()
    {
        this.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);

    }
}
