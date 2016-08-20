using UnityEngine;
using System.Collections;

public class AircraftController : MonoBehaviour {
    public float throttleForce;

    private GameObject cam;
    private Rigidbody rbody;
    private Vector3 forward;
    private GvrReticle reticle;
    private Crosshair ch;

    private float maxTurn = 8f;
    private float maxAngle = 45f;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera");
        rbody = GetComponent<Rigidbody>();
        forward = cam.transform.forward;
        reticle = cam.GetComponentInChildren<GvrReticle>();
        ch = cam.GetComponentInChildren<Crosshair>();

        turnGravityOff();
        reticle.hideReticle();
	}
	
	void FixedUpdate () {
        forward = cam.transform.forward;
        applyForwardForce();
        setTilt();
        setOrientation();
    }

    private void applyForwardForce()
    {
        //transform.position = Vector3.MoveTowards(transform.position, ch.getPosition(), .5f);
        rbody.AddForce(forward * throttleForce);
    }

    private void turnGravityOn()
    {
        rbody.useGravity = true;
    }

    private void turnGravityOff()
    {
        rbody.useGravity = false;
    }

    private void setOrientation()
    {
        transform.LookAt(ch.getPosition());
    }

    private void setTilt()
    {
        float myX = transform.position.x;
        float chX = ch.getPosition().x;
        float deltaX = myX - chX;
        float mult = deltaX / maxTurn;
        float angle = mult * maxAngle;

        ch.transform.localEulerAngles = new Vector3(0f, 0f, maxAngle * mult);

        //transform.localEulerAngles = new Vector3(transform.rotation.x,
            //transform.rotation.y,
            //transform.rotation.z + angle);
    }
}
