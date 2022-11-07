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
    public List<GameObject> typeOfEnemies = new List<GameObject>();
    public GameObject core;
    private System.Random random = new System.Random();
    private bool levelEnd = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        

        if (enemyCount.Length == 0 && !levelEnd)
        {
            gameOverText.SetActive(true);
            StartCoroutine(WriteText("H[a]cked_"));
            playerCanvas.SetActive(false);
            levelEnd = true;
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator WriteText(string text)
    {
        string currentText = "";
        for (int i = 0; i < text.Length+1; i++)
        {
            currentText = text.Substring(0, i);
            gameOverText.GetComponent<TextMeshProUGUI>().SetText(currentText);
            yield return new WaitForSeconds(0.1f); 
        }
    }
    
    void NewRandomLevel()
    {
        int numberOfEnemies = random.Next(1, 4);
        int posZ = random.Next(2, 10);
        int posX = 0;
        Instantiate(core, new Vector3(posX, core.transform.position.y, posZ), Quaternion.identity);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            posZ = random.Next(2, 10);
            posX = random.Next(4, 10);
            GameObject newEnemy = choice(typeOfEnemies);
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
        gameOverText.SetActive(false);
        playerCanvas.SetActive(true);
        levelEnd = false;

    }



}
