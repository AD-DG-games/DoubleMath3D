using Fusion;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManger : NetworkBehaviour
{
    //[SerializeField] ScoreField score;
    [SerializeField] PlatfromManager[] platfroms;
    [SerializeField] ScreanManager[] screans;
    [SerializeField] int min = 0;
    [SerializeField] int max = 10;
    [SerializeField] int howCorrect = 3;
    [SerializeField] int maxTime;
    private int num;
    private int[] chosenPlatfroms;
    private int timeLeft;

    void SetPlatfrom(int index, bool isChosen)
    {
        int ans = num;
        if (!isChosen)
        {
            while (ans == num)
            {
                ans = Random.Range(min, max + 1);
            }
        }
        int a = Random.Range(min, max + 1);
        if (a > ans)
        {
            int b = a - ans;
            platfroms[index].SetNumbers(a, '-', b);
        }
        else
        {
            int b = ans - a;
            platfroms[index].SetNumbers(a, '+', b);
        }
    }
    void NewRound()
    {
        num = Random.Range(min, max + 1);
        //Set Platfrom data
        for (int i = 0; i < platfroms.Length; i++)
        {
            platfroms[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < chosenPlatfroms.Length; i++)
        {
            chosenPlatfroms[i] = Random.Range(0, platfroms.Length);
        }
        for (int i = 0; i < platfroms.Length; i++)
        {
            SetPlatfrom(i, chosenPlatfroms.Contains(i));
        }
        //Set Screans data
        foreach (var screan in screans)
        {
            screan.SetTime(maxTime);
            screan.SetNumber(num);
        }
        

        StartCoroutine(Countdown());
    }
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(DateTime.Now.Minute);
        platfroms = new PlatfromManager[9];
        screans = new ScreanManager[4];
        for (int i = 1; i <= 9; i++)
        {
            string name = "Floor (" + i + ")";
            platfroms[i-1] = GameObject.Find(name).GetComponent<PlatfromManager>();
        }
        for (int i = 1; i <= 4; i++)
        {
            string name = "TV (" + i + ")";
            screans[i-1] = GameObject.Find(name).GetComponent<ScreanManager>();
        }
        timeLeft = maxTime;
        chosenPlatfroms = new int[howCorrect];
        NewRound();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (timeLeft == 0)
        {
            timeLeft = maxTime;
            StartCoroutine(EndRound());
        }
    }
    public IEnumerator EndRound()
    {
        for (int i = 0; i < platfroms.Length; i++)
        {
            if (!chosenPlatfroms.Contains(i))
            {
                platfroms[i].gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(2);
        NewRound();
    }
    public IEnumerator Countdown()
    {
        while(timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            foreach (var screan in screans)
            {
                screan.SetTime(timeLeft);
            }
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        throw new NotImplementedException();
    }
}
