//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using BigTask2.Api;
using BigTask2.Data;
using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.IO;
using BigTask2.Problems;
using BigTask2.RequestServerChain;

namespace BigTask2
{
	class Program
	{
        static IEnumerable<Route> ServeRequest(Request request)
        {
            (IGraphDatabase cars, IGraphDatabase trains) = MockData.InitDatabases();

            //if (!ValidateRequest(request))
            //    return null;

            FilteredDatabase database = new FilteredDatabase(new MergedDatabase(cars, trains), request.Filter);

            IRequestServer server = new RequestValidator(
                new CostServer(
                    new TimeServer(
                        new BFSServer(
                            new DFSServer(
                                new DijkstraServer())))));

            return server.Solve(request, null, database);

            //if (request.Problem == "Cost")
            //{
            //    var problem = new CostProblem(request.From, request.To);
            //    problem.Graph = database;
            //    return problem.Solve(request.Solver);
            //}
            //if (request.Problem == "Time")
            //{
            //    var problem = new TimeProblem(request.From, request.To);
            //    problem.Graph = database;
            //    return problem.Solve(request.Solver);
            //}
            //throw new ArgumentException();
		}

       

		static void Main(string[] args)
		{
           Console.WriteLine("---- Xml Interface ----");
            /*
			 * Create XML System Here
             * and execute prepared strings
			 */
            Ui.TaskSystem xmlSystem = CreateSystem(new XmlForm(), new XmlDisplay());
            Execute(xmlSystem, "xml_input.txt");
            Console.WriteLine();

            Console.WriteLine("---- KeyValue Interface ----");
            /*
			 * Create INI System Here
             * and execute prepared strings
			 */
            Ui.TaskSystem keyValueSystem = CreateSystem(new KeyValueForm(), new KeyValueDisplay());
            Execute(keyValueSystem, "key_value_input.txt");
            Console.WriteLine();
        }

        /* Prepare method Create System here (add return, arguments and body)*/
        static Ui.TaskSystem CreateSystem(IForm form, IDisplay display)
        {
            return new Ui.TaskSystem(form, display);
        }

        static void Execute(ISystem system, string path)
        {
            IEnumerable<IEnumerable<string>> allInputs = ReadInputs(path);
            foreach (var inputs in allInputs)
            {
                foreach (string input in inputs)
                {
                    system.Form.Insert(input);
                }
                var request = RequestMapper.Map(system.Form);
                var result = ServeRequest(request);
                system.Display.Print(result);
                Console.WriteLine("==============================================================");
            }
        }

        private static IEnumerable<IEnumerable<string>> ReadInputs(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                List<List<string>> allInputs = new List<List<string>>();
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    List<string> inputs = new List<string>();
                    while (!string.IsNullOrEmpty(line))
                    {
                        inputs.Add(line);
                        line = file.ReadLine();
                    }
                    if (inputs.Count > 0)
                    {
                        allInputs.Add(inputs);
                    }
                }
                return allInputs;
            }
        }
    }
}
