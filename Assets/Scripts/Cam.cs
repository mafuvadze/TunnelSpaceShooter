using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

    public Transform target;

    private const float camOffsetY = 0.51f;
    private const float camOffsetZ = -0.96f;
	// Use this for initialization
	void Start () {
        positionCam();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        positionCam();
	}

    private void positionCam()
    {
        Vector3 pos = new Vector3(
            target.position.x,
            target.position.y + camOffsetY,
            target.position.z + camOffsetZ);

        transform.position = pos;
    }
}
