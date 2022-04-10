using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    public GameObject blackOutSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFadeout(int speed){
        StartCoroutine(FadeBlackOutSquare(true, speed));
    }

    public void reverseFadeout(){
        StartCoroutine(FadeBlackOutSquare(false, 3));
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5){
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;
        if(fadeToBlack){
            while(blackOutSquare.GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else {
            while(blackOutSquare.GetComponent<Image>().color.a > 0) {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
