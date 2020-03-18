using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        StartCoroutine(wait());


    }
    public IEnumerator wait()
    {
        do
        {
            yield return new WaitForSecondsRealtime(0.01f);
        }
        while (GameObject.FindGameObjectWithTag("GameController") == null);
        Debug.Log(GameObject.FindGameObjectWithTag("GameController"));
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Play(0, 100, 150, 0.2f, 5, 1, 12, 10, 1);
    }
}
