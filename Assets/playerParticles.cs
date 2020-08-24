using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerParticles : MonoBehaviour
{
    public float speed;
    Vector3 PreviousFramePosition = Vector3.zero;

    public ParticleSystem PS;

    private void Awake() {
        PS.Stop();
        PS.gameObject.SetActive(false);

    }

    private void FixedUpdate() {
        CalculateSpeed();
        if (speed > 0f) {
            PS.Play();
            PS.gameObject.SetActive(true);

            PS.playbackSpeed = speed / 4f;
        } else {
            PS.Stop();
            PS.gameObject.SetActive(false);
        }
    }

    private void CalculateSpeed() {
        // speed calculation
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;
    }
}
