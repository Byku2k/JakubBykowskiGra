using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject monster; // Prefab zwyk�ego potwora

    private float targetTime = 2f; // Czas do nast�pnego tworzenia potwora
    private Vector2 direction; // Kierunek ruchu bossa
    private float speed; // Pr�dko�� bossa

    void Start()
    {
        direction = transform.right; // Pocz�tkowy kierunek ruchu w prawo
        speed = GameManager.Instance.bossSpeed; // Pobranie pr�dko�ci bossa z klasy GameManager
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.Rotate(0, 180, 0); // Obr�t bossa o 180 stopni
            speed = Random.Range(0.6f, 5); // Losowa zmiana pr�dko�ci bossa w zakresie od 0.5f do 3
        }
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed); // Poruszanie bossa w aktualnym kierunku z zadan� pr�dko�ci�
        targetTime -= Time.deltaTime; // Odliczanie czasu do tworzenia nowego potwora

        if (targetTime <= 0)
        {
            SpawnMonster(); // Tworzenie zwyk�ego potwora
            targetTime = Random.Range(GameManager.Instance.minMonsterSpawnRate, GameManager.Instance.maxMonsterSpawnRate); // Losowanie nowego czasu do tworzenia potwora w okre�lonym zakresie
        }
    }

    void SpawnMonster()
    {
        Instantiate(monster, transform.position, Quaternion.identity); // Tworzenie zwyk�ego potwora na pozycji bossa
    }
}