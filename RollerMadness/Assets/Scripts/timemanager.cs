using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timemanager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameover=false;

    [SerializeField] private float levelFinishTime = 5f;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(gameFinished==false && gameover==false)
        {
            UpdateTheTimer();

        }
        if (Time.timeSinceLevelLoad>=levelFinishTime && gameover==false)
        {
            
            gameFinished =true;
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);
            UpdateObjectList("objects");
            UpdateObjectList("enemy");
            foreach (GameObject allObjets in destroyAfterGame) 
            {
                Destroy(allObjets);
            }
        }
        if (gameover==true)
        {
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
            UpdateObjectList("objects");
            UpdateObjectList("enemy");
            foreach (GameObject allObjets in destroyAfterGame)
            {
                Destroy(allObjets);
                
            }
        }
       
  
    }
    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));

    }
    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }
}
