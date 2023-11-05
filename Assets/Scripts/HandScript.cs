using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI; 

public class HandScript : MonoBehaviour
{
    private Camera mainCamera;
    private Animator animator; 
    public GameObject bloodSplatterPrefab;
    public int score = 0; 
    public Text scoreText; 

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        mainCamera = Camera.main;
        animator = GetComponent<Animator>(); 
        UpdateScoreText();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Vector3 targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0; // Z ekseni değerini 0 olarak belirle çünkü 2D oyun

            
            transform.position = targetPosition;
            animator.SetBool("slap", true);
        }
        else
        {
            animator.SetBool("slap", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fly"))
        {
            Destroy(collision.gameObject);
            PlayHitEffect(collision.transform.position);
            score++;
            UpdateScoreText();
        }
        if (collision.CompareTag("Butterfly"))
        {
            Destroy(collision.gameObject);
            score -= 5;
            UpdateScoreText();
        }
        if (collision.CompareTag("Spider"))
        {
            Destroy(collision.gameObject);
            score += 5;
            UpdateScoreText();
        }
    }

        void PlayHitEffect(Vector3 position)
        {
            GameObject splatter = Instantiate(bloodSplatterPrefab, position, Quaternion.identity);
            Destroy(splatter, 1f);
        }

        void UpdateScoreText()
        {
            scoreText.text = "Score: " + score;
        }
    }
