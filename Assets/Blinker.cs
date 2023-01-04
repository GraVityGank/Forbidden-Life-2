using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    public float FlashingTime = .6f;
    public float TimeInterval = .1f;

    void OnEnable()
    {
        StartCoroutine(Flash(FlashingTime, TimeInterval));
    }

    IEnumerator Flash(float time, float intervalTime)
    {
        //this counts up time until the float set in FlashingTime
        float elapsedTime = 0f;
        //This repeats our coroutine until the FlashingTime is elapsed
        while (elapsedTime < time)
        {
            //This gets an array with all the renderers in our gameobject's children
            Renderer[] RendererArray = GetComponentsInChildren<Renderer>();
            //this turns off all the Renderers
            foreach (Renderer r in RendererArray)
                r.enabled = false;
            //then add time to elapsedtime
            elapsedTime += Time.deltaTime;
            //then wait for the Timeinterval set
            yield return new WaitForSeconds(intervalTime);
            //then turn them all back on
            foreach (Renderer r in RendererArray)
                r.enabled = true;
            elapsedTime += Time.deltaTime;
            //then wait for another interval of time
            yield return new WaitForSeconds(intervalTime);
        }
    }
}
