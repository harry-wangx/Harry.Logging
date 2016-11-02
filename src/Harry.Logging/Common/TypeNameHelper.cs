﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Harry.Logging.Common
{
    static class TypeNameHelper
    {
        private static readonly Dictionary<Type, string> _builtInTypeNames = new Dictionary<Type, string>
            {
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(object), "object" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(string), "string" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            { typeof(ushort), "ushort" }
            };

        public static string GetTypeDisplayName(Type type)
        {
#if !NET40 && !NET35 && !NET20

            if (type.GetTypeInfo().IsGenericType)
            {
                var fullName = type.GetGenericTypeDefinition().FullName;
                return getTypeDisplayName(fullName);
            }
            else
#endif
            if (_builtInTypeNames.ContainsKey(type))
            {
                return _builtInTypeNames[type];
            }
            else
            {
                var fullName = type.FullName;
#if NET40 || NET35 || NET20

                fullName = getTypeDisplayName(fullName);
#else
                if (type.IsNested)
                {
                    fullName = fullName.Replace('+', '.');
                }
#endif
                return fullName;
            }
        }

        static string getTypeDisplayName(string fullName)
        {
            // Nested types (public or private) have a '+' in their full name
            var parts = fullName.Split('+');

            // Handle nested generic types
            // Examples:
            // ConsoleApp.Program+Foo`1+Bar
            // ConsoleApp.Program+Foo`1+Bar`1
            for (var i = 0; i < parts.Length; i++)
            {
                var partName = parts[i];

                var backTickIndex = partName.IndexOf('`');
                if (backTickIndex >= 0)
                {
                    // Since '.' is typically used to filter log messages in a hierarchy kind of scenario,
                    // do not include any generic type information as part of the name.
                    // Example:
                    // Microsoft.AspNetCore.Mvc -> log level set as Warning
                    // Microsoft.AspNetCore.Mvc.ModelBinding -> log level set as Verbose
                    partName = partName.Substring(0, backTickIndex);
                }

                parts[i] = partName;
            }

            return string.Join(".", parts);
        }
    }
}
