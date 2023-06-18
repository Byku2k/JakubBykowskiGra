using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject monster; // Prefab zwyk³ego potwora

    private float targetTime = 2f; // Czas do nastêpnego tworzenia potwora
    private Vector2 direction; // Kierunek ruchu bossa
    private float speed; // Prêdkoœæ bossa

    void Start()
    {
        direction = transform.right; // Pocz¹tkowy kierunek ruchu w prawo
        speed = GameManager.Instance.bossSpeed; // Pobranie prêdkoœci bossa z klasy GameManager
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.Rotate(0, 180, 0); // Obrót bossa o 180 stopni
            speed = Random.Range(0.6f, 5); // Losowa zmiana prêdkoœci bossa w zakresie od 0.5f do 3
        }
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed); // Poruszanie bossa w aktualnym kierunku z zadan¹ prêdkoœci¹
        targetTime -= Time.deltaTime; // Odliczanie czasu do tworzenia nowego potwora

        if (targetTime <= 0)
        {
            SpawnMonster(); // Tworzenie zwyk³ego potwora
            targetTime = Random.Range(GameManager.Instance.minMonsterSpawnRate, GameManager.Instance.maxMonsterSpawnRate); // Losowanie nowego czasu do tworzenia potwora w okreœlonym zakresie
        }
    }

    void SpawnMonster()
    {
        Instantiate(monster, transform.position, Quaternion.identity); // Tworzenie zwyk³ego potwora na pozycji bossa
    }
}