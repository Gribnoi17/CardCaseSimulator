using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private CaseManager CM;
    public bool isInfoCard;

    [Header("Переменные")]
    public int money;
    public Text textMoney;

    [Header("Сцена")]
    public GameObject panelCollection; //это панель с коллекцией карт
    public Transform pointSpawnCollection; //это то место, в котором спавняться карты
    public Transform pointSpawnCase; //это то место, в котором спавняться кейсы
    public GameObject errorMessage; //это панель которая показывает что нехватает денег

    [Header("Кейсы")]
    public Text[] priceCase; //текст выводящий стоимость кейса
    public GameObject[] panelCase; //панель кейсов (сам же кейс)

    [Header("Карты")]
    public List<Item> Items; //класс указанный в низу скрипта с данными колекции карт

    void Start()
    {
        LoadGame();

        for (int i = 0; i < panelCase.Length; i++){ //введенная цена автоматически в начале игры подстраивается в свой текст
            if (panelCase[i].GetComponent<CaseManager>().price == 0){ //если цена не указана на кейсе, то он становится бесплатным
                priceCase[i].text = "Free";
            }else{ //если цена указана, то текст выводит её в текст
                priceCase[i].text = panelCase[i].GetComponent<CaseManager>().price + "$";
            }
        }
    }

    void Update()
    {
        textMoney.text = "Money: " + money; //текст выводит количество монет
    }

    public void OpenCaseButton1() //при нажатии на кнопку первого кейса, будет происхоить спавн определённого кейса
    {
        if (panelCase[0].GetComponent<CaseManager>().price <= money){ //если денег больше цены кейса, то происходит покупка
            Instantiate(panelCase[0], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
            CM = GameObject.FindGameObjectWithTag("Case").GetComponent<CaseManager>();
            money -= panelCase[0].GetComponent<CaseManager>().price;
            PlayerPrefs.SetInt("money", money);
        }else{ //если нехватает денег, тогда появляется панель ошибки
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
        }else{ //если нехватает денег, тогда появляется панель ошибки
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
        }else{ //если нехватает денег, тогда появляется панель ошибки
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
        }else{ //если нехватает денег, тогда появляется панель ошибки
            errorMessage.SetActive(true);
            Invoke("EnterMessageAnim", 2f);
        }
    }

    public void RandomOpenCase() //при нажатии на кнопку рандомного кейса, будет происходить спавн рандомного кейса
    {
        int chance = 0; //вводится переменная шанса
        int randomCase = Random.Range(0, panelCase.Length); //количество кейсов
        int allRandom = Random.Range(1, 101); //шанс выпадания

        switch(randomCase) //присвоение шанса определённым кейсам
        {
            case 1:
                chance = 0;
                break;
            case 2:
                chance = 50;
                break;
            case 3:
                chance = 80;
                break;
            case 4:
                chance = 95;   
                break;
        }

        if (allRandom >= chance){ //если рандом больше шанса, то тогда происходит спавн определённого кейса
            Instantiate(panelCase[randomCase], pointSpawnCase.transform.position, Quaternion.identity, pointSpawnCase.transform);
        }else{ //в ином случае операци будет повторятся
            RandomOpenCase();
        }
    }


    public void CollectionButton(){ //при нажатии открывается панель с коллекцией
        panelCollection.SetActive(true);
    }

    public void ExitCollectionButton(){ //при нажатии закрывается панель с коллекцией
        panelCollection.SetActive(false);
    }

    public void TakeLoan(){ //при нажатии начисляется 500 монет
        money += 500;
        PlayerPrefs.SetInt("money", money);
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
}

[System.Serializable]
public class Item
{
    public string typeCard; //тип карт
    public int chanceCard; //шанс выпадения карт
    public GameObject[] card; //сами карты
    public int[] quantity; //данные карт (их должно быть столько, сколько самих карт)
}
