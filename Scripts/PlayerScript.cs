using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    public float jumpForce;
    SpriteRenderer spriteRenderer;
    public SpriteRenderer life6;
    public SpriteRenderer life1;
    public SpriteRenderer life2;
    public SpriteRenderer life3;
    public SpriteRenderer life4;
    public SpriteRenderer life5;
    public GameObject seeds;
    public Transform startPosition;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;

    // Start is called before the first frame update
    void Start()
    {
        life1.enabled = false;
        life2.enabled = false;
        life3.enabled = false;
        life4.enabled = false;
        life5.enabled = false;
        life6.enabled = false;

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        transform.position = startPosition.position;
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        // Horizontal player movement (A and D keys to move left and right)
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontal);
        if(horizontal > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        if(horizontal < -0.01)
        {
            spriteRenderer.flipX = true;
        }

        // Vertical player movement (Spacebar to jump)
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.01)
        {
            rb2d.AddRelativeForce(Vector2.up * jumpForce);
        }

    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("seed"))
        {
            Destroy(seeds);
        }
        if (other.CompareTag("life"))
        {
            life1.enabled = true;
            life2.enabled = true;
            life3.enabled = true;
            life4.enabled = true;
            life5.enabled = true;
            life6.enabled = true;

        }

        if(other.CompareTag("Finish"))
        {
            transform.position = startPosition.position;
        }

        if(other.CompareTag("text1"))
        {
            text1.SetActive(true);
            Destroy(text1, 5.3f);
        }

        if (other.CompareTag("text2"))
        {
            text2.SetActive(true);
            Destroy(text2, 3.1f);
        }

        if (other.CompareTag("text3"))
        {
            text3.SetActive(true);
            Destroy(text3, 2.3f);
        }

        if (other.CompareTag("text4"))
        {
            text4.SetActive(true);
            Destroy(text4, 8f);
        }

        if (other.CompareTag("text5"))
        {
            text5.SetActive(true);
            
        }
    }
}
