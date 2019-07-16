namespace BorderControl.Core
{
    using BorderControl.Model;
    using BorderControl.Collections;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Engine
    {
        private CitizenCollection citiPopulation;
        private RobotCollection robotCollection;
        public Engine()
        {
            citiPopulation = new CitizenCollection();
            robotCollection = new RobotCollection();
        }
        public void Run()
        {
            string line = string.Empty;
            int counter = 1;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] lineSplit = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (lineSplit.Length == 2)
                {
                    Robot robot = RobotFactory(lineSplit, counter);
                    AddRobot(robot);

                }
                else
                {
                    Citizen citizen = CitizenFactory(lineSplit, counter);
                    AddCitizen(citizen);
                }
                counter++;
            }
            string endWithDigits = Console.ReadLine();
            List<Citizen> reportCitizen = TakeAllCitizenWihtIdEnd(endWithDigits);
            List<Robot> reportRobot = TakeAllRobotsWihtIdEnd(endWithDigits);

            List<string> reportList = RorderOutPutByInputOrder(reportCitizen, reportRobot);
            PrintResult(reportList);
        }

        private void PrintResult(List<string> reportList)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (reportList.Count == 0)
            {
                Console.WriteLine("<empty output>");
            }
            else
            {

                foreach (var id in reportList)
                {
                    Console.WriteLine(id);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private List<Robot> TakeAllRobotsWihtIdEnd(string endWithDigits)
        {
            var report = robotCollection.TakeRevurseId(endWithDigits);
            return report;
        }

        private void AddRobot(Robot robot)
        {
            robotCollection.Add(robot);
        }

        private Robot RobotFactory(string[] lineSplit, int counter)
        {
            string model = lineSplit[0];
            string id = lineSplit[1];
            Robot robot = new Robot(model, id, counter);
            return robot;
        }
        private Citizen CitizenFactory(string[] lineSplit, int counter)
        {
            string name = lineSplit[0];
            int age = int.Parse(lineSplit[1]);
            string id = lineSplit[2];
            Citizen citizen = new Citizen(name, age, id, counter);
            return citizen;

        }

        private List<string> RorderOutPutByInputOrder(List<Citizen> citizenCollection, List<Robot> robots)
        {
            Dictionary<int, string> resultData = new Dictionary<int, string>();

            foreach (var citizen in citizenCollection)
            {
                int inputNumber = citizen.InputNumber;
                string id = citizen.Id;
                resultData.Add(inputNumber, id);
            }
            foreach (var robot in robots)
            {
                int inputNumber = robot.InputNumber;
                string id = robot.Id;
                resultData.Add(inputNumber, id);
            }
            var result = resultData.OrderBy(x => x.Key).Select(x => x.Value).ToList();
            return result;
        }

        private List<Citizen> TakeAllCitizenWihtIdEnd(string endWithDigits)
        {
            var report = citiPopulation.TakeRevurseId(endWithDigits);
            return report;
        }

        private void AddCitizen(Citizen citizen)
        {
            citiPopulation.Add(citizen);
        }

    }
}
