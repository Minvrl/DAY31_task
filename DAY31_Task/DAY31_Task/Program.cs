using DAY31_Task;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

#region Task 2.1
Person person1 = null;
//person1 = new Person()
//{
//    Fullname = "Mimi",
//    Age = 18
//};


//SerializeJson(person1);
person1 = DeserializeJson();

Console.WriteLine(person1);


void SerializeJson(Person person)
{
    using (FileStream fs = new FileStream("C:\\Users\\Comp\\source\\repos\\DAY31_Task\\DAY31_Task\\Data\\person.json",FileMode.Create))
    {
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
        jsonSerializer.WriteObject(fs, person);
    }
}

Person DeserializeJson()
{
    Person Data = null;
    using (FileStream fs = new FileStream("C:\\Users\\Comp\\source\\repos\\DAY31_Task\\DAY31_Task\\Data\\person.json",FileMode.Open))
    {
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof (Person));
        Data = jsonSerializer.ReadObject(fs) as Person;
    }
    return Data;

}

#endregion


#region Task 2.2
List<Person> personlist = new List<Person>();

//SerializeJsonList(personlist);


string opt,name,ageStr;
byte age;
do
{
    Console.WriteLine("1. Person yarat");
    Console.WriteLine("2. Butun personlara bax");
    Console.WriteLine("0. Cix");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            do
            {
                Console.Write("Ad daxil edin - ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            do
            {
                Console.Write(" Yas daxil edin - ");
                ageStr = Console.ReadLine();
            } while (!byte.TryParse(ageStr, out age) || age < 0);

            Person newPerson = new Person()
            {
                Fullname = name,
                Age = age
            };

            SerializeJsonList(personlist, newPerson);
            break;

        case "2":
            personlist = DeserializeJsonList();
            if (personlist.Count ==0) Console.WriteLine("Siyahi bosdur");
            foreach (var person in personlist)
            {
                Console.WriteLine(person);
            }
            break;
        case "0":
            Console.WriteLine("Proqram bitdi");
            break;
        default:
            Console.WriteLine("Duzgun operator daxil edin !");
            break;
    }


} while (opt != "0");

void SerializeJsonList(List<Person> personlist,Person newPerson)
{
    personlist = DeserializeJsonList();
    personlist.Add(newPerson);

    using (FileStream fs = new FileStream("C:\\Users\\Comp\\source\\repos\\DAY31_Task\\DAY31_Task\\Data\\personlist.json", FileMode.Create))
    {
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Person>));
        jsonSerializer.WriteObject(fs, personlist);
    }
}


List<Person> DeserializeJsonList()
{
    List<Person> personlist = null;
    string filePath = "C:\\Users\\Comp\\source\\repos\\DAY31_Task\\DAY31_Task\\Data\\personlist.json";

    if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Person>));
            personlist = jsonSerializer.ReadObject(fs) as List<Person>;
        }
    }
    return personlist;
}


#endregion