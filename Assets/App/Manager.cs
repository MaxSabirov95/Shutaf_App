using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class User
{
    [HideInInspector] public float percents;
    [HideInInspector] public float paid;

    public bool isAboveAvarage = false;
    public bool isCool = false;
    public float totalToPayPerUser;

    public Text userNameText;
    public InputField percentsText;
    public InputField numberText;

    public void GetPercents()
    {
        int.TryParse(percentsText.text, out int percentsValue);
        percents = percentsValue / 100f;
    }

    public void GetPaidNumber()
    {
        float.TryParse(numberText.text, out paid);
    }

    public void SetPaidText()
    {
        numberText.text = paid.ToString();
    }

    public void TotalNeedToPay(float totalPaid)
    {
        totalToPayPerUser = totalPaid * percents;
    }

    public void IsOverPaid()
    {
        if (paid > totalToPayPerUser)
        {
            isAboveAvarage = true;
        }
        else if (paid == totalToPayPerUser)
        {
            isCool = true;
        }
    }

    public void ResetProperties()
    {
        isAboveAvarage = false;
        isCool = false;
    }
}

public class Manager : MonoBehaviour
{
    public User[] users;

    private List<User> _needPayUsers;
    private List<User> _overPaidUsers;

    // via link inspector
    public void Calculate()
    {
        Debug.Log("In");

        float total = 0;
        _needPayUsers = new();
        _overPaidUsers = new();

        for (int i = 0; i < users.Length; i++)
        {
            users[i].ResetProperties();
            users[i].GetPaidNumber();
            users[i].GetPercents();
            total += users[i].paid;
        }

        for (int i = 0; i < users.Length; i++)
        {
            users[i].TotalNeedToPay(total);
            users[i].IsOverPaid();

            if (users[i].isAboveAvarage)
            {
                _overPaidUsers.Add(users[i]);
            }
            else
            {
                if (!users[i].isCool)
                {
                    _needPayUsers.Add(users[i]);
                }
            }
        }

        while(_needPayUsers.Count > 0 && _overPaidUsers.Count > 0)
        {
            User toPay = _needPayUsers[0];
            User getPay = _overPaidUsers[0];

            float userToPay = toPay.totalToPayPerUser - toPay.paid;
            float userGettingPay = getPay.paid - getPay.totalToPayPerUser;

            if (userToPay <= userGettingPay)
            {
                Debug.Log("1: " + toPay.userNameText.text + " need to give " + getPay.userNameText.text + " " + userToPay);
                toPay.paid += userToPay;
                getPay.paid -= userToPay;
                toPay.SetPaidText();
                getPay.SetPaidText();

                _needPayUsers.Remove(toPay);
                if (userToPay == userGettingPay)
                    _overPaidUsers.Remove(toPay);
            }
            else if (userToPay > userGettingPay)
            {
                Debug.Log("2: " + toPay.userNameText.text + " need to give " + getPay.userNameText.text + " " + userGettingPay);
                toPay.paid += userGettingPay;
                getPay.paid -= userGettingPay;
                toPay.SetPaidText();
                getPay.SetPaidText();

                _overPaidUsers.Remove(getPay);
            }
        }
    }
}
