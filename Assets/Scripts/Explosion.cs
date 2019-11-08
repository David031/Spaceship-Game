using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public AudioClip[] audioClips;

    void Start () {
        int n = Random.Range (0, audioClips.Length);
        AudioClip a = audioClips[n];
        GetComponent<AudioSource> ().PlayOneShot (a);
        Destroy (gameObject, 5);
    }

}