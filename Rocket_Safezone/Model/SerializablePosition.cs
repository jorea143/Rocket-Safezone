﻿using System;
using System.Xml.Serialization;
using UnityEngine;

namespace Safezone.Model
{
    [Serializable]
    [XmlType(TypeName = "Position")]
    public class SerializablePosition
    {
        public SerializablePosition()
        {
            X = 0;
            Y = 0;
        }

        public SerializablePosition(Vector3 vec)
        {
            X = vec.x;
            Y = vec.y;
        }

        [XmlAttribute("x")]
        public float X;
        [XmlAttribute("y")]
        public float Y;
    }
}