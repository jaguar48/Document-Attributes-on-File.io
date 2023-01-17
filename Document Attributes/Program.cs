
using System.Reflection;

namespace DocumentAttribute
{

    internal class Program
    {

        public static void GetMethods(Type type)
        {


            MethodInfo[] getmeth = type.GetMethods();
            for (int i = 0; i < getmeth.GetLength(0); i++)
            {
                object[] methinfo = getmeth[i].GetCustomAttributes(true);

                foreach (Attribute doc in methinfo.Cast<Attribute>())
                {
                    if (doc is DocumentAttribute)
                    {
                        DocumentAttribute attribute = (DocumentAttribute)doc;

                        Console.WriteLine(attribute.Description);
                    }
                }
            }
        }
        public static void GetClass(Type type)
        {
            Console.WriteLine("Assembly: {0}", Assembly.GetExecutingAssembly());
            object[] classinfo = type.GetCustomAttributes(true);
            foreach (object attr in classinfo)
            {
                if (attr is DocumentAttribute)
                {
                    DocumentAttribute attribute = (DocumentAttribute)attr;

                    Console.WriteLine($"{attribute.Description} {attribute.Input}");
                }
            }

        }
        public static void GetProps(Type type)
        {
            PropertyInfo[] propinfo = type.GetProperties();
            for (int i = 0; i < propinfo.Length; i++)
            {
                object[] prop = propinfo[i].GetCustomAttributes(true);

                foreach (Attribute myprop in prop.Cast<Attribute>())
                {
                    if (myprop is DocumentAttribute)
                    {
                        DocumentAttribute attribute = (DocumentAttribute)myprop;

                        Console.WriteLine(attribute.Description);
                    }
                }

            }

        }
        public static void GetDocs(Type type)
        {
            GetClass(type);
            GetMethods(type);
            GetProps(type);
        }



        static void Main(string[] args)
        {
            Program.GetDocs(typeof(SchoolEnum));

            SampleClass sam = new SampleClass();

            Console.WriteLine(sam.SampleMethod("stanley"));
        }
    }
}