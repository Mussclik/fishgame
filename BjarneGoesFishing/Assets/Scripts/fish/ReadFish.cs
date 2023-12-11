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
    [Serializable]
    public class FishInfo
    {
        public string fishname, description;
        public int points, tier;
        public int minDepth, maxDepth;


    }

    [SerializeField] string[] lines;

    string readType;

    [SerializeField] TextAsset fishList; /* itemCardList, mutationCardList;
        [SerializeField] CreatureCard[] creatureCard;
        [SerializeField] ItemCard[] itemCard;
        [SerializeField] MutationCard[] mutationCard;
                                                     */
    [SerializeField]
    public List<FishInfo> fishies;


    private void OnValidate() //this be stoled
    {

        // the ? is a short way of asking if it does not equal null then continue, if it does equal null then return lines = nulll
        lines = fishList ? fishList.text.Split(new[]
        {
                Environment.NewLine
            }, StringSplitOptions.RemoveEmptyEntries) : null; // if creaturecardlist equals true then it makes a new split every new line, also remove empty lines as an addon(?) and if it equals false return null

        fishies.Clear();

        if (lines != null)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(", ");
                readType = parts[0].ToLower(); //buhbuh
                switch (readType)
                {
                    case "f": //creature card
                        fishies.Add(ConvertToFish(lines[i]));
                        Debug.Log("fish");
                        break;

                    case "ignore":
                    case "ign":
                        Debug.Log("notfish");
                        break;

                    default:
                        Debug.LogWarning($"[{gameObject.name}.ReadFish.OnValidate(switch): default case]");
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

    private FishInfo ConvertToFish(string line)
    {
        string[] parts = line.Split(", "); // turns a string into array depending on the Split() parameters

        FishInfo fishinfo = new FishInfo();
        fishinfo.fishname = parts[1]; //uuuuhhhh, i think so int.tryparse(string, output int) ?(if)  truevalue : falsevalue     so if tryparse returns true, the line will give whats left of the :, but if false then it returns what is to the right.
        fishinfo.description = AddNewLines(parts[2], "¤"); //because of some fucky wuckys, the notes are out of order
        fishinfo.points = int.TryParse(parts[3], out int output) ? output : 0; // int.TryParse(parts[4]) returns a true/false if it can convert it or not, you can give it an out variable to put the result into
        fishinfo.tier = int.TryParse(parts[4], out output) ? output : 0; //baseattack = AttemptConvertToInt, if true, return output, if false return 0;     ? output = if true return output,   : 0 = if false return 0
        fishinfo.minDepth = int.TryParse(parts[5], out output) ? output : 0;
        fishinfo.maxDepth = int.TryParse(parts[6], out output) ? output : 0; //buh buh
        return fishinfo;


        //return new FishInfo()
        //{
        //    name = parts[1], //uuuuhhhh, i think so int.tryparse(string, output int) ?(if)  truevalue : falsevalue     so if tryparse returns true, the line will give whats left of the :, but if false then it returns what is to the right.
        //    description = AddNewLines(parts[2], "¤"), //because of some fucky wuckys, the notes are out of order
        //    points = int.TryParse(parts[3], out int output) ? output : 0, // int.TryParse(parts[4]) returns a true/false if it can convert it or not, you can give it an out variable to put the result into
        //    tier = int.TryParse(parts[4], out output) ? output : 0, //baseattack = AttemptConvertToInt, if true, return output, if false return 0;     ? output = if true return output,   : 0 = if false return 0
        //    minDepth = int.TryParse(parts[5], out output) ? output : 0,
        //    maxDepth = int.TryParse(parts[6], out output) ? output : 0, //buh buh
        //};
    }
}

