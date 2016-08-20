using UnityEngine;
using System.Collections;

public class ReticleChange : MonoBehaviour {
    public Camera GvrCamera;
    public GameObject GvrReticle;
    
    //sprite of the reticle you want to replace the default one
    public Sprite newReticleSprite;

    //distance in meters from the camera
    public float distanceFromCamera;

    //the size of the reticle
    public float localSizeX, localSizeY;

	// Use this for initialization
	void Start () {
        createReticle();
        hideDefaultReticle();
	}
	
	private void createReticle()
    {
        try
        {
            //creates gameobject that will contain the sprite
            GameObject reticle = new GameObject();
             
            //assign a SpriteRenderer so that the sprite can be attached to the newly created gameobject
            SpriteRenderer srenderer = reticle.AddComponent<SpriteRenderer>();
            srenderer.sprite = newReticleSprite;

            //position the reticle using the user generated values
            reticle.transform.SetParent(GvrCamera.transform);
            reticle.transform.localScale = new Vector3(localSizeX, localSizeY, 1f);
            reticle.transform.position = new Vector3(0f, 0f, distanceFromCamera);
        }catch (System.Exception ex)
        {
            Debug.LogError("Reticle could not be created");
        }
    }

    private void hideDefaultReticle()
    {
        //disables the renderer on the default reticle
        GvrReticle.GetComponent<MeshRenderer>().enabled = false;
    }
}
