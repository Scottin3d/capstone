
using UnityEngine;

public class objectBase : MonoBehaviour
{
    // is it break able?
    [SerializeField]
    private bool isBreakable = false;

    // damage effects
    public ParticleSystem PS;
    [SerializeField]
    private Texture2D cracks;
    private Material material;
    private Renderer rend;
    private float crackOpacity = 0f;

    // health
    [SerializeField]
    private float objectHealth;
    private float currentHealth;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = objectHealth;
        rend = GetComponent<Renderer>();
        material = GetComponent<MeshRenderer>().material;
        //material = Material.Instantiate(material);
    }

    // on collision, if breakable, damage health
    private void OnCollisionEnter(Collision collision) {
        if (isBreakable) {
            if (collision.gameObject.tag == "Player") {

                // get hit damage from player
                GameObject player = collision.gameObject;
                float damage = player.GetComponent<playerAttributes>().HitForce();
                currentHealth -= damage;

                // collisino point
                Vector3 point = collision.transform.position;

                // TODO update visual damage to object

                crackOpacity = 1 - Mathf.Clamp01(currentHealth / objectHealth) ;
                Debug.Log(crackOpacity);

                material.SetFloat("Vector1_F8D3532F", crackOpacity);
                
                // if health at 0, destroy
                if (currentHealth < 0) {
                    currentHealth = 0f;
                    DestroyObject(point);
                }


                // debug log
                Debug.Log("Hit!  Health at: " + currentHealth);
            }
        }
    }

    // when health == 0
        // play destruction PS
        // destroy object
    private void DestroyObject(Vector3 pos) {
        PS = ParticleSystem.Instantiate(PS);
        PS.gameObject.SetActive(true);
        PS.transform.position = pos;
        PS.Play();
        Destroy(this.gameObject);
    }
}
