using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /// <summary>
    /// Defaults to the first object with the 'Player' tag.
    /// </summary>
    public Transform follow;
    public BoxCollider2D cameraBounds;
    public Vector2 margin = new Vector2(1, 1);
    public Vector2 smoothing = new Vector2(3,3);
    public bool isFollowing = true;

    private Vector3 min, max;
    private Camera cam;

    void Start() {
        this.cam = this.GetComponent<Camera>();
        if (cameraBounds == null) {
            this.min = Vector3.negativeInfinity;
            this.max = Vector3.positiveInfinity;
        } else {
            this.min = cameraBounds.bounds.min;
            this.max = cameraBounds.bounds.max;
        }
        if (this.follow == null)
        {
            this.follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }


    void Update() {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        if (this.isFollowing)
        {
            if (Mathf.Abs(x - this.follow.position.x) > margin.x)
            {
                x = Mathf.Lerp(x, this.follow.position.x, smoothing.x * Time.deltaTime);
            }
            if (Mathf.Abs(y - this.follow.position.y) > margin.y)
            {
                y = Mathf.Lerp(y, this.follow.position.y, smoothing.y * Time.deltaTime);
            }
        }
        float cameraHalfWidth = this.cam.orthographicSize * ((float)Screen.width / (float) Screen.height);
        if (max.x - min.x > cameraHalfWidth)
        {
            x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
        }
        //y = Mathf.Clamp(y, min.y + this.cam.orthographicSize, max.y - this.cam.orthographicSize);
        this.transform.position = new Vector3(x, y, transform.position.z);
    }
}
