using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public static int selectedLevel;
    public int level;
    public Text levelText;
    void Start()
    {
        levelText.text = level.ToString();
    }

    public void OpenScene ()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
