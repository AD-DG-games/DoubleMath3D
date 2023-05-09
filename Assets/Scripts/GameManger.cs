using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(TextMeshPro))]
public class GameManger : MonoBehaviour
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
}
