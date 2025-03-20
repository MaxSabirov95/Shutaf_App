using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ItweenManager
{
    // iTween.EaseType.easeOutExpo = Default
    public static void MoveToOnXorY(GameObject _object, string xy, float position, float time, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.MoveTo(_object, iTween.Hash(
                        xy, position,
                        "time", time,
                        "easetype", easeType,
                        "islocal", isLocal,
                        "oncompleteaction", new Action(() =>
                        {
                            callBack?.Invoke();
                        })
                    ));
    }
    public static void MoveFromSpeed(GameObject _object, Vector3 position, float speed, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.MoveFrom(_object, iTween.Hash(
                        "position", position,
                        "speed", speed,
                        "easetype", easeType,
                        "islocal", isLocal,
                        "oncompleteaction", new Action(() =>
                        {
                            callBack?.Invoke();
                        })
                    ));
    }

    public static void ScaleTo(GameObject _object, Vector3 scale, float time, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.ScaleTo(_object, iTween.Hash
        (
            "scale", scale,
            "time", time,
            "easetype", easeType,
            "islocal", isLocal,
            "oncompleteaction", new Action(() =>
            {
                callBack?.Invoke();
            })
        ));
    }

    public static void ScaleToSpeed(GameObject _object, Vector3 scale, float speed, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.ScaleTo(_object, iTween.Hash
        (
            "scale", scale,
            "speed", speed,
            "easetype", easeType,
            "islocal", isLocal,
            "oncompleteaction", new Action(() =>
            {
                callBack?.Invoke();
            })
        ));
    }
    public static void ScaleToXYZ(GameObject _object, string xyz, float scale, float time, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.ScaleTo(_object, iTween.Hash
        (
            xyz, scale,
            "time", time,
            "easetype", easeType,
            "islocal", isLocal,
            "oncompleteaction", new Action(() =>
            {
                callBack?.Invoke();
            })
        ));
    }
    public static void FadeTo(GameObject _object, float alpha, float time, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.FadeTo(_object, iTween.Hash
                    (
                        "alpha", alpha,
                        "time", time,
                        "easetype", easeType,
                        "islocal", isLocal,
                        "oncompleteaction", new Action(() =>
                        {
                            callBack?.Invoke();
                        })
                    ));
    }

    public static void SpeedFadeTo(GameObject _object, float alpha, float speed, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.FadeTo(_object, iTween.Hash
                    (
                        "alpha", alpha,
                        "speed", speed,
                        "easetype", easeType,
                        "islocal", isLocal,
                        "oncompleteaction", new Action(() =>
                        {
                            callBack?.Invoke();
                        })
                    ));
    }

    public static void TimeMoveTo(GameObject _object, Vector3 position, float time, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.MoveTo(_object, iTween.Hash(
                        "position", position,
                        "time", time,
                        "easetype", easeType,
                        "islocal", isLocal,
                        "oncompleteaction", new Action(() =>
                        {
                            callBack?.Invoke();
                        })
                    ));
    }

    public static void SpeedMoveTo(GameObject _object, Vector3 position, float speed, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.MoveTo(_object, iTween.Hash(
                        "position", position,
                        "speed", speed,
                        "easetype", easeType,
                        "islocal", isLocal,
                        "oncompleteaction", new Action(() =>
                        {
                            callBack?.Invoke();
                        })
                    ));
    }

    public static void RotateTo(GameObject _object, string xyz, float rotation, float time, iTween.EaseType easeType, bool isLocal, Action callBack)
    {
        iTween.RotateTo(_object, iTween.Hash(
                 xyz, rotation,
                 "time", time,
                 "easetype", easeType,
                 "islocal", isLocal,
                 "oncompleteaction", new Action(() =>
                 {
                     callBack?.Invoke();
                 })
             ));
    }
    //public void ShakeRotation(GameObject _object, char angle, float degrees, float time, iTween.EaseType easeType, Action callBack)
    //{
    //    iTween.ShakeRotation(_object, iTween.Hash(
    //            angle, degrees,
    //            "time", time,
    //            "easetype", easeType,
    //            "oncompleteaction", new Action(() =>
    //            {
    //                callBack?.Invoke();
    //            })));
    //}
}