using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    public class IOConsole
    {
        private readonly string _filename;
        private int _N;
        private int _A;
        private int _B;
        private int[,] _matrix;
        public int N { get => _N; }
        public int From { get => _A; }
        public int To { get => _B; }
        public int[,] CMatrix { get => _matrix; }
        public IOConsole()
        {
            _filename = null;
            _matrix = null;
        }
        public IOConsole(string filename)
        {
            _filename = filename;
            _matrix = null;
        }
        public void ReadMatrix()
        {
            StreamReader streamReader = new StreamReader(_filename, Encoding.UTF8);
            _N = Convert.ToInt32(streamReader.ReadLine());
            var destinationLine = streamReader.ReadLine();
            var _from_to = new List<int>();
            foreach (var x in destinationLine.Trim().Split(' '))
                _from_to.Add(Convert.ToInt32(x));
            _A = _from_to[0];
            _B = _from_to[1];

            var buffer = streamReader.ReadToEnd();
            _matrix = new int[_N, _N];
            Fill();
            var i = 0;
            foreach (var row in buffer.Split('\n'))
            {
                var j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    _matrix[i, j] = Convert.ToInt32(col.Trim());
                    j++;
                }
                i++;
            }
            streamReader.Close();
        }
        public void WriteMatrix(int[,] A)
        {
            for (var i = 0; i < _N; i++)
            {
                for (var j = 0; j < _N; j++)
                    Console.Write(A[i, j].ToString() + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void WriteFlowMatrixToConsole(int[,] A, int[,] B)
        {
            for (var i = 0; i < _N; i++)
            {
                for (var j = 0; j < _N; j++)
                {
                    if (A[i, j] == 0)
                        Console.Write("(....) ");
                    else
                        Console.Write("(" + B[i, j].ToString() + "/" + A[i, j].ToString() + ") ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
   
        public void WriteListToConsole(List<int> list, int cost)
        {
            foreach (var x in list)
                Console.Write((x + 1).ToString() + " ");
            Console.WriteLine("\n Cost = " + cost.ToString());
        }
        public void WriteListToFile(List<int> list, int cost, StreamWriter fileWriter)
        {
            foreach (var x in list)
                fileWriter.Write((x + 1).ToString() + " ");
            fileWriter.WriteLine("\n Cost = " + cost.ToString());
        }
        public StreamWriter GetFileStream()
        {
            Console.WriteLine("Enter a filename: (with .txt)");
            var filename = Console.ReadLine();
            if (!filename.Contains(".txt"))
                throw new Exception("Invalid filename");
            StreamWriter fileWriter = new StreamWriter(filename);
            return fileWriter;

        }
        public void Fill()
        {
            for (var i = 0; i < _N; i++)
                for (var j = 0; j < _N; j++)
                    _matrix[i, j] = 0;
        }
        public int[,] GetNullMatrix()
        {
            var m = new int[_N, _N];
            for (int i = 0; i < _N; i++)
            {
                for (int j = 0; j < _N; j++)
                    m[i, j] = 0;
            }
            return m;
        }
        public void WriteTimeToFile(List<double> time, string filename)
        {
            filename = $"{filename}_{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}_{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.txt";
            using (StreamWriter fileWriter = new StreamWriter(filename))
            {
                for (var i = 0; i < time.Count; i++)
                {
                    fileWriter.WriteLine(time[i].ToString());
                }
            }
        }
    }
}
