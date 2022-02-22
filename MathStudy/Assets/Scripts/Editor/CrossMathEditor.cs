/*
 * Description:             CrossMathEditor.cs
 * Author:                  TONYTANG
 * Create Date:             2022/02/21
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// CrossMathEditor.cs
/// 叉乘Editor绘制
/// </summary>
public class CrossMathEditor : Editor
{
    /// <summary>
    /// 起点对象1属性
    /// </summary>
    SerializedProperty Start1GoProperty;

    /// <summary>
    /// 终点对象1属性
    /// </summary>
    SerializedProperty End1GoProperty;

    /// <summary>
    /// 起点对象2属性
    /// </summary>
    SerializedProperty Start2GoProperty;

    /// <summary>
    /// 终点对象2属性
    /// </summary>
    SerializedProperty End2GoProperty;

    /// <summary>
    /// 第一根连线颜色
    /// </summary>
    private Color Line1Color = Color.red;

    /// <summary>
    /// 第二根连线颜色
    /// </summary>
    private Color Line2Color = Color.green;

    /// <summary>
    /// 第一根线向量
    /// </summary>
    private Vector3 Line1Vector = Vector3.zero;

    /// <summary>
    /// 第二根线向量
    /// </summary>
    private Vector3 Line2Vector = Vector3.zero;

    protected void OnEnable()
    {
        Start1GoProperty = serializedObject.FindProperty("Start1Go");
        End1GoProperty = serializedObject.FindProperty("End1Go");
        Start2GoProperty = serializedObject.FindProperty("Start2Go");
        End2GoProperty = serializedObject.FindProperty("End2Go");
    }

    public void OnSceneGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            if (Start1GoProperty.objectReferenceValue != null && End1GoProperty.objectReferenceValue != null)
            {
                var start1Go = Start1GoProperty.objectReferenceValue as GameObject;
                var start1GoPos = start1Go.transform.position;
                var end1Go = End1GoProperty.objectReferenceValue as GameObject;
                var end1GoPos = end1Go.transform.position;
                Line1Vector = end1GoPos - start1GoPos;
                var size1 = Line1Vector.magnitude;
                Handles.color = Line1Color;
                var line1Quaternion = Quaternion.FromToRotation(start1Go.transform.forward, Line1Vector);
                Handles.ArrowHandleCap(
                    0,
                    start1GoPos,
                    line1Quaternion,
                    size1,
                    EventType.Repaint
                );
            }
            if (Start2GoProperty.objectReferenceValue != null && End2GoProperty.objectReferenceValue != null)
            {
                var start2Go = Start2GoProperty.objectReferenceValue as GameObject;
                var start2GoPos = start2Go.transform.position;
                var end2Go = End2GoProperty.objectReferenceValue as GameObject;
                var end2GoPos = end2Go.transform.position;
                Line2Vector = end2Go.transform.position - start2Go.transform.position;
                var size2 = Line2Vector.magnitude;
                Handles.color = Line2Color;
                var line2Quaternion = Quaternion.FromToRotation(start2Go.transform.forward, Line2Vector);
                Handles.ArrowHandleCap(
                    0,
                    start2Go.transform.position,
                    line2Quaternion,
                    size2,
                    EventType.Repaint
                );
            }
        }
    }
}