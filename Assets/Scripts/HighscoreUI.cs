using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour {
    [SerializeField] TMP_Text nama;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text hari;
    public void UpdateUI (HighscoreElement[] list) {
        nama.text = "Name";
        score.text = "Score";
        hari.text = "Day";

        for (int i = 0; i < list.Length-1; i++) {
            nama.text += "\n"+list[i].playerName;
            score.text += "\n"+list[i].points.ToString();
            hari.text += "\n"+list[i].day.ToString();
        }
    }

}