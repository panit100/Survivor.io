using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OrbitAttack : MonoBehaviour
{
    public GameObject OrbitObject;
    public float OrbitSpeed;
    public float OrbitDuration;
    public float OrbitCoolDown;
    public int orbitCount;

    private bool loadAllOrbit = false;
    private float tempDuration;
    private Coroutine IECooldown;
    void Start()
    {
        tempDuration = OrbitDuration;
        StartCoroutine(SurroundOrbitSpawn());
    }

    private void Update()
    {
        if (loadAllOrbit)
        {
            this.transform.RotateAround(this.transform.position,Vector3.forward,OrbitSpeed*Time.deltaTime);
            OrbitDuration -= Time.deltaTime;
            if(OrbitDuration < 0)
            {
                Debug.Log("Below");
                foreach (Transform orbits in this.transform)
                {
                    GameObject.Destroy(orbits.gameObject);
                }
                if (IECooldown == null) IECooldown = StartCoroutine(WaitForCoolDown());
                loadAllOrbit = false;
            }
        }
    }



    IEnumerator WaitForCoolDown()
    {
        yield return new WaitForSeconds(OrbitCoolDown);
        StartCoroutine(SurroundOrbitSpawn());
        IECooldown = null;
    }

    IEnumerator SurroundOrbitSpawn()
    {
        float anglestep = 360.0f / orbitCount;
        for (int i = 0; i < orbitCount; i++)
        {
            var NewOrbitObject = Instantiate(OrbitObject);
            //NewOrbitObject.transform.position = Vector2.Lerp(this.transform.position, NewOrbitObject.transform.position, 0.45f);
            NewOrbitObject.transform.RotateAround(transform.position,Vector3.forward, anglestep*i);
            NewOrbitObject.transform.SetParent(this.transform);
            yield return new WaitForEndOfFrame();
        }
        OrbitDuration = tempDuration;
        loadAllOrbit = true;
    
    }
}
