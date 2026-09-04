using Library.BasicTypes.Operators;
using Library.Interfaces;
using System;
using System.Collections.Generic;

namespace GraphExploring.Logic
{
    public sealed class OperatorsCollection
    {
        private OperatorsCollection() { }

        private static readonly Dictionary<char, (Type, char)> knownOperators =
            new()
            {
                {'l', (typeof(LeftOperator), 'r') },
                {'r', (typeof(RightOperator), 'l') },
                {'u', (typeof(UpOperator), 'd') },
                {'d', (typeof(DownOperator), 'u') }
            };
        private static readonly Dictionary<char, SingletonOperator> instances = [];

        public static IOperator GetOperator(char key)
        {
            char lowerCaseKey = char.ToLower(key);
            if (instances.TryGetValue(lowerCaseKey, out SingletonOperator op))
            {
                return op;
            }
            if (knownOperators.TryGetValue(lowerCaseKey, out (Type, char) opType))
            {
                var retType = opType;
                var propinstance = opType.Item1.GetProperty("Instance", System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Static);
                var instance = propinstance.GetGetMethod().Invoke(null, null);
                instances.Add(lowerCaseKey, (SingletonOperator)instance);
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
