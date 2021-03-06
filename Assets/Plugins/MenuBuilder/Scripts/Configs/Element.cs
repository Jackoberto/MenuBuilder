﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MenuBuilder.Configs
{
    public abstract class Element : ScriptableObject
    {
        public GameObject objectToCreate;
        public string[] Arguments { get; private set; }
        public string[] Descriptions { get; private set; }
        protected IPrefabInstantiator PrefabInstantiator;
        protected IEventTools EventTools;
        [HideInInspector] public bool canCombineArgs;
    
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

        public abstract void Create(IPrefabInstantiator prefabInstantiator, IEventTools eventTools, string name, Menu menu, string[] args);

        protected void CheckAllArgs(IEnumerable<string> args)
        {
            foreach (var arg in args)
            {
                CheckArg(arg);
            }
        }

        protected virtual void OnValidate()
        {
            AutoGenerateArgs();
        }

        private void CheckArg(string arg)
        {
            var method = GetType().GetMethod(arg, BindingFlags.Instance | BindingFlags.NonPublic);
            method?.Invoke(this, null);
        }
    }
}