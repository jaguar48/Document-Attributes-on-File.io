
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Xml;

namespace DocumentAttribute
{

    internal class Program
    {
        public static string ? savestr = null;
        public static string FilePath = @"C:/Users/HP/Downloads/filea.txt";
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
                       

                        File.AppendAllText(FilePath, $"{attribute.Description} \n {attribute.Input} \n {attribute.Output} \n \n");
                      
                    }
                }
            }
        }
      
        public static void GetClass(Type type)
        {
            object[] classinfo = type.GetCustomAttributes(true);
            foreach (object attr in classinfo)
            {
                if (attr is DocumentAttribute)
                {
                    

                    DocumentAttribute attribute = (DocumentAttribute)attr;

                   

                    SaveAsJsonFormat(attribute.Description, @"C:/Users/HP/Downloads/Myfile4.json");

                 

                    File.AppendAllText(FilePath, $"{attribute.Description} \n {attribute.Input} \n \n");

                }
            }

        }
     
    

        public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };
            File.WriteAllText(fileName, JsonSerializer.Serialize(objGraph, options));
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

                        File.AppendAllText(FilePath, $"{attribute.Description} \n {attribute.Input} \n {attribute.Output} \n");
                    }
                }

            }

        }
        public static void GetDocs()
        {
           

            Assembly assembly = Assembly.GetExecutingAssembly();
           

            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
            {
                GetClass(t);
                GetMethods(t);
                GetProps(t);
              
                Console.WriteLine();
            }
            Console.WriteLine(File.ReadAllText(FilePath));


        }
       

        static void Main(string[] args)
        {
           

            Program.GetDocs ();
            
        }
    }
}