using NUnit.Framework;
using ReflectionMoodAnalyzer;

namespace TestMoodAnalyzer
{
    public class MoodAnalyse
    {
       
        [Test]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyzer();
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("ReflectionMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }

    }
}
    
