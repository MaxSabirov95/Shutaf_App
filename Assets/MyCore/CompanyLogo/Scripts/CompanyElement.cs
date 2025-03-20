using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyElement : MonoBehaviour
{
    public void ScaleZero()
    {
        transform.localScale = Vector3.zero;
    }

    public void ScaleUp(float time)
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
            "scale",Vector3.one,
            "time", time,
            "easeType", iTween.EaseType.easeOutBack));
    }
}
