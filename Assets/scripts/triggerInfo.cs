using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerInfo : MonoBehaviour
{
    public Canvas Canvas;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
     Vector3 wantedSize = new Vector3(1f,1f,1f);
     Vector3 unwantedSize = new Vector3(.05f,.05f,.05f);
     public bool isIncreasing = false;

void OnTriggerEnter(Collider other)
{
    Debug.Log("Triggered");
    onTriggerEnter.Invoke();
    if(Canvas.GetComponent<RectTransform>().localScale.x < .1){
        StartCoroutine(ScaleOverTime(.5f, 1f));
    }
     
}

void OnTriggerExit(Collider other){
    onTriggerExit.Invoke();
    StartCoroutine(ScaleOverTime(.5f, 0f));
}


private IEnumerator ScaleOverTime(float duration, float scale) {
    var startScale = Canvas.GetComponent<RectTransform>().transform.localScale;
    var endScale = Vector3.one * scale;
    var elapsed = 0f;

    while (elapsed < duration) {
        var t = elapsed / duration;
        Canvas.GetComponent<RectTransform>().transform.localScale = Vector3.Lerp(startScale, endScale, t);
        elapsed += Time.deltaTime;
        yield return null;
    }

    Canvas.GetComponent<RectTransform>().transform.localScale = endScale;
}
}
