﻿using Library.BasicTypes.Operators;
using Library.Interfaces;
using System;
using System.Collections.Generic;

namespace GraphExploring.Logic
{
    internal class OperatorsCollection
    {
        private OperatorsCollection() { }

        private static Dictionary<char, (Type, char)> knownOperators =
            new Dictionary<char, (Type, char)>()
            {
                {'l', (typeof(LeftOperator), 'u') },
                {'r', (typeof(RightOperator), 'l') },
                {'u', (typeof(UpOperator), 'd') },
                {'d', (typeof(DownOperator), 'u') }
            };
        private static Dictionary<char, SingletonOperator>
            instances = new Dictionary<char, SingletonOperator>();

        public static IOperator GetOperator(char key)
        {
            if (instances.TryGetValue(key, out SingletonOperator op))
            {
                return op;
            }
            if (knownOperators.TryGetValue(key, out (Type, char) opType))
            {
                var retType = opType;
                var propinstance = opType.Item1.GetProperty("Instance", System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Static);
                var instance = propinstance.GetGetMethod().Invoke(null, null);
                instances.Add(key, (SingletonOperator)instance);
                return (SingletonOperator)instance;
            }
            return null;
        }
        public static IOperator GetReverse(IOperator op)
        {
            if (op == null)
                return null;
            return GetOperator(knownOperators[op.Representation].Item2);
        }

    }
}
