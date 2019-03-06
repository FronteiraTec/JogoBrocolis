//FONTE https://www.youtube.com/watch?v=0IWY9QOyAv4   ou    https://goo.gl/9K1aj8
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlphaFlashing : MonoBehaviour {
  public float minAlpha = 0.1f;
  public float maxAlpha = 0.9f;
  public float timerAlpha = 0.0f;

  private float minAlphaZ;
  private float maxAlphaZ;
  private float timerAlphaZ;
  private float alphazxc;
  private bool timertr = false;
  private Color rezcolor;

  void Start() {
    alphazxc = minAlpha;
    minAlphaZ = minAlpha;
    maxAlphaZ = maxAlpha;
    timerAlphaZ = timerAlpha / 100.0f;
    rezcolor = this.GetComponent<Text>().color;
  }

  private void FixedUpdate() {
    if(timertr == false)
    {
      minAlphaZ += timerAlphaZ * Time.deltaTime;
      alphazxc = minAlphaZ;
      if(minAlphaZ >= maxAlpha) {
        timertr = true;
        minAlphaZ = minAlpha;
      }
    }

    if(timertr == true)
    {
      maxAlphaZ -= timerAlphaZ * Time.deltaTime;
      alphazxc = maxAlphaZ;
      if(maxAlphaZ <= minAlpha) {
        timertr = false;
        maxAlphaZ = maxAlpha;
      }
    }

    this.GetComponent<Text>().color = new Color(rezcolor.r, rezcolor.g, rezcolor.b, alphazxc);
  }
}