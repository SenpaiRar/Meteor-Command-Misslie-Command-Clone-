using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoHandler : MonoBehaviour {

    public Text AmmoText;
    public string AmmoPrefix;

    void Start()
    {
        Player.AmmoEvent += UpdateAmmoText;

        AmmoText.text = AmmoPrefix;
    }
    
    void UpdateAmmoText(int AmmoCount)
    {
        AmmoText.text = AmmoPrefix + AmmoCount.ToString(); 
    }
}
