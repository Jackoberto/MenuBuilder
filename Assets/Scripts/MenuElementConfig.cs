﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

public abstract class MenuElementConfig : ScriptableObject
{
    public string[] Arguments { get; private set; }
    public string[] Descriptions { get; private set; }
    public bool canCombineArgs;

    public virtual void Awake()
    {
        AutoGenerateArgs();
    }
    
    public virtual void UpdateElements()
    {
        var menuElements = FindObjectsOfType<MenuElement>().ToList();
        foreach (var menuElement in menuElements.Where(menuElement => menuElement.menuElementConfig == this))
        {
            ApplyUpdate(menuElement);
        }
    }

    public virtual void ApplyUpdate(MenuElement menuElement)
    {
        
    }

    protected void AddMenuElement(GameObject gameObject)
    {
        var menuElement = gameObject.AddComponent<MenuElement>();
        menuElement.menuElementConfig = this;
    }

    private void AutoGenerateArgs()
    {
        var methods = GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
            .ToList().Where(method => method.GetCustomAttributes(typeof(DescriptionAttribute)).Any());
        var descriptions = methods.Select(method => method.GetCustomAttribute<DescriptionAttribute>().Description).ToList();
        var args = methods.Select(t => t.Name).ToList();
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