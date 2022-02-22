/*
 * Description:             DotMath.cs
 * Author:                  TONYTANG
 * Create Date:             2022/02/21
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DotMath.cs
/// 点乘学习
/// 点乘计算两个向量的相似性
/// 点乘计算两个向量是否垂直以及夹角角度
/// </summary>
[ExecuteInEditMode]
public class DotMath : MonoBehaviour
{
    /// <summary>
    /// 起点对象1
    /// </summary>
    [Header("起点对象1")]
    public GameObject Start1Go;

    /// <summary>
    /// 终点对象1
    /// </summary>
    [Header("终点对象1")]
    public GameObject End1Go;

    /// <summary>
    /// 起点对象2
    /// </summary>
    [Header("起点对象2")]
    public GameObject Start2Go;

    /// <summary>
    /// 终点对象2
    /// </summary>
    [Header("终点对象2")]
    public GameObject End2Go;

    /// <summary>
    /// 两个向量的角度
    /// </summary>
    [Header("两个向量的角度")]
    public double Angle;

    /// <summary>
    /// 第一根线向量
    /// </summary>
    private Vector3 Line1Vector = Vector3.zero;

    /// <summary>
    /// 第二根线向量
    /// </summary>
    private Vector3 Line2Vector = Vector3.zero;

    private void Update()
    {
        if(Start1Go != null && End1Go != null & Start2Go != null && End2Go != null)
        {
            Line1Vector = End1Go.transform.position - Start1Go.transform.position;
            Line2Vector = End2Go.transform.position - Start2Go.transform.position;
            var dotValue = Vector3.Dot(Line1Vector.normalized, Line2Vector.normalized);
            Angle = Math.Acos(dotValue) * Mathf.Rad2Deg;
        }
    }
}