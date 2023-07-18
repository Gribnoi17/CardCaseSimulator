using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private CaseManager CM;
    public bool isInfoCard;

    private int cardLevel1 = 0;
    private int cardLevel2 = 0;
    private int cardLevel3 = 0;
    private int cardAll = 0;
    private bool canOpenRandomCase;

    [Header("Переменные")]
    public int money;
    public Text textMoney;

    [Header("Сцена")]
    public GameObject panelCollection; //это панель с коллекцией карт
    public Transform pointSpawnCollection; //это то место, в котором спавняться карты
    public Transform pointSpawnCase; //это то место, в котором спавняться кейсы
    public GameObject errorMessage; //это панель которая показывает что нехватает денег
    public Image openRandomCaseImage; //это панель которая показывает что нехватает денег
    public GameObject openRandomCaseText; //это панель которая показывает что нехватает денег
    public GameObject panelTeacher; 
    public GameObject panelMoney; 

    [Header("Кейсы")]
    public Text[] priceCase; //текст выводящий стоимость кейса
    public GameObject[] panelCase; //панель кейсов (сам же кейс)

    [Header("Карты")]
    public List<Item> Items; //класс указанный в низу скрипта с данными колекции карт
    public Text[] countCards;

    void Start()
    {
        LoadGame();
        canOpenRandomCase = true;
        for (int i = 0; i < panelCase.Length; i++){ //введенная цена автоматически в начале игры подстраивается в свой текст
            if (panelCase[i].GetComponent<CaseManager>().price == 0){ //если цена не указана на кейсе, то он становится бесплатным
                priceCase[i].text = "Бесплатно";
            }else{ //если цена указана, то текст выводит её в текст
                priceCase[i].text = panelCase[i].GetComponent<CaseManager>().price + "$";
            }
        }
    }

    private void OnEnable()
    {
        YandexGame.OpenVideoEvent += AddReward;
    }
    private void OnDestroy()
    {
        YandexGame.OpenVideoEvent -= AddReward;
    }

    void Update()
    {
        textMoney.text = "Деньги: " + money + "$"; //текст выводит количество монет
    }


    public void OpenCaseButton1() //при нажатии на кнопку первого кейса, будет происхоить спавн определённого кейса
    {
        if (panelCase[0].GetComponent<CaseManager>().price <= money){ //если денег больше цены кейса, то происходит покупка
            Instantiate(panelCase[0], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
            CM = GameObject.FindGameObjectWithTag("Case").GetComponent<CaseManager>();
            money -= panelCase[0].GetComponent<CaseManager>().price;
            PlayerPrefs.SetInt("money", money);
            EventManager.OnCaseOpened();
        }
        else{ //если нехватает денег, тогда появляется панель ошибки
            errorMessage.SetActive(true);
            Invoke("EnterMessageAnim", 2f);
        }
    }

    public void OpenCaseButton2() //при нажатии на кнопку второго кейса, будет происхоить спавн определённого кейса
    {
        if (panelCase[1].GetComponent<CaseManager>().price <= money){ //если денег больше цены кейса, то происходит покупка
            Instantiate(panelCase[1], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
            CM = GameObject.FindGameObjectWithTag("Case").GetComponent<CaseManager>();
            money -= panelCase[1].GetComponent<CaseManager>().price;
            PlayerPrefs.SetInt("money", money);
            EventManager.OnCaseOpened();
        }
        else{ //если нехватает денег, тогда появляется панель ошибки
            errorMessage.SetActive(true);
            Invoke("EnterMessageAnim", 2f);
        }
    }

    public void OpenCaseButton3() //при нажатии на кнопку третьего кейса, будет происхоить спавн определённого кейса
    {
        if (panelCase[2].GetComponent<CaseManager>().price <= money){ //если денег больше цены кейса, то происходит покупка
            Instantiate(panelCase[2], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
            CM = GameObject.FindGameObjectWithTag("Case").GetComponent<CaseManager>();
            money -= panelCase[2].GetComponent<CaseManager>().price;
            PlayerPrefs.SetInt("money", money);
            EventManager.OnCaseOpened();
        }
        else{ //если нехватает денег, тогда появляется панель ошибки
            errorMessage.SetActive(true);
            Invoke("EnterMessageAnim", 2f);
        }
    }

    public void OpenCaseButton4() //при нажатии на кнопку четвёртого кейса, будет происхоить спавн определённого кейса
    {
        if (panelCase[3].GetComponent<CaseManager>().price <= money){ //если денег больше цены кейса, то происходит покупка
            Instantiate(panelCase[3], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
            CM = GameObject.FindGameObjectWithTag("Case").GetComponent<CaseManager>();
            money -= panelCase[3].GetComponent<CaseManager>().price;
            PlayerPrefs.SetInt("money", money);
            EventManager.OnCaseOpened();
        }
        else{ //если нехватает денег, тогда появляется панель ошибки
            errorMessage.SetActive(true);
            Invoke("EnterMessageAnim", 2f);
        }
    }

    public void RandomOpenCase() //при нажатии на кнопку рандомного кейса, будет происходить спавн рандомного кейса
    {
        if (canOpenRandomCase == true)
        {
            int chance = 0; //вводится переменная шанса
            int randomCase = Random.Range(0, panelCase.Length); //количество кейсов
            int allRandom = Random.Range(1, 101); //шанс выпадания

            switch (randomCase) //присвоение шанса определённым кейсам
            {
                case 0:
                    chance = 0;
                    break;
                case 1:
                    chance = 70;
                    break;
                case 2:
                    chance = 90;
                    break;
                case 3:
                    chance = 95;
                    break;
            }
            if (allRandom >= chance)
            { //если рандом больше шанса, то тогда происходит спавн определённого кейса
                Instantiate(panelCase[randomCase], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
                EventManager.OnCaseOpened();
            }
            else
            { //в ином случае операци будет повторятся
                RandomOpenCase();
            }
            StartCoroutine(RandomCaseTimer(30));
        }
    }

    private IEnumerator RandomCaseTimer(float durationInSec)
    {
        canOpenRandomCase = false;
        openRandomCaseImage.fillAmount = 0;
        openRandomCaseText.SetActive(false);
        float timer = 0f;
        while (timer < durationInSec)
        {
            timer += Time.deltaTime;
            float currentFillAmount = Mathf.Lerp(0, 1, timer / durationInSec);
            openRandomCaseImage.fillAmount = currentFillAmount;
            yield return null;
        }
        openRandomCaseText.SetActive(true);
        canOpenRandomCase = true;
    }

    public void ExitCollectionButton(){ //при нажатии закрывается панель с коллекцией
        panelCollection.SetActive(false);
        panelMoney.SetActive(true);
    }

    public void ExitTeacherPanelButton()
    { //при нажатии закрывается панель с коллекцией
        panelTeacher.SetActive(false);
    }

    public void AddReward(){ //при нажатии начисляется 500 монет
        
        money += 1000;
        PlayerPrefs.SetInt("money", money);
        YandexGame.NewLeaderboardScores("LeaderBoard", money);
    }

    public void EnterMessageAnim(){ // анимация выключения панели с ошибкой
        errorMessage.SetActive(false);
    }

    public void SaveGame() //сохранение количества каждой редкости карт
    {
        for (int i = 0; i < Items.Count; i++)
        {
            for (int a = 0; a < Items[i].quantity.Length; a++)
            {
                PlayerPrefs.SetInt("Items " + i + ", quantity " + a, Items[i].quantity[a]);
            }
        }
    }

    public void LoadGame() //загрузка игры и всех данных
    {
        money = PlayerPrefs.GetInt("money", money);
        for (int i = 0; i < Items.Count; i++) //загрузка редкости
        {
            for (int a = 0; a < Items[i].quantity.Length; a++) //загрузка количества
            {
                Items[i].quantity[a] = PlayerPrefs.GetInt("Items " + i + ", quantity " + a, Items[i].quantity[a]);
                if (Items[i].quantity[a] > 0) //спавн карт у которых есть какое-то кол-во карт
                {
                    Instantiate(Items[i].card[a], pointSpawnCollection.transform.position, Quaternion.identity, pointSpawnCollection.transform);
                }
            }
        }

        cardLevel1 = PlayerPrefs.GetInt("cardLevel1");
        cardLevel2 = PlayerPrefs.GetInt("cardLevel2");
        cardLevel3 = PlayerPrefs.GetInt("cardLevel3");
        cardAll = PlayerPrefs.GetInt("cardAll");
        
    }

    public void DeleteSave() //удаление всех сохранений, достежений, карт и монет
    {
        for (int i = 0; i < Items.Count; i++){
            for (int a = 0; a < Items[i].quantity.Length; a++){
                Items[i].quantity[a] = 0;
                PlayerPrefs.SetInt("Items " + i + ", quantity " + a, Items[i].quantity[a]);
            }
        }

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0); //перезагрузка сцены, для корректного отображения всех нововедений
    }

    public void UpdateCardText()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].typeCard == "Обычная")
            {
                for (int j = 0; j < Items[i].quantity.Length; j++)
                {
                    if (Items[i].quantity[j] == 0)
                    {
                        cardLevel1++;
                        //print("Level1: " + cardLeve1);
                    }
                }
                countCards[0].text = "Обычных открыто " + (8 - cardLevel1) + "/8";
                cardAll += cardLevel1;
                cardLevel1 = 0;
            }
            if (Items[i].typeCard == "Редкая")
            {
                for (int j = 0; j < Items[i].quantity.Length; j++)
                {
                    if (Items[i].quantity[j] == 0)
                    {
                        cardLevel2++;
                        //print("Level1: " + cardLeve1);
                    }
                }
                countCards[1].text = "Редких открыто " + (7 - cardLevel2) + "/7";
                cardAll += cardLevel2;
                cardLevel2 = 0;
            }
            if (Items[i].typeCard == "Легендарная")
            {
                for (int j = 0; j < Items[i].quantity.Length; j++)
                {
                    if (Items[i].quantity[j] == 0)
                    {
                        cardLevel3++;

                    }
                }
                countCards[2].text = "Легендарных открыто " + (3 - cardLevel3) + "/3";
                cardAll += cardLevel3;
                cardLevel3 = 0;
            }
        }
        countCards[3].text = "Всего открыто " + (18 - cardAll) + "/18";
        cardAll = 0;
    }
    public void CollectionButton()
    { //при нажатии открывается панель с коллекцией
        panelCollection.SetActive(true);
        panelMoney.SetActive(false);
        UpdateCardText();
    }
}

[System.Serializable]
public class Item
{
    public string typeCard; //тип карт
    public int chanceCard; //шанс выпадения карт
    public GameObject[] card; //сами карты
    public int[] quantity; //данные карт (их должно быть столько, сколько самих карт)
}
