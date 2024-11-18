using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    private TextMeshPro _timeText;

    public void Awake()
    {
        _timeText = GetComponent<TextMeshPro>();
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}