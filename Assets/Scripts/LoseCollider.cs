using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private SceneLoader levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<SceneLoader>();
    }

	void OnTriggerEnter2D (Collider2D trigger)
    {
        print("Trigger");
        levelManager.LoadScene("Lose Screen");
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        print("Collision");

    }
}
