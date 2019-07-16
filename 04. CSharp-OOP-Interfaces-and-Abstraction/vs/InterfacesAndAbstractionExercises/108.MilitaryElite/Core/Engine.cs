using System;
using MilitaryElite.Model;
using MilitaryElite.Interface;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> army;
        public Engine()
        {
            this.army = new List<ISoldier>();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(" ");
                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);


                if (type == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);
                    this.army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAddArg = commandArgs
                        .Skip(5)
                        .ToArray();

                    foreach (var privateId in privatesToAddArg)
                    {
                        ISoldier soldierToAdd = this.army
                            .First(sol => sol.Id == privateId);
                        general.AddPrivate(soldierToAdd);
                    }
                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairArgs = commandArgs
                            .Skip(6)
                            .ToArray();
                        AddRepairs(engineer, repairArgs);
                        this.army.Add(engineer);

                    }
                    catch (InvalidCorpException ex)
                    {
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionArgs = commandArgs
                            .Skip(6)
                            .ToArray();
                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missionArgs[i];
                                string state = missionArgs[i+1];
                                IMissions mission = new Mission(codeName, state);
                                commando.Add(mission);
                            }
                            catch (InvalidStateException ex)
                            {
                                continue;
                            }
                        }
                        this.army.Add(commando);
                    }
                    catch (InvalidCorpException ex)
                    {
                    }

                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    this.army.Add(spy);
                }
                command = Console.ReadLine();
            }
            PrintOutput();
        }

        private void PrintOutput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var soldier in army)
            {
                Type type = soldier.GetType();
                Object actual = Convert.ChangeType(soldier, type);
                Console.WriteLine(actual.ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AddRepairs(IEngineer engineer, string[] repairArgs)
        {
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hours = int.Parse(repairArgs[i + 1]);
                IRepair repair = new Repair(partName, hours);
                engineer.AddRepair(repair);
            }
        }
    }
}

