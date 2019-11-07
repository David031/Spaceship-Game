using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public AudioClip[] audioClips;

    void Start () {
        // audioClips is an array of AudioClip
        // audioClips.length is 5
        // Random.Range(0,audioClips.length) is 0.0 to 5.0
        // but not including 5.0
        // The range comes down to 0 to 4 when casted to integer
        // Randomly select from audioClips[0] to audioClips[4]
        int n = Random.Range (0, audioClips.Length);
        AudioClip a = audioClips[n];
        GetComponent<AudioSource> ().PlayOneShot (a);
        Destroy (gameObject, 5); // Self-destroy after 5 seconds
    }

}