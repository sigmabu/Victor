using System;
using System.Reflection;

/// <summary>
/// Single tone
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleTone<T> where T : class
{
    private static volatile T _instance = null;
    private static readonly object _syncRoot = new object();

    /// <summary>
    /// Instance 
    /// </summary>
    public static T It
    {
        get
        {
            if (_instance == null)
                _CreateInstance();

            return _instance;
        }
    }

    private static void _CreateInstance()
    {
        lock (_syncRoot)
        {
            if (_instance == null)
            {
                Type type = typeof(T);

                ConstructorInfo[] ctors = type.GetConstructors();
                if (ctors.Length > 0)
                {
                    throw new InvalidOperationException(string.Format("{0} has at least one accesible ctor making it impossible to enforce singleton behaviour", type.Name));
                }

                _instance = (T)Activator.CreateInstance(type, true);

            }
        }
    }
}

