using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public string nextScene;

    private ParticleSystem particle_system;
    private bool winnable;
    // Use this for initialization
    void Start () {
        particle_system = GetComponent<ParticleSystem>();
        particle_system.Clear();
        particle_system.Stop();
        winnable = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && winnable)
        {
            StartCoroutine(portal());
        }
    }
    // Update is called once per frame
    void Update () {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        if (points.Length == 0 && !winnable)
        {
            winnable = true;
            particle_system.Play();
        }
	}

    IEnumerator portal()
    {
        yield return new WaitForSeconds(0.1f);
        Manager.getInstance().ShowNextLevelMenu();
    }
}
