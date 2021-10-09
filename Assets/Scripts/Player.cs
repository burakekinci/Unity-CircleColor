using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //oyun başında rigidbody kinematicten etkilenmesin
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //siyah,mavi,kırmızı,yeşil olmak üzere rastgele renk seç
        SetRandomColor();
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
        if (collision.tag == "colorChanger")
        {
            Destroy(collision.gameObject);
            SetRandomColor();
            Debug.Log("renk değişti");
            
            LevelManager.score += 1;
            Debug.Log(LevelManager.score);
            return;
        }

        //yanlış renk ile temas ederse veya  kamera alanından çıkarsa bölümü resetle
        else if (collision.GetComponent<SpriteRenderer>().color != sr.color || collision.tag =="deadzone")
        {
            Debug.Log("You died");
            Debug.Log(collision.GetComponent<SpriteRenderer>().color);
            Debug.Log(sr.color);
            StartCoroutine(ResetLevel()); 
        }   
    }

    void SetRandomColor()
    {
        int rand = Random.Range(0, 4);
        Debug.Log("random color no" + rand);
        switch (rand)
        {
            case 0:
                sr.color = Color.blue;
                break;
            case 1:
                sr.color = Color.green;
                break;
            case 2:
                sr.color = Color.black;
                break;
            case 3:
                sr.color = Color.red;
                break;
            default:
                break;
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
