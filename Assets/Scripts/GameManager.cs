using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour//make the audio clip stay playing
{
    private List<GameObject> OptionsPosition;//make a list to generate options in random position to enhance replayability; the real position in-game
    private List<GameObject> PossibleOptionsPosition;//possible position
    public static GameManager Instance;
    public static float usedTime;
    
    //private Scene scene;

    public TMP_InputField inputField;

    public string userName;
    public string UserName
    {
        get
        {
            if (userName == string.Empty)
                userName = PlayerPrefs.GetString ("playerName", "Player");
            return userName;
        }
        set
        {
            userName = value;
            PlayerPrefs.SetString ("playerName", userName);
        }
    }
    
    void Awake()
    {

        if (Instance == null) //Instance has not been set
        {
            DontDestroyOnLoad(gameObject); //don't destroy
            Instance = this; //and set instance to this GameManager
        }
        else //Instance is set
        {
            Destroy(gameObject);
        }
        
        inputField.text = UserName;
    }
    public void SetUserName (string text)
    {
        UserName = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            UserName = inputField.text;
            SceneManager.LoadScene(1);
            Debug.Log("Return key was pressed.");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != "StartScene" && SceneManager.GetActiveScene().name != "EndScene")
        {
            OptionsPosition = new List<GameObject>();
            PossibleOptionsPosition = new List<GameObject>();
            foreach (GameObject Option in GameObject.FindGameObjectsWithTag("Option"))//put all objects with Option tag into the list
            {
                OptionsPosition.Add(Option);
            }

            foreach (GameObject TestOption in GameObject.FindGameObjectsWithTag("TestPosition"))//put all objects with TestPosition tag into the list
            {
                PossibleOptionsPosition.Add(TestOption);
            }

            foreach (GameObject option in OptionsPosition)//randomly choose one position from PossiblePosition list
            {
                int i = Random.Range(0, PossibleOptionsPosition.Count);//count the number of option's position
                option.transform.position = PossibleOptionsPosition[i].transform.position;//set the position
                PossibleOptionsPosition.RemoveAt(i);//remove the position that has been used
            }

            //OptionsPosition = GameObject.FindGameObjectsWithTag("Option");
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }
    }
}
