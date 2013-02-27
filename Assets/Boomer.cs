using UnityEngine;
using System.Collections;

public class Boomer : MonoBehaviour {

    Transform tranBoomX;
    Transform tranBoomXN;
    Transform tranBoomZ;
    Transform tranBoomZN;

    float fBoomerTime;
    public float fFireLength = 5;


	// Use this for initialization
	void Start () {
        tranBoomX = transform.Find("BoomX");
        tranBoomXN = transform.Find("BoomXN");
        tranBoomZ = transform.Find("BoomZ");
        tranBoomZN = transform.Find("BoomZN");
        tranBoomX.particleEmitter.emit = false;
        tranBoomXN.particleEmitter.emit = false;
        tranBoomZ.particleEmitter.emit = false;
        tranBoomZN.particleEmitter.emit = false;
	}
	
	// Update is called once per frame
	void Update () {
        fBoomerTime += Time.deltaTime;
        
        if (fBoomerTime > 2)
        {
            tranBoomX.particleEmitter.emit = true;
            tranBoomXN.particleEmitter.emit = true;
            tranBoomZ.particleEmitter.emit = true;
            tranBoomZN.particleEmitter.emit = true;
            Destroy(GetComponent("MeshRenderer"));
            FireLength(tranBoomX);
            FireLength(tranBoomXN);
            FireLength(tranBoomZ);
            FireLength(tranBoomZN);
        }
        if (fBoomerTime > 3)
        {
            tranBoomX.particleEmitter.emit = false;
            tranBoomXN.particleEmitter.emit = false;
            tranBoomZ.particleEmitter.emit = false;
            tranBoomZN.particleEmitter.emit = false;
            Destroy(gameObject);
            //GameObject gobjPlayer = GameObject.FindGameObjectWithTag("Player");
        }
	}

    int FireLength(Transform transform)
    {
        Ray rayFireLine = new Ray(transform.position, transform.forward);
        RaycastHit rayHit;
        Debug.Log("Don't hit anything.");
        Debug.DrawLine(rayFireLine.origin, new Vector3(7.5f, 1f, 1.5f));
        if (collider.Raycast(rayFireLine, out rayHit, fFireLength))
        {
            Debug.Log("Hit something!");
            Debug.DrawLine(rayFireLine.origin, rayHit.point);
        }
        return 0;
    }
}
