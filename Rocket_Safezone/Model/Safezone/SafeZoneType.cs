﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Rocket.Unturned.Player;

namespace Safezone.Model
{
    [XmlInclude(typeof(RectangleType))]
    [XmlInclude(typeof(CircleType))]
    public abstract class SafeZoneType
    {
        private static readonly Dictionary<String, Type> RegistereTypes = new Dictionary<String, Type>();

        public static SafeZoneType RegisterSafeZoneType(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            name = name.ToLower();

            if (!RegistereTypes.ContainsKey(name))
            {
                return null;
            }
            Type t = RegistereTypes[name];
            return (SafeZoneType)Activator.CreateInstance(t);
        }

        public static void RegisterSafeZoneType(String name, Type t)
        {
            if(!typeof(SafeZoneType).IsAssignableFrom(t))
            {
                throw new ArgumentException(t.Name + " is not a SafeZoneType!");
            }

            if (RegistereTypes.ContainsKey(name))
            {
                throw new ArgumentException(name + " is already registered!");
            }

            RegistereTypes.Add(name, t);
        }

        public abstract SafeZone OnCreate(RocketPlayer player, String name, string[] args);
        public abstract bool OnRedefine(RocketPlayer player, string[] args);

        public abstract bool IsInSafeZone(SerializablePosition p);

        public static ReadOnlyCollection<String> GetTypes()
        {
            return new ReadOnlyCollection<string>(new List<string>(RegistereTypes.Keys));
        }
    }
}