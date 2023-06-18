using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterKnife : MonoBehaviour
{
    public float speed = 2f;
    public float avoidDamageChance = 0.05f;

    private Vector2 direction = Vector2.up;
    private bool avoidDamage = false; // Zmienna przechowuj¹ca informacjê o uniku obra¿eñ

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!avoidDamage)
            {
                RestartGame();
            }
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        float randomValue = Random.value;
        if (randomValue <= 0.1f)
        {
            speed *= 2f;
            avoidDamage = true; // Ustawienie uniku obra¿eñ na true
        }
    }
}
