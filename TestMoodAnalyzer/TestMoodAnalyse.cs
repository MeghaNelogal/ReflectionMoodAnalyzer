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

        [Test]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstrctor()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("ReflectionMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer", "HAPPY");
            expected.Equals(obj);
        }
        [Test]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "Happy";
            string mood = MoodAnalyseFactory.InvokeAnalyzeMood("Happy", "MoodAnalyze");
            Assert.AreEqual(expected, mood);
        }
        [Test]
        public void GivenHappyMessage_WithReflector_ShouldReturn_Happy()
        {
            string result = MoodAnalyseFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
    }
}
       

    
