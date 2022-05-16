using ReflectionMoodAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReflectionMoodAnalyzer
{
    public class MoodAnalyseFactory
    {
        public static object CreateMoodAnalyse(string className, string ConstructorName)
        {
            string pattern = @"." + ConstructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }
        }
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string ConstructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(ConstructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");

            }
        }
        public static string InvokeAnalyzeMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("ReflectionMoodAnalyzer.MoodAnalyzer");
                object moodAnalyzerObject = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("ReflectionMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer", message);
                MethodInfo analyzerMoodInfo = type.GetMethod(methodName);
                object mood = analyzerMoodInfo.Invoke(moodAnalyzerObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }
    }
    
}
