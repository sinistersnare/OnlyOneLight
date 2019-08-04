using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject[] thingsToActivate;

    private void Start()
    {
        foreach (GameObject go in this.thingsToActivate)
        {
            go.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject go in this.thingsToActivate)
        {
            go.SetActive(true);
        }
    }
}
