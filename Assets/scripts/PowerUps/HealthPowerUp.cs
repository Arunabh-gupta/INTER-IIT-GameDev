using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public Character_Health playerHealth;
    [SerializeField] private float healthIncrease = 20f;
    public HealthManager healthManager;
    public float ScrollSpeed = 2f;
    public float endx = -1f;

    void Start()
    {
        // playerHealth = GameObject.Find("HealthManager").GetComponent<Character_Health>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);

        if (transform.position.x <= endx)
        {
            // Vector2 pos = new Vector2(startx, transform.position.y);
            // transform.position = pos;
            healthManager.destroyed = true;
            healthManager.exist = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.CompareTag("Player 1") || collider.CompareTag("Player 2"))
        {
            Debug.Log("Collision detected");
            BoostPlayerHealth(collider);
            healthManager.destroyed = true;
            healthManager.exist = false;
            Destroy(gameObject);
        }
    }

    void BoostPlayerHealth(Collider2D collider)
    {
        if (collider.CompareTag("Player 1"))
        {
            var player = GameObject.FindWithTag("Player 1");
            if (player != null)
            {
                if (playerHealth.character_health_1 <= 80)
                {
                    playerHealth.character_health_1 += healthIncrease;
                }
                else
                {
                    playerHealth.character_health_1 = 100;
                }
                Debug.Log(playerHealth.character_health_1);
            }
        }
        else if (collider.CompareTag("Player 2"))
        {
            if (playerHealth.character_health_2 <= 80)
            {
                playerHealth.character_health_2 += healthIncrease;
            }
            else
            {
                playerHealth.character_health_2 = 100;
            }
            Debug.Log(playerHealth.character_health_2);
        }
   }
}
