using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public Ball ball; 

    public void InitiateCountdown()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            AudioManager.instance.Play(SoundName.HIT_WALL);
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "GO!";

        if (ball != null)
        {
            AudioManager.instance.Play(SoundName.SCORE);
            ball.AddStartingForce();
        }

        yield return new WaitForSeconds(0.5f);
        countdownText.text = "";
    }
}
