/*
 * Description:             HandlesUtilities.cs
 * Author:                  TONYTANG
 * Create Date:             2022/03/17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// HandlesUtilities.cs
/// Handles辅助工具
/// </summary>
public static class HandlesUtilities
{
    /// <summary>
    /// 绘制有颜色的文本
    /// </summary>
    /// <param name="pos">坐标</param>
    /// <param name="text">文本</param>
    /// <param name="color">颜色</param>
    public static void DrawColorLable(Vector3 pos, string text, Color color)
    {
        Color preColor = GUI.color;
        GUI.color = color;
        Handles.Label(pos, text);
        GUI.color = preColor;
    }
}