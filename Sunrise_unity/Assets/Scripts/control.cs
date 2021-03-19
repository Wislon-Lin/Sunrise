using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float speed = 10;
    public float rotation = 20;
    bool active = true;
    public int force = 10;
    public float delay = 3.85f;
    public ParticleSystem ps1, ps2, ps3, ps4;

    void Start()
    {
        StartCoroutine(buoyancySimulation());
    }

    IEnumerator buoyancySimulation()
    {
        while (active)
        {
            yield return new WaitForSeconds(delay);
            GetComponent<Rigidbody>().AddForce(Vector3.up * -force);
        }
    }

    void Update()
    {
		float counting = Input.GetAxis("Vertical"); //(-1~0後退)(0~1前進)
        transform.Translate(Vector3.forward * counting * Time.deltaTime * speed);
        if (counting >= 0.9f)
        {
            ps1.Play(true);
            ps2.Play(true);
        }
        else if (counting > -0.9f && counting < 0.9f)
        {
            ps1.Stop();
            ps2.Stop();
            ps3.Stop();
            ps4.Stop();

        }
        else
        {
            ps3.Play(true);
            ps4.Play(true);
        }
		transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * rotation);//(-1~0左)(0~1右)
    }
}
