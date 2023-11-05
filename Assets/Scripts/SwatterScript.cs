using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatterScript : MonoBehaviour

{
    public float amplitude = 1.0f; 
    public float frequency = 1.0f; 
    protected float speed = 4.0f; 

    private Vector2 startPos;
    private float maxY = 7f; 
    private float maxX = 10f; 

    public void Start()
    {
        startPos = transform.position;
        speed *= Random.Range(0.5f, 1.5f);
        frequency *= Random.Range(0.5f, 1.5f);
    }

    public void Update()
    {
        startPos.x += speed * Time.deltaTime;
        float newY = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = new Vector2(startPos.x, newY);

        if (startPos.x > maxX || startPos.x < -maxX ||
            newY > maxY || newY < -maxY)
        {
            Destroy(gameObject);
        }
    }

}