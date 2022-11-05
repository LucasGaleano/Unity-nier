using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Array enemyCount;
    public GameObject gameOverText;
    public GameObject playerCanvas;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject core;
    private List<string> levels = new List<string>();
    private System.Random random = new System.Random();
    private bool levelEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        levels.Add("2");

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        

        if (enemyCount.Length == 0 && !levelEnd)
        {
            gameOverText.SetActive(true);
            playerCanvas.SetActive(false);
            levelEnd = true;
            StartCoroutine(NextLevel());
        }
    }
    
    void NewRandomLevel()
    {
        int numberOfEnemies = random.Next(2, 4);
        int posZ = random.Next(2, 10);
        int posX = random.Next(-10, 2);
        Instantiate(core, new Vector3(posX, core.transform.position.y, posZ), Quaternion.identity);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            posZ = random.Next(2, 10);
            posX = random.Next(-10, 2);
            GameObject newEnemy = choice(enemies);
            Instantiate(newEnemy, new Vector3(posX, newEnemy.transform.position.y, posZ), Quaternion.identity);
            Instantiate(newEnemy, new Vector3(-posX, newEnemy.transform.position.y, posZ), Quaternion.identity);
        }
    }

    GameObject choice(List<GameObject> list)
    {
        return list[random.Next(list.Count)];
    }

    IEnumerator NextLevel()
    {

        yield return new WaitForSeconds(3);

        NewRandomLevel();
        //SceneManager.LoadScene("Level 2");
        //levels.RemoveAt(0);
        gameOverText.SetActive(false);
        playerCanvas.SetActive(true);
        levelEnd = false;

    }



}
