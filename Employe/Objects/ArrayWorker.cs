using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Employe.Objects
{
    class ArrayWorker : IEnumerable, IEnumerator
    {
        EmployeBase[] workers;
        private int _count = -1;
        private Random Random { get; } = new Random();

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_count == workers.Length - 1)
            {
                Reset();
                return false;
            }
            _count++;
            return true;
        }

        internal void Init(int countOfWorkers)
        {
            workers = new EmployeBase[countOfWorkers];
            for (int i = 0; i < countOfWorkers; i++)
            {
                switch (Random.Next(0, 2))
                {
                    case 0:
                        workers[i] = new EmployeHourly($"Имя_{i}", $"Фамилия_{i}");
                        break;

                    case 1:
                        workers[i] = new EmployeFixed($"Имя_{i}", $"Фамилия_{i}");
                        break;
                }

                if(workers[i] is EmployeHourly)
                {
                    workers[i].GetSalary(Random.Next(5, 500)*10);
                }
                else if(workers[i] is EmployeFixed)
                {
                    workers[i].GetSalary(Random.Next(30, 150)*1000);
                }
            }
        }

        public void Reset()
        {
            _count = -1;
        }
        public object Current => workers[_count];

        public void Sort()
        {
            Array.Sort(workers);
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            foreach (EmployeBase employe in workers)
            {
                sb.Append(workers.ToString());
            }
            return sb.ToString();
        }
    }



    //из урока 8 базового курса
    public class Emploees
    {
        List<EmployeBase> list;
        int index;

        public void Next()
        {
            if (list.Count > index + 1) index++;
        }

        public void Prev()
        {
            if (list.Count > 0) index--;
        }

        public void Add(EmployeBase emploee)
        {
            list.Add(emploee);
            index = list.Count - 1; //перепрыгиваем в конец списка
        }

        public Emploees()
        {
            list = new List<EmployeBase>();
            index--;
        }

        public EmployeBase CurrentEmployee
        {
            get
            {
                try { return list[index]; }
                catch { return null; }
            }
        }

        public void Save(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EmployeBase>));
            //создаем файловы поток
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // в этот поток записываем сериализованные данные
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
            index = 0;
        }

        public void Load(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EmployeBase>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            List<EmployeBase> list = (List<EmployeBase>)xmlFormat.Deserialize(fStream);
            fStream.Close();
            index = 0;
        }



    }



}
