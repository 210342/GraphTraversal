using Library.BasicTypes.Operators;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Library.Logic
{
    internal class OperatorsCollection
    {
        private static Dictionary<char, Type> knownOperators =
            new Dictionary<char, Type>()
            {
                {'l', typeof(LeftOperator) },
                {'r', typeof(RightOperator) },
                {'u', typeof(UpOperator) },
                {'d', typeof(DownOperator) }
            };
        private static Dictionary<char, SingletonOperator>
            instances = new Dictionary<char, SingletonOperator>();
        public SingletonOperator this[char key]
        {
            get
            {
                if (instances.TryGetValue(key, out SingletonOperator op))
                {
                    return op;
                }
                if (knownOperators.TryGetValue(key, out Type opType))
                {
                    var retType = opType;
                    var propinstance = opType.GetProperty("Instance", System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.Static);
                    var instance = propinstance.GetGetMethod().Invoke(null, null);
                    instances.Add(key, (SingletonOperator)instance);
                    return (SingletonOperator)instance;
                }
                return null;
            }
        }
    }
}
