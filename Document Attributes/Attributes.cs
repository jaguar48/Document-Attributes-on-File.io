using System.Reflection;

namespace DocumentAttribute
{


    [AttributeUsage(AttributeTargets.All, AllowMultiple = true),]
    public class DocumentAttribute : Attribute
    {
        [Document("This makes a get and set for the description")]
        public string Description { get; set; }
        [Document("This makes a get and set for the input")]
        public string Input { get; set; }
        [Document("This makes a get and set for the output")]
        public string Output { get; set; }

        [Document("This is a sample constructor that takes only one parameter", "takes description as input")]
        public DocumentAttribute(string description, string input = "", string output = "")
        {
            Input = input;
            Output = output;
            Description = description;
        }
    }

    [Document("This is a sample class", " sample input parameters")]
    public class SampleClass
    {
      

       
        [Document("This is a sample method", "input parameters", "output parameters")]
        public string SampleMethod(string name)
        {
            return name + " is a student of " + SchoolEnum.Brighgirls;

        }

    }
    [Document("This contains enumerable for schools")]
    public enum SchoolEnum
    {
        Highschool,
        Brightdays,
        Brighgirls
    }

}
