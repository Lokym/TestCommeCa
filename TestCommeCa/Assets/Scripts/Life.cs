using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Life : Singleton<Life> {

    public int LifeNb = 10;
    public Text LifeText;




    private void Update()
    {
        DontDestroyOnLoad(this);

        LifeText.text = LifeNb.ToString();
        
    }
}
