using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSmash : MonoBehaviour
{

    public ParticleSystem PS;
    public float objectHealth;
    private float currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = objectHealth;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            GameObject player = collision.gameObject;
            float damage = player.GetComponent<playerAttributes>().HitForce();
            currentHealth -= damage;

            Vector3 point = collision.transform.position;
            Debug.Log("Hit!  Health at: " + currentHealth);
            if (currentHealth < 0) {
                currentHealth = 0f;
                DestroyObject(point);
            }
        }
    }

    private void DestroyObject(Vector3 pos) {
        PS = ParticleSystem.Instantiate(PS);
        PS.gameObject.SetActive(true);
        PS.transform.position = pos;
        PS.Play();
        Destroy(this.gameObject);
    }
}
