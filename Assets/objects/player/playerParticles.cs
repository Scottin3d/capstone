using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerParticles : MonoBehaviour
{
    public ParticleSystem PS;
    public playerAttributes player;

    private void Awake () {
        PS.Stop();
        PS.gameObject.SetActive(false);

    }

    private void FixedUpdate() {
        /*
        if (player.speed > 0f) {
            PS.Play();
            PS.gameObject.SetActive(true);

            PS.playbackSpeed = player.speed / 4f;
        } else {
            PS.Stop();
            PS.gameObject.SetActive(false);
        }
        */
    }

    
}
