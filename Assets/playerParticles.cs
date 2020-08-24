using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerParticles : MonoBehaviour
{
    public float speed;
    Vector3 PreviousFramePosition = Vector3.zero;

    public ParticleSystem PS;

    private void Start() {
        PS.Stop();
    }

    private void FixedUpdate() {
        CalculateSpeed();
        if (speed > 0f) {
            PS.Play();
            PS.playbackSpeed = speed;
        } else {
            PS.Stop();
        }
    }

    private void CalculateSpeed() {
        // speed calculation
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;
    }
}
