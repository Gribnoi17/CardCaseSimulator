using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    private MenuManager MM;
    public Transform pointPanel;

    [Header("Цена кейса")]
    public int price;

    [Header("Шанс выпадания карт")]
    public int minCard;
    public int maxCard;

    [Header("Количество выпавших карт")]
    public int minQuantity;
    public int maxQuantity;
    private int quantity;
    private int random;

    void Start()
    {
        quantity = Random.Range(minQuantity, maxQuantity + 1); //определяется рандомное количество карт
        MM = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();

        for (int i = 0; i < quantity; i++) //создаются карты, пока не доёдет до указанного рандомного значения
        {
            int chance = Random.Range(minCard, maxCard + 1); //указывается шанс выпадания
            random = Random.Range(0, MM.Items.Count); //выбирается тип карты для выпадения
            for (int a = 0; a <= MM.Items.Count; a++){ //происходит спавн карт, учитывая шанс и редкость
                if (a == random){
                    if (chance >= MM.Items[random].chanceCard){
                        CreateCard();
                    }else{
                        random -= 1;
                        CreateCard();
                    }
                }
            }
        }
    }

    public void CreateCard() //метод создание карт
    {
        int randomCard = Random.Range(0, MM.Items[random].card.Length);
        Instantiate(MM.Items[random].card[randomCard], pointPanel.transform.position, Quaternion.identity, pointPanel.transform); //создаётся карта на панеле при открытии
        MM.Items[random].quantity[randomCard] += 1;
        if (MM.Items[random].quantity[randomCard] == 1)
        {
            Instantiate(MM.Items[random].card[randomCard], MM.pointSpawnCollection.transform.position, Quaternion.identity, MM.pointSpawnCollection.transform); //создаётся карта в коллекции
        }
        MM.SaveGame();
    }
    
    public void ExitPanels() //выход из панели кейса
    {
        Destroy(gameObject);
    }
}
