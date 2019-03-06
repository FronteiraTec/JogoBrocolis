using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;
using UnityEngine.UI;

namespace JogoBrocolis.FTec {

  public class FlashTextScript : MonoBehaviour {
    public Text newScoreText;
    private string HoldText;

    void Start() {
      HoldText = newScoreText.text;
      StartCoroutine("flashTextOff");
    }

    private IEnumerator flashTextOff() {
      yield return new WaitForSeconds(1);
      newScoreText.text = "";
      StartCoroutine("flashTextOn");
    }

    private IEnumerator flashTextOn() {
      yield return new WaitForSeconds(0.6f);
      newScoreText.text = HoldText;
      StartCoroutine("flashTextOff");
    }
  }
}
