using System;
[Serializable]
public class HighscoreElement {
    public string playerName;
    public int points;
    public int day;
    public HighscoreElement (string name, int points,int day) {
        playerName = name;
        this.points = points;
        this.day = day;
    }

}