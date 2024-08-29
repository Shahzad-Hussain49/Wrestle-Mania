using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private GameObject focalPoint;
    [SerializeField] GameObject powerUpIndicator;
    private Rigidbody rb;
    private bool hasPowerUp;
    private float powerUpStrength = 15.0f;
    private float powerUpTime = 7;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
  
    }

    private void Update()
    {
        if (focalPoint == null) return;
        float verticalMove = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * verticalMove * speed );
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp")) {

            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerUp= false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyfarAway = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(enemyfarAway*powerUpStrength, ForceMode.Impulse);
        }
    }
}
