using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterController : MonoBehaviour {

    public float speed;
    public float timePerDirection;

    private float timeAtCurrentDir = 0;

    private void Update()
    {
        this.transform.position += this.transform.TransformVector(Vector3.up) * this.speed * Time.deltaTime;
        if (this.timeAtCurrentDir > this.timePerDirection)
        {
            this.transform.Rotate(new Vector3(0, 0, 180), Space.Self);
            this.timeAtCurrentDir = 0;
        } else
        {
            this.timeAtCurrentDir += Time.deltaTime;
        }
    }
}
