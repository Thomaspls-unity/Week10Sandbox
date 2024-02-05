using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOutKeywork : MonoBehaviour
{
    public bool isSpecialNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandoomNumber valueToReturn = GetRandomeNumber(5);

            isSpecialNumber = valueToReturn.isSpecialNumber;
            Debug.Log(valueToReturn.randomValue);
        }
    }

    public RandoomNumber GetRandomeNumber(int maxValue)
    {
        int randomInt = Random.Range(0, maxValue);

        RandoomNumber randomNumber;

        randomNumber.randomValue = randomInt;
        if (randomInt == 2)
        {
            randomNumber.isSpecialNumber = true;
        }
        else
        {
            randomNumber.isSpecialNumber = false;
        }
        return randomNumber;
    }
}
