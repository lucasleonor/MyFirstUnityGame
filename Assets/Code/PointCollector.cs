using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour {

    //public ParticleSystem particle_system;
    public AudioClip collect;
    private bool collected;

    // Use this for initialization
    void Start () {
        /*particle_system.Clear();
        particle_system.Stop();*/
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && !collected)
        {
            StartCoroutine(BallCollected());
            collected = true;
        }
    }

    IEnumerator BallCollected()
    {
        Hero.AddPoint();
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = collect;
        audio.Play();
        GetComponentInChildren<Animator>().SetBool("Collected", true);
        //GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(1.0f);
        //particle_system.Play();
        Destroy(transform.gameObject);
    }
}
