using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string currentColor;
    public float jumpForce = 10f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public Color blue, yellow, pink, purple;
    public Rigidbody2D rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            circle.velocity = Vector2.up * jumpForce;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "colorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            Debug.Log("renk değişti");
            return;
        }
        if(collision.tag != currentColor || collision.tag == "deadzone")
        {
            Debug.Log("You died");
            StartCoroutine(ResetLevel());
        }
       
    }


    void SetRandomColor()
    {
        int rand = Random.Range(0, 3);

        switch(rand)
        {
            case 0:
                currentColor = "blue";
                sr.color = blue;
                break;
            case 1:
                currentColor = "yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColor = "purple";
                sr.color = purple;
                break;
            case 3:
                currentColor = "pink";
                sr.color = pink;
                break;
            default:
                break;
        }



    }

    IEnumerator ResetLevel()
    {
        this.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);

    }
}
