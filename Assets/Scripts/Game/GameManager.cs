using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform spwanPointTeamBlue;
    [SerializeField] private Transform spwanPointTeamRed;
    [SerializeField] private Transform footBallPrefab;
    [SerializeField] private GameObject tb;
    [SerializeField] private GameObject tr;
    [SerializeField] private GameObject pausemenu;
    [SerializeField] private GameObject tbwinPanel;
    [SerializeField] private GameObject trwinPanel;
    [SerializeField] private Text trScore;
    [SerializeField] private Text tbScore;
    [SerializeField] private Text trScore2;
    [SerializeField] private Text tbScore2;
    [SerializeField] private Transform[] buttons;


    public List<GameObject> players = new List<GameObject>();

    [HideInInspector] public int teamBlueScore;
    [HideInInspector] public int teamRedScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
        tbwinPanel.SetActive(false);
        trwinPanel.SetActive(false);

        int random = Random.Range(1, 6);
        if (random == 2 || random == 4 || random == 6)
        {
            Instantiate(footBallPrefab, spwanPointTeamBlue.position, Quaternion.identity);
        }
        else if (random == 1 || random == 3 || random == 5)
        {
            Instantiate(footBallPrefab, spwanPointTeamRed.position, Quaternion.identity);
        }

        trScore.text = teamRedScore.ToString();
        trScore2.text = teamRedScore.ToString();
        tbScore.text = teamBlueScore.ToString();
        tbScore2.text = teamBlueScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (teamBlueScore >= 3)
        {
            StartCoroutine(GameOverTB());
        }
        else if (teamRedScore >= 3)
        {
            StartCoroutine(GameOverTR());
        }
    }

    IEnumerator GameOverTB()
    {
        yield return new WaitForSeconds(1.1f);
        tbwinPanel.SetActive(true);
        trwinPanel.SetActive(false);

    }

    IEnumerator GameOverTR()
    {
        yield return new WaitForSeconds(1.1f);
        tbwinPanel.SetActive(false);
        trwinPanel.SetActive(true);
    }

    public void SpawnAtTeamBlue()
    {
        teamRedScore++;
        trScore.text = teamRedScore.ToString();
        trScore2.text = teamRedScore.ToString();
        tr.SetActive(true);
        StartCoroutine(TBtime());
    }

    IEnumerator TBtime()
    {
        yield return new WaitForSeconds(1f);
        tr.SetActive(false);
        Instantiate(footBallPrefab, spwanPointTeamBlue.position, Quaternion.identity);
    }



    public void SpawnAtTeamRed()
    {
        teamBlueScore++;
        tbScore.text = teamBlueScore.ToString();
        tbScore2.text = teamBlueScore.ToString();
        tb.SetActive(true);
        StartCoroutine(TRtime());
    }

    IEnumerator TRtime()
    {
        yield return new WaitForSeconds(1f);
        tb.SetActive(false);
        Instantiate(footBallPrefab, spwanPointTeamRed.position, Quaternion.identity);
    }

    public void Pause()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        SceneManager.LoadScene(0);
    }
    void ButtonSizeReset()
    {
        foreach (var button in buttons)
        {
            button.localScale = Vector3.one;
        }
    }
}
