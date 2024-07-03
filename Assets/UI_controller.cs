using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    public TextMeshProUGUI LeftPlayerScore;
    public TextMeshProUGUI RightPlayerScore;

    public void SetLeftPlayerScored(string Text)
    {
        LeftPlayerScore.SetText(Text);
    }
    public void SetRightPlayerScored(string Text) {  RightPlayerScore.SetText(Text); }
    
  
}
