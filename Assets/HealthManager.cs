using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject HealthPowerUpPrefab;
    [SerializeField] private Transform launchOffset;
    private Vector3 position;

    public bool destroyed = false;
    public bool exist = false;

    void Start()
    {
        position = launchOffset.position;
    }

    void Update()
    {
        if (destroyed)
        {
            Debug.Log("inside if expr");
            // StartCoroutine("Wait hehe");
            Debug.Log(Random.Range(3f, 8f));
            if (!exist)
            {
                exist = true;
                Invoke("instantiateOrb", Random.Range(3f, 8f));
            }
        }
    }

    void instantiateOrb()
    {
        position.y = Random.Range(-3f, 2.5f);
        var orb = Instantiate(HealthPowerUpPrefab, position, launchOffset.rotation);
        orb.GetComponent<HealthPowerUp>().playerHealth = GameObject.Find("Health Manager").GetComponent<Character_Health>();
        orb.GetComponent<HealthPowerUp>().healthManager = GameObject.Find("PowerUpManager").GetComponent<HealthManager>();
        destroyed = false;
        exist = true;
    }
}
