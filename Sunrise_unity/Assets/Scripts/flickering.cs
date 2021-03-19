using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickering : MonoBehaviour
{
    public Light sourceLight;
    public float min_interval;
    public float max_interval;
	void Start ()
    {
        StartCoroutine(flashing());
	}
	
	IEnumerator flashing()
    {
		while(true)
        {
            yield return 
            new WaitForSeconds(Random.Range(min_interval,max_interval));
            sourceLight.enabled = !sourceLight.enabled;
        }
	}
}
