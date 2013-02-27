using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    public Transform tranBoomer{get; set;}
    public int nBoomCount = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire") && nBoomCount > 0)
	    {
            PutBoomerOnMesh(transform);
	    }	    
	}

    void PutBoomerOnMesh(Transform tranPlayer)
    {
        float fBoomerX = 0.0f;
        float fBoomerZ = 0.0f;
        float fPlayerX = OffSetMeshPosition(tranPlayer.position.x);
        float fPlayerZ = OffSetMeshPosition(tranPlayer.position.z);
        float fPlayerEulaer = tranPlayer.eulerAngles.y;
        if (fPlayerEulaer > 45 && fPlayerEulaer < 135)
        {
            fBoomerX = fPlayerX + 1;
            fBoomerZ = fPlayerZ;
        }
        else if (fPlayerEulaer > 225 && fPlayerEulaer < 315)
        {
            fBoomerX = fPlayerX - 1;
            fBoomerX = fPlayerZ;
        }
        else if (fPlayerEulaer >135 && fPlayerEulaer < 225)
        {
            fBoomerX = fPlayerX;
            fBoomerZ = fPlayerZ - 1;
        }
        else
        {
            fBoomerX = fPlayerX;
            fBoomerZ = fPlayerZ + 1;
        }
        if (IsArea(fBoomerX, fBoomerZ))
        {
            Vector3 vct3BoomerPosition = new Vector3(fBoomerX, 0.3f, fBoomerZ);
            Instantiate(tranBoomer, vct3BoomerPosition, Quaternion.identity);
            --nBoomCount;
        }
    }

    float OffSetMeshPosition(float fSource)
    {
        int nInt = Mathf.CeilToInt(fSource);
        float fDest = nInt - 0.5f;
        return fDest;
    }

    bool IsArea(float fX, float fZ)
    {
        fX -= 1.5f;
        fZ -= 1.5f;
        if (fX % 2 == 0 || fZ % 2 == 0)
            return true;
        else
            return false;
    }
}
