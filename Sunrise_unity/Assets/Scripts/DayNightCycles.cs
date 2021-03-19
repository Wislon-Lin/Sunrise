using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DayNightCycles : MonoBehaviour
{
    public float time;
    public TimeSpan currentime;
    public Transform sunTransform;
    public Light sunLight;
    public Text timetext;
    public float intensity;
    public Color fogday = Color.gray;
    public Color fognight = Color.black;
    public int speed;
    public ParticleSystem PS1, PS2, PS3, PS4, PS5;
    public GameObject spot_light;

    void Start()
    {
        PS1.Stop(); PS2.Stop(); PS3.Stop(); PS4.Stop(); PS5.Stop();
        PS1.GetComponent<AudioSource>().enabled = false;
        PS2.GetComponent<AudioSource>().enabled = false;
        PS3.GetComponent<AudioSource>().enabled = false;
        PS4.GetComponent<AudioSource>().enabled = false;
        spot_light.SetActive(false);
        /*float ang = sunTransform.eulerAngles.x;
        if (ang > 270)
            ang -= 360;
        time = ang * 86400 / 360 + 21600;*/
    }
    void Update()
    {
        if(time > 0 && time <= 19800)
        {
            if (!PS4.isPlaying)
                PS4.Play();
            if (!PS5.isPlaying)
                PS5.Play();
            if(!spot_light.activeInHierarchy)
                spot_light.SetActive(true);
        }
        if (time > 7200)
        {
            if (PS4.GetComponent<AudioSource>().enabled == false)
                PS4.GetComponent<AudioSource>().enabled = true;
        }
        if (time > 19800)
        {
            if (PS4.isPlaying)
                PS4.Stop();
            if (PS5.isPlaying)
                PS5.Stop();
            if (PS4.GetComponent<AudioSource>().enabled == true)
                PS4.GetComponent<AudioSource>().enabled = false;
            if (!PS1.isPlaying)
                PS1.Play();
            if(PS1.GetComponent<AudioSource>().enabled == false)
                PS1.GetComponent<AudioSource>().enabled = true;
            GetComponent<AudioSource>().volume = 0.25f;
            spot_light.SetActive(false);
        }
        if (time > 21600)
        {
            if (!PS2.isPlaying)
                PS2.Play();
            if (PS2.GetComponent<AudioSource>().enabled == false)
                PS2.GetComponent<AudioSource>().enabled = true;
        }
        if (time > 23400)
        {
            if (!PS3.isPlaying)
                PS3.Play();
            if (PS3.GetComponent<AudioSource>().enabled == false)
                PS3.GetComponent<AudioSource>().enabled = true;
        }
        if (time > 25200)
        {
            if (PS3.isPlaying)
                PS3.Stop();
            if (PS3.GetComponent<AudioSource>().enabled == true)
                PS3.GetComponent<AudioSource>().enabled = false;
        }
        if (time > 27000)
        {
            if (PS2.isPlaying)
                PS2.Stop();
            if (PS2.GetComponent<AudioSource>().enabled == true)
                PS2.GetComponent<AudioSource>().enabled = false;
        }
        if (time > 43200)
        {
            if (PS1.isPlaying)
                PS1.Stop();
            if (PS1.GetComponent<AudioSource>().enabled == true)
                PS1.GetComponent<AudioSource>().enabled = false;
            GetComponent<AudioSource>().volume = 1;
        }
        if (time > 19800 && time < 27000) 
            speed = 300;
        else if(time > 63000 && time < 68400)
            speed = 4500;
        else
            speed = 4500;

        time += Time.deltaTime * speed;
        if (time > 86400)
            time = 0;
        currentime = TimeSpan.FromSeconds(time);

        string[] temptime = currentime.ToString().Split(":"[0]);
        timetext.text = temptime[0] + ":" + temptime[1];
        sunTransform.rotation
        = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, -140, 0));

        if (time < 43200)
            intensity = time / 43200;
        else
            intensity = 2 - (time / 43200);

        //RenderSettings.fogColor = Color.Lerp(fognight, fogday, intensity * intensity);
        sunLight.intensity = intensity;
    }
}
