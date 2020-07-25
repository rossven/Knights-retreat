using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    // Start is called before the first frame update
    public bool name;
    public List<bool> list = new List<bool>();
    public int currentLevel = 0;
    private int totalSceneCount = 4;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ChooseSelected(int a)
    {
        for (int i = 0; i < 20; i++)
        {
            if (i!=a)
            {
                list[i] = false;
            }
            else
            {
                list[i] = true;
            }
        }
    }

    
    public void NextLevel()
    {
        if (currentLevel==totalSceneCount)
        {
            currentLevel = -1;
        }
        currentLevel += 1;

        SceneManager.LoadScene(currentLevel);

    }

}
