using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLightFlasher : MonoBehaviour {

    private float[] timings = { 0.5f, 0.5f, 0.5f, 1.0f };
    private int currentTiming = 0;
    private Light flickeringLight;

    private void Start()
    {
        this.flickeringLight = this.GetComponent<Light>();
        this.flickeringLight.enabled = false; // start it off.
        this.StartCoroutine(FlickerLight());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    private IEnumerator FlickerLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.timings[this.currentTiming++ % this.timings.Length]);
            this.flickeringLight.enabled = !this.flickeringLight.enabled;
        }
    }
}
