using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Unity.VisualScripting;

public class ReadFish : MonoBehaviour
{
    public string name;
    public string description;




    [SerializeField] string[] lines;

    string cardType;

    [SerializeField] TextAsset cardList; /* itemCardList, mutationCardList;
        [SerializeField] CreatureCard[] creatureCard;
        [SerializeField] ItemCard[] itemCard;
        [SerializeField] MutationCard[] mutationCard;
                                                     */
    [SerializeField]
    public List<CreatureCard> creatureList;
    [SerializeField]
    public List<ItemCard> itemList;
    [SerializeField]
    public List<MutationCard> mutationList;


    private void OnValidate() //this be stoled
    {

        // the ? is a short way of asking if it does not equal null then continue, if it does equal null then return lines = nulll
        lines = cardList ? cardList.text.Split(new[]
        {
                Environment.NewLine
            }, StringSplitOptions.RemoveEmptyEntries) : null; // if creaturecardlist equals true then it makes a new split every new line, also remove empty lines as an addon(?) and if it equals false return null

        creatureList.Clear();
        itemList.Clear();
        mutationList.Clear();

        if (lines != null)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(", ");
                cardType = parts[0].ToLower(); //buhbuh
                switch (cardType)
                {
                    case "c": //creature card
                        creatureList.Add(ConvertCreatureText(lines[i]));
                        break;

                    case "i": //item card
                        itemList.Add(ConvertItemText(lines[i]));
                        break;

                    case "m": //mutation card
                        mutationList.Add(ConvertMutationText(lines[i]));
                        break;

                    case "ignore":
                        break;

                    case "ign":
                        break;

                    default:
                        Debug.LogWarning("invalid card type");
                        break;
                }
            }


            /*
            creatureCard = new CreatureCard[lines.Length];
            for (int i = 0; i < creatureCard.Length; i++)
            {
                Debug.Log(lines.Length + "lineslenght");
                Debug.Log(i + "i");
                Debug.Log(creatureCard.Length + "infolenght");
                creatureCard[i] = ConvertCreatureText(lines[i]);
            }
            */
        }

    }

    private string AddNewLines(string stringInput, string charToLine, bool replaceChar = false)
    {
        if (replaceChar)
        {
            stringInput = stringInput.Replace(charToLine, Environment.NewLine);
        }
        else
        {
            stringInput = stringInput.Replace(charToLine, Environment.NewLine + charToLine);
        }

        return stringInput;
    }

    private CreatureCard ConvertCreatureText(string line)
    {
        string[] parts = line.Split(", "); // turns a string into array depending on the Split() parameters
        int tempInt = 0;
        switch (parts[8].ToLower())
        {
            case "mint":
                tempInt = 1;
                break;

            case "sour":
                tempInt = 2;
                break;

            case "salt":
                tempInt = 3;
                break;

            case "spic":
                tempInt = 4;
                break;

            default:
                tempInt = 0;
                break;
        }

        return new CreatureCard
        {

            name = parts[1], //uuuuhhhh, i think so int.tryparse(string, output int) ?(if)  truevalue : falsevalue     so if tryparse returns true, the line will give whats left of the :, but if false then it returns what is to the right.
            description = AddNewLines(parts[2], "¤"),
            //because of some fucky wuckys, the notes are out of order
            baseHealth = int.TryParse(parts[3], out int output) ? output : 0, // int.TryParse(parts[4]) returns a true/false if it can convert it or not, you can give it an out variable to put the result into
            baseAttack = int.TryParse(parts[4], out output) ? output : 0, //baseattack = AttemptConvertToInt, if true, return output, if false return 0;     ? output = if true return output,   : 0 = if false return 0
            cost = int.TryParse(parts[5], out output) ? output : 0,
            tier = int.TryParse(parts[6], out output) ? output : 0, //buh buh



            family = parts[7].ToLower(),
            weakness = tempInt,

        };
    }
    private ItemCard ConvertItemText(string line)
    {
        string[] parts = line.Split(", "); // turns a string into array depending on the Split() parameters
        return new ItemCard
        {
            name = parts[1],
            description = AddNewLines(parts[2], "¤"),
            tier = int.TryParse(parts[3], out int output) ? output : 0, //buh buh buh buh
            cost = int.TryParse(parts[4], out output) ? output : 0
        };
    }
    private MutationCard ConvertMutationText(string line)
    {
        string[] parts = line.Split(", "); // turns a string into array depending on the Split() parameters
        return new MutationCard
        {
            name = parts[1],
            description = AddNewLines(parts[2], "¤"),
        };
    }
}
