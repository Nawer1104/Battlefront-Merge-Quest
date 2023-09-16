using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Level> levels;

    private int startIndex = 0;

    private int currentIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentIndex = startIndex;

        levels[currentIndex].gameObject.SetActive(true);
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void CheckLevelUp()
    {
        if (levels[currentIndex].gameObjects.Count == 0)
        {
            levels[currentIndex].gameObject.SetActive(false);

            currentIndex += 1;

            StartCoroutine(LevelUp());
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(1);

        if (currentIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            currentIndex = 0;
        }

        levels[currentIndex].gameObject.SetActive(true);
    }

    public void ReSetCurrentLevel()
    {
        //levels[currentIndex].AddComponents();
    }
}