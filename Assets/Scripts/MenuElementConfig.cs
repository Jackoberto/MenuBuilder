﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public abstract class MenuElementConfig : ScriptableObject
{
    public GameObject objectToCreate;
    public string[] Arguments { get; private set; }
    public string[] Descriptions { get; private set; }
    public bool canCombineArgs;

    public virtual void Awake()
    {
        AutoGenerateArgs();
    }

    protected void AddMenuElement(GameObject gameObject)
    {
        var menuElement = gameObject.AddComponent<MenuElement>();
        menuElement.menuElementConfig = this;
    }

    private void AutoGenerateArgs()
    {
        var methods = GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
            .ToList().Where(method => method.GetCustomAttributes(typeof(ExtraOptionAttribute)).Any());
        var descriptions = new List<string>();
        var args = new List<string>();
        foreach (var method in methods) 
        {
            descriptions.Add(method.GetCustomAttribute<ExtraOptionAttribute>().Description);
            args.Add(method.Name);
        }
        Descriptions = descriptions.ToArray();
        Arguments = args.ToArray();
    }

    public virtual void Create(string name, Menu menu, string[] args)
    {
        foreach (var arg in args)
        {
            CheckArg(arg);
        }
    }

    private void CheckArg(string arg)
    {
        var method = typeof(MenuButtonConfig).GetMethod(arg, BindingFlags.Instance | BindingFlags.NonPublic);
        method?.Invoke(this, null);
    }
}