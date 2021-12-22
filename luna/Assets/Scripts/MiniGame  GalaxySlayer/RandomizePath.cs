using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomizePath : MonoBehaviour
{
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float speed;

    Vector2 targetPostion;

    private void Start()
    {
        targetPostion = GetRandomPosition();
    }

    private void Update()
    {
        if ((Vector2)transform.position != targetPostion)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
        }
        else
        {
            targetPostion = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Animals")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
